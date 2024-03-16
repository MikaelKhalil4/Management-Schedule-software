using CustomizedTools;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;


namespace MKproject.Management
{
    public partial class EditBundleProduct : Form
    {
        public ViewBundlesAndProducts ParentFormViewBundle;

        public bool Edit;
        public bool BundleOrProduct;
        public int? ID;
        public DataRow DesiredRow;
        public UCTextbox1 UCDescription;
        private UCTextbox1 UCBundleName;
        public bool ButtonSaveClicked = false;//kermel l ucpayment la n8ayir lawna 
        SqlConnection con = new SqlConnection(Program.DataLocation);
        Color ColorBackTExtbOxEditMode = Color.White;


        public EditBundleProduct(bool edit, bool bundleorproduct, DataRow desiredRow)
        {
            InitializeComponent();


            Edit = edit;
            BundleOrProduct = bundleorproduct;
            DesiredRow = desiredRow;

            if (BundleOrProduct)
            {
                OpenAsBundle();
            }
            else
            {
                OpenAsProduct();
            }


            if (!Edit)//for packages and products
            {
                UCBundleName.myTextBox1.Select();
                checkBoxStatus.Visible = false;
                this.Height = this.Height - (checkBoxStatus.Height + checkBoxMemberShip.Height);
            }


            this.Opacity = 0;
            this.TopMost = true;
        }



