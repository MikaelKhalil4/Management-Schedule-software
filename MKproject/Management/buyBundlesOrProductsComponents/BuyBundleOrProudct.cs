using GlobalFunctions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;


namespace MKproject.Management
{
    public partial class BuyBundleOrProudct : Form
    {
        bool IsBundle;//true = bundle, false= product


        public ClientManagementProfile ParentFormClientMang { get; set; }

        public List<ClassProduct> ProductList = new List<ClassProduct>();
        public List<ClassBundles> BundleList = new List<ClassBundles>();

        public BuyBundleOrProudct(bool isbundle)//tarrayna nhat el client id hone cz we re going to use this form also in new register
        {
            InitializeComponent();

            this.Opacity = 0;
            this.TopMost = true;
            IsBundle = isbundle;
            LoadUC();
        }


        public void LoadUC()
        {
            if (IsBundle)
            {
                UCBundlesOutput uc = new UCBundlesOutput(null);
                uc.ParentFormBuy = this;
                uc.Dock = DockStyle.Fill;
                uc.Margin = new Padding(7, 0, 7, 0);
                TLPExercises.Controls.Add(uc, 0, 2);
            }
            else
            {
                UCProductOutput uc = new UCProductOutput();
                uc.ParentFormBuy = this;
                uc.Dock = DockStyle.Fill;
                uc.Margin = new Padding(7, 0, 7, 0);
                TLPExercises.Controls.Add(uc, 0, 2);
            }
        }

        public void AddItem(ClassBundles bundle, ClassProduct product)
        {

            double price;

            if (bundle != null)//bundle
            {
                UCItem ucBundle = new UCItem();
                ucBundle.ucNOItem.Minimum_number = 1;
                ucBundle.ucNOItem.Maximum_number = 100;
                ucBundle.TextBoxValueTextChange += ucBundle_TextBoxValueTextChange;
                FLPSelectedItems.Controls.Add(ucBundle);

                ucBundle.Id = bundle.BundleID;
                ucBundle.Title = bundle.BundleName;
                ucBundle.NOItem = 1;
                price = bundle.Price;
                BundleList.Add(bundle);

            }
            else//product
            {
                UCItem ucProduct = new UCItem();
                ucProduct.ucNOItem.Minimum_number = 1;
                ucProduct.ucNOItem.Maximum_number = 100;
                ucProduct.TextBoxValueTextChange += UcProduct_TextBoxValueTextChange; ;
                FLPSelectedItems.Controls.Add(ucProduct);

                ucProduct.Id = product.ID;
                ucProduct.Title = product.Name;
                ucProduct.NOItem = 1;
                price = product.Price;
                ProductList.Add(product);
            }

            UCItemCost.Amount += price;
        }

        private void UcProduct_TextBoxValueTextChange(object sender, EventArgs e)
        {
            UCItem ucProduct = (UCItem)sender;
            UCItemCost.Amount = 0;
            double Amount = 0;
            foreach (var product in ProductList)
            {
                if (product.ID == ucProduct.Id)
                {
                    // Modify the property you want to change
                    product.Qty = ucProduct.ucNOItem.Number;
                }
                for (int i = 0; i < product.Qty; i++)
                {
                    Amount += product.Price;
                }
            }
            UCItemCost.Amount = Amount;
        }

        private void ucBundle_TextBoxValueTextChange(object sender, EventArgs e)
        {
            UCItem ucBundle = (UCItem)sender;
            UCItemCost.Amount = 0;
            double Amount = 0;
            foreach (var bundle in BundleList)
            {
                if (bundle.BundleID == ucBundle.Id)
                {
                    // Modify the property you want to change
                    bundle.Qty = ucBundle.ucNOItem.Number;
                }
                for (int i = 0; i < bundle.Qty; i++)
                {
                    Amount += bundle.Price;
                }
            }
            UCItemCost.Amount = Amount;

        }

        public void RemoveButton(int id, double price)
        {
            foreach (UCItem ucItem in FLPSelectedItems.Controls)
            {
                if (ucItem.Id == id)
                {
                    ucItem.Dispose();
                    break;
                }
            }
            FLPSelectedItems.PerformLayout();
            UCItemCost.Amount -= price;
        }