        //bundles
        void OpenAsBundle()
        {
            CreateBundlesFields();


            //
            comboBoxBundle.Items.Add(ClassBundles.enumBundle.Sessions);
            comboBoxBundle.Items.Add(ClassBundles.enumBundle.Days);
            comboBoxBundle.Items.Add(ClassBundles.enumBundle.Solo);
            comboBoxBundle.SelectedIndex = 0;
            //

            if (Edit)
            {
                this.Text = "Edit Bundle";
                FillBundlesFields();
            }
        }
        void CreateBundlesFields()
        {
            this.Text = "Add Bundle";

            UCBundleName = new UCTextbox1("Service Name", true);
            FLPTop.Controls.Add(UCBundleName);
            FLPTop.Controls.SetChildIndex(UCBundleName, 0);
            UCBundleName.Size = new Size(420, 72);
            UCBundleName.Margin = new Padding(3, 10, 3, 10); // (left, top, right, bottom)


            UCDescription = new UCTextbox1("Description", false);
            FLPTop.Controls.Add(UCDescription);
            FLPTop.Controls.SetChildIndex(UCDescription, 1);
            UCDescription.Size = new Size(420, 72);
            UCDescription.Margin = new Padding(3, 10, 3, 10); // (left, top, right, bottom)


            UCNOSessionsOrDay.Minimum_number = 1;
            UCNOSessionsOrDay.Maximum_number = 9999;
            UCNOSessionsOrDay.Number = 1;
            UCNOSessionsOrDay.textBoxValue.BackColor = ColorBackTExtbOxEditMode;
            UCNOSessionsOrDay.BackColor= this.BackColor; 
            UCNOSessionsOrDay.buttonValueMinus.BackColor = this.BackColor;
            UCNOSessionsOrDay.buttonValuePlus.BackColor = this.BackColor;

            UCBundleName.NextControl = UCDescription.myTextBox1;
            UCDescription.NextControl = ucPaymentsPrice.textBoxPayment;

            checkBoxMemberShip.Visible = true;
        }
        void FillBundlesFields()
        {
            string BundleName = DesiredRow["bundle_name"].ToString();

            string Description;
            if (DesiredRow["description"].ToString() != "N/A")
            {
                Description = DesiredRow["description"].ToString();
            }
            else
            {
                Description = null;
            }

            int? SessionNumber;
            if (DesiredRow["sessions_numb"] != DBNull.Value)
            {
                SessionNumber = Convert.ToInt32(DesiredRow["sessions_numb"]);
            }
            else
            {
                SessionNumber = null;
            }

            string BundleType = DesiredRow["bundle_type"].ToString();

            double? Price;
            if (DesiredRow["price"] != DBNull.Value)
            {
                Price = Convert.ToDouble(DesiredRow["price"]); ;
            }
            else
            {
                Price = null;
            }

            bool Status = Convert.ToBoolean(DesiredRow["status"]);
            bool IsMemberShip = Convert.ToBoolean(DesiredRow["is_member_ship"]);




            if (SessionNumber != null)//in case in solo it will be null
            {
                UCNOSessionsOrDay.Number = (int)SessionNumber;
            }
            ucPaymentsPrice.Amount = (double)Price;
            UCDescription.FillDesignValue(Description);
            UCBundleName.FillDesignValue(BundleName);
            checkBoxStatus.Checked = Status;
            checkBoxMemberShip.Checked = IsMemberShip;
            comboBoxBundle.SelectedIndex = comboBoxBundle.FindString(BundleType);


        }
        public void AddBundle()
        {
            ClassBundles bundle = new ClassBundles();

            bundle.BundleName = UCBundleName.Value;
            bundle.Description = UCDescription.Value;
            bundle.Price = ucPaymentsPrice.Amount;
            bundle.EnumBundletype = (ClassBundles.enumBundle)Enum.Parse(typeof(ClassBundles.enumBundle), comboBoxBundle.SelectedItem.ToString());

            if (bundle.EnumBundletype == ClassBundles.enumBundle.Solo)
            {
                bundle.SessionDaysNumber = null;
            }
            else
            {
                bundle.SessionDaysNumber = UCNOSessionsOrDay.Number;
            }

            bundle.IsMemberShip = checkBoxMemberShip.Checked;

            bundle.InsertBundle();

            DataTable dtinserteditem = ClassBundles.GetLastInsertBundle();
            ParentFormViewBundle.FormatdtBundles(dtinserteditem);
            DataRow InsertedRow = dtinserteditem.Rows[0];//0 since it s only one row retrieve which is the new one 

            //Design        
            DataRow NewRow = ParentFormViewBundle.dtBundles.NewRow();
            NewRow.ItemArray = InsertedRow.ItemArray; // Copy the data from InsertedRow to NewRow
            ParentFormViewBundle.dtBundles.Rows.InsertAt(NewRow, 0);
            ParentFormViewBundle.dataGridViewEdit.FirstDisplayedScrollingRowIndex = 0;
        }
        public void UpdateBundle()
        {
            ClassBundles bundle = new ClassBundles();

            bundle.BundleID = (int)DesiredRow["bundle_id"];
            bundle.BundleName = UCBundleName.Value;
            bundle.Description = UCDescription.Value;
            bundle.Price = ucPaymentsPrice.Amount;
            bundle.EnumBundletype = (ClassBundles.enumBundle)Enum.Parse(typeof(ClassBundles.enumBundle), comboBoxBundle.SelectedItem.ToString());

            if (bundle.EnumBundletype == ClassBundles.enumBundle.Solo)
            {
                bundle.SessionDaysNumber = null;
            }
            else
            {
                bundle.SessionDaysNumber = UCNOSessionsOrDay.Number;
            }

            bundle.IsMemberShip = checkBoxMemberShip.Checked;
            bundle.Status = checkBoxStatus.Checked;

            bundle.UpdateBundle();

            //design
            DesiredRow["bundle_name"] = bundle.BundleName;
            DesiredRow["bundle_type"] = bundle.EnumBundletype;
            DesiredRow["price"] = bundle.Price;
            DesiredRow["status"] = bundle.Status;
            DesiredRow["FakeStatus"] = bundle.Status;
            DesiredRow["is_member_ship"] = bundle.IsMemberShip;
            DesiredRow["FakeMemberShip"] = bundle.IsMemberShip;

            string bundles;
            if (bundle.EnumBundletype == ClassBundles.enumBundle.Solo)
            {
                bundles = bundle.EnumBundletype.ToString();
            }
            else
            {
                bundles = bundle.SessionDaysNumber.ToString() + " " + bundle.EnumBundletype.ToString();
            }

            DesiredRow["Bundle"] = bundles;


            if (bundle.Description != null)
            {
                DesiredRow["description"] = bundle.Description;
            }
            else
            {
                DesiredRow["description"] = "N/A";
            }

        }
        public bool BundleNameExists(string BundleName)
        {
            if (DesiredRow != null && BundleName == DesiredRow["bundle_name"].ToString())
            {
                return false;
            }
            else
            {
                DataTable dt = ParentFormViewBundle.dtBundles;
                BundleName = BundleName.Trim();

                bool bundleExists = dt.AsEnumerable().Any(row => row.Field<string>("bundle_name") == BundleName);

                if (bundleExists)
                {

                    CustomMessageBox.Show("Bundle Name is already taken", CustomMessageBox.Type.Ok);
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }//try catch
        bool CheckRequiredBundles()
        {
            bool a = true;
            if (UCBundleName != null && UCBundleName.ActiveRequiredMode())
            {
                a = false;
            }
            if (comboBoxBundle.SelectedItem.ToString() != ClassBundles.enumBundle.Solo.ToString())
            {
                if (UCNOSessionsOrDay.Number == 0)
                {
                    groupBoxNumberOfSessions.BorderColor = Color.Red;
                    a = false;
                }
            }
            return a;
        }

        private void comboBoxDetail_DropDown(object sender, EventArgs e)
        {
            groupBoxPrice.Select();
        }
        private void comboBoxDetail_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxBundle.SelectedItem.ToString() == ClassBundles.enumBundle.Solo.ToString())
            {
                UCNOSessionsOrDay.Hide();
                TLPBundle.SetColumnSpan(comboBoxBundle, 2);
                comboBoxBundle.Anchor = AnchorStyles.None;

            }
            else
            {
                UCNOSessionsOrDay.Show();
                TLPBundle.SetColumnSpan(comboBoxBundle, 1);
                comboBoxBundle.Anchor = AnchorStyles.Right;
            }
            groupBoxPrice.Select();
        }