        private void buttonBuy_Click(object sender, EventArgs e)
        {

            if (IsBundle)
            {
                if (BundleList.Count > 0)
                {

                    DateTime Date = DateTime.Now;
                    bool OneOfThePackgesIsMemberShip = false;
                    int NOBundles = 0;
                    foreach (ClassBundles Bundle in BundleList)
                    {
                        for (int i = 0; i < Bundle.Qty; i++)
                        {
                           //Sql And Logic
                            DataTable dtinserteditem = ClassClient.PurchaseAService(Bundle, Date, Date, ParentFormClientMang.Client,null);//hattayneha global lieanno ha nestaamela men kaza mahal
                            DateTime NewCheckInDate = SQLToProject.GetMaxAttendanceDateOfClient(ParentFormClientMang.Client.ClientId);//ma stamlna DateTime.Now, lieanno ma32oul ma tetghayar, eza fi date akbar menna


                        //Design
                        //updating originaldatable
                        DataRow InsertedRow = dtinserteditem.Rows[0];

                            DataRow NewRow = ParentFormClientMang.dtClientBalanceOriginal.NewRow();
                            NewRow.ItemArray = InsertedRow.ItemArray; // Copy the data from InsertedRow to NewRow
                            ParentFormClientMang.dtClientBalanceOriginal.Rows.Add(NewRow);

                            ParentFormClientMang.CheckAndSetNoBundleLabel();

                            if (ParentFormClientMang.dtClientBalanceOriginal.Rows.Count != 1)//kermel first row , bi kun already 1
                            {
                                NewRow["AutoIncrementColumn"] = Convert.ToInt32(ParentFormClientMang.dtClientBalanceOriginal.Compute("MAX(AutoIncrementColumn)", "")) + 1;
                            }
                            if (Bundle.SessionDaysNumber != null)
                            {
                                //Add UCbundle
                                ParentFormClientMang.CreateUCPackage(NewRow);
                            }


                            if (Bundle.IsMemberShip == true)
                            {
                                OneOfThePackgesIsMemberShip = true;

                            }

                            if (Bundle.EnumBundletype == ClassBundles.enumBundle.Solo)
                            {
                                ParentFormClientMang.UCLastVisit.Detail = RandomFunctions.SetDateFormat(NewCheckInDate.ToString());
                                ParentFormClientMang.Client.LastVisit = NewCheckInDate;

                                ParentFormClientMang.Client.TotalAttendance++;
                                ParentFormClientMang.UCTotalAttendance.Detail = Convert.ToString(ParentFormClientMang.Client.TotalAttendance);
                            }


                            //shi elo aalea bel token bundle
                            NOBundles++;

                        }
                    }
               
                    //design
                    ParentFormClientMang.UCTokenServices.Detail = Convert.ToString(NOBundles + Convert.ToInt16(ParentFormClientMang.UCTokenServices.Detail));


                    //Check if Member , if mo update in sql
                    if (OneOfThePackgesIsMemberShip == true && ParentFormClientMang.Client.RegistrationDate == null)
                    {
                        //!!!!!sql naamalit bel  ClassClient.PurchaseAService kremel el schedule also
                        //ClassClient.MakeClientMemberSQL(ParentFormClientMang.Client.ClientId);

                        //design
                        ParentFormClientMang.UCMemberSince.Detail = RandomFunctions.SetDateFormat(Date.ToString());
                        ParentFormClientMang.Client.RegistrationDate = Date;

                    }

                    this.Close();
                }

            }
            else
            {
                if (ProductList.Count > 0)
                {
                    DateTime Date = DateTime.Now;
                    int NOProducts = 0;
                    foreach (ClassProduct product in ProductList)
                    {
                        for (int i = 0; i < product.Qty; i++)
                        {
                            //SQL
                            DataTable dtinserteditem = ClassClient.PurchaseAProduct(product, Date,ParentFormClientMang.Client);

                            //Design
                            //updating originaldatable
                            DataRow InsertedRow = dtinserteditem.Rows[0];//0 since it s only one row retrieve which is the new one       
                            DataRow NewRow = ParentFormClientMang.dtClientBalanceOriginal.NewRow();
                            NewRow.ItemArray = InsertedRow.ItemArray; // Copy the data from InsertedRow to NewRow
                            ParentFormClientMang.dtClientBalanceOriginal.Rows.Add(NewRow);

                            if (ParentFormClientMang.dtClientBalanceOriginal.Rows.Count != 1)//kermel first row , bi kun already 1
                            {
                                NewRow["AutoIncrementColumn"] = Convert.ToInt32(ParentFormClientMang.dtClientBalanceOriginal.Compute("MAX(AutoIncrementColumn)", "")) + 1;

                            }
                            //shi elo aalea bel token products
                            NOProducts++;
                        }
                    }



                    ParentFormClientMang.UCTokenProducts.Detail = Convert.ToString(NOProducts + Convert.ToInt16(ParentFormClientMang.UCTokenProducts.Detail));
                    this.Close();
                }
            }
            //design in profile
       
            ParentFormClientMang.ResortOriginalDataTableAndSetDatasource();
            ParentFormClientMang.datagridviewBalanceMode();
            ParentFormClientMang.FormatDatagridviewDesign();//ejbbare ha tkun tahet datagridviewBalanceMode
            ParentFormClientMang.CalculatingTotalBalancesDesignAndSql(false);//hattayneha false, cz foe bel purchase functon aam naamil already update lal total balance
                                                                             //ejbare tahet FormatDatagridviewDesign, cz aam bi bayno el x icon bel dattagrid eza kenit abla
            ParentFormClientMang.dataGridViewBalance.FirstDisplayedScrollingRowIndex = 0;
        }//try catch



        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Opacity == 1)
            {
                timer1.Stop();
            }
            Opacity += .1;
        }
       
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BuyBundleOrProudct_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BuyBundleOrProudct_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Program.GreyForm != null)
            {
                Program.GreyForm.Close();
                Program.GreyForm = null;
            }
        }
    }
}