        //products
        void OpenAsProduct()
        {
            CreateProductFields();
            if (Edit)
            {
                this.Text = "Edit Product";
                FillProductFields();
            }
 
        }
        void CreateProductFields()
        {
            this.Text = "Add Product";
            UCBundleName = new UCTextbox1();
            FLPTop.Controls.Add(UCBundleName);
            FLPTop.Controls.SetChildIndex(UCBundleName, 0);
            UCBundleName.Size = new Size(420, 72);
            // Check if the "Required" value is true or false
            UCBundleName.IsRequired = true;
            UCBundleName.StringType = "Product Name";
            UCBundleName.Margin = new Padding(3, 10, 3, 10); // (left, top, right, bottom)

            groupBoxNumberOfSessions.Visible = false;

            this.Height = 375;

            UCBundleName.NextControl = ucPaymentsPrice.textBoxPayment;

            checkBoxMemberShip.Visible = false;
        }
        void FillProductFields()
        {
            string ProductName = DesiredRow["product_name"].ToString();
            int ProductPrice = Convert.ToInt32(DesiredRow["product_price"]);
            bool Status = Convert.ToBoolean(DesiredRow["status"]);


            UCBundleName.FillDesignValue(ProductName);
            ucPaymentsPrice.Amount = (int)ProductPrice;
            checkBoxStatus.Checked = Status;
        }
        public void AddProduct()
        {
            ClassProduct product = new ClassProduct();

            product.Name = UCBundleName.Value;
            product.Price = ucPaymentsPrice.Amount;

            product.InsertProduct();

            DataTable dtinserteditem = ClassProduct.GetLastInsertProduct();
            ParentFormViewBundle.FormatdtProducts(dtinserteditem);
            DataRow InsertedRow = dtinserteditem.Rows[0];//0 since it s only one row retrieve which is the new one 

            //Design        
            DataRow NewRow = ParentFormViewBundle.dtProducts.NewRow();
            NewRow.ItemArray = InsertedRow.ItemArray; // Copy the data from InsertedRow to NewRow
            ParentFormViewBundle.dtProducts.Rows.InsertAt(NewRow, 0);
            ParentFormViewBundle.dataGridViewEdit.FirstDisplayedScrollingRowIndex = 0;
        }
        public void UpdateProduct()
        {
            ClassProduct product = new ClassProduct();

            product.Name = UCBundleName.Value;
            product.Price = ucPaymentsPrice.Amount;
            product.Status = checkBoxStatus.Checked;
            product.ID = (int)DesiredRow["product_id"];
            product.UpdateProduct();

            //design
            DesiredRow["product_name"] = product.Name;
            DesiredRow["product_price"] = product.Price;
            DesiredRow["status"] = product.Status;
            DesiredRow["FakeStatus"] = product.Status;
        }
        public bool ProductNameExists(string productName)
        {
            if (DesiredRow != null && productName == DesiredRow["product_name"].ToString())
            {
                return false;
            }
            else
            {
                DataTable dt = ParentFormViewBundle.dtProducts;
                productName = productName.Trim();

                bool productExists = dt.AsEnumerable().Any(row => row.Field<string>("product_name") == productName);

                if (productExists)
                {
                    CustomMessageBox.Show("Product Name is already taken", CustomMessageBox.Type.Ok);
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }//try catch
        bool CheckRequiredProduct()
        {
            bool a = true;
            if (UCBundleName != null && UCBundleName.ActiveRequiredMode())
            {
                a = false;
            }

            return a;
        }



        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            ButtonSaveClicked = true;
            if (BundleOrProduct)
            {
                if (CheckRequiredBundles())
                {
                    if (Edit)
                    {
                        if (!BundleNameExists(UCBundleName.myTextBox1.Text))
                        {
                            UpdateBundle();
                            this.Close();
                        }
                    }
                    else
                    {
                        if (!BundleNameExists(UCBundleName.myTextBox1.Text))
                        {
                            AddBundle();
                            this.Close();
                        }
                    }
                }
            }
            else
            {
                if (CheckRequiredProduct())
                {
                    if (Edit)
                    {
                        if (!ProductNameExists(UCBundleName.myTextBox1.Text))
                        {
                            UpdateProduct();
                            this.Close();
                        }
                    }
                    else
                    {
                        if (!ProductNameExists(UCBundleName.myTextBox1.Text))
                        {
                            AddProduct();
                            this.Close();
                        }
                    }
                }
            }
          
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Opacity == 1)
            {
                timer1.Stop();
            }
            Opacity += .1;
        }

        private void EditBundleProduct_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Program.GreyForm != null)
            {
                Program.GreyForm.Close();
                Program.GreyForm = null;
            }
        }

        private void buttonCancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (BundleOrProduct)
            {
                ClassBundles bundle = new ClassBundles();
                bundle.BundleID = (int)DesiredRow["bundle_id"];
                if (bundle.CheckIBundletHasReferences())
                {
                    CustomMessageBox.Show("Cannot delete this Bundle as there is some data attached to them.", CustomMessageBox.Type.Ok);
                }
                else
                {
                    bundle.DeleteBundle();
                    DesiredRow.Delete();
                    this.Close();
                }

            }
            else
            {
                ClassProduct product = new ClassProduct();
                product.ID = (int)DesiredRow["product_id"];
                if (product.CheckIProductHasReferences())
                {
                    CustomMessageBox.Show("Cannot delete this Product as there is some data attached to them.", CustomMessageBox.Type.Ok);
                }
                else
                {
                    product.DeleteProducts();
                    DesiredRow.Delete();
                    this.Close();
                }
            }
        }
    }
}
