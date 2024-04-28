using System;
using System.Data;
using CustomizedTools;


namespace MKproject.Management
{
    public partial class UCComboBoxFilterSearch : UCComboBoxFilterOriginal
    {
        public FilterCheckListSearch ParentFormFilter { get; set; }

        private FiltersType filterType;
        public FiltersType FilterType
        {
            get { return filterType; }
            set
            {
                filterType = value;
                SetValuesForComboBox();
            }
        }
        public enum FiltersType
        {
            Type,
            Album,
            AgeCategory,
            Gender,
            SaveDate,
            LastVisit,
            Registration,
            Balance,
            SessionLeft,
            Payment,
            SessionDone,
            PackagesRemaining

        }

        public static string All = "All";
        public static string Member = "Member", Visitor = "Visitor", NoneVisitor = "None Visitor";
        public static string Adult = "Adult", Child = "Child";
        public static string ThisMonth = "This Month", LastMonth = "Last Month", ThisYear = "This Year", LastYear = "Last Year", CustomDate = "Custom Date";
        public static string Last30Days = "Last 30 Days", Last90Days = "Last 90 Days", Last180Days = "Last 180 Days", Last365Days = "Last 365 Days";

        bool IsBeingCreated = false;//awwal ma tekhlae ma ha tfout fiya, kermel ma nkharbit el ordering

        public UCComboBoxFilterSearch()
        {
            comboBoxDetail.SelectedIndexChanged += ComboBoxDetail_SelectedIndexChanged;
        }

        private void ComboBoxDetail_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LastState != comboBoxDetail.SelectedItem.ToString())
            {
                if (IsBeingCreated)//awwal ma tekhlae ma ha tfout fiya, kermel ma nkharbit el ordering bel datagridview,only to show the values
                {
                    //hone el values already exists, so lamma nbayyin el column ha ybayno el values, bala ma yfouto bi holr
                    if (this.FilterType == FiltersType.SessionDone)//hone lamma nbayyin el column , nehna badna naabe el values aa kaba that s why fasalnehun
                    {
                        ParentFormFilter.FillSessionDoneColumn();
                    }
                    else if (this.FilterType == FiltersType.SaveDate)
                    {
                        ParentFormFilter.CreateUCCustomeDateSave();
                    }
                    else if (this.FilterType == FiltersType.LastVisit)
                    {
                        ParentFormFilter.CreateUCCustomeDateLastVisit();
                    }
                    else if (this.FilterType == FiltersType.Registration)
                    {
                        ParentFormFilter.CreateUCCustomeDateRegistration();
                    }
                    else
                    {
                        ParentFormFilter.FilterDatable();
                    }

                }
                else
                {
                    if (this.FilterType == FiltersType.SessionDone)//hone lamma nbayyin el column , nehna badna naabe el values aa kaba that s why fasalnehun
                    {
                        ParentFormFilter.FillSessionDoneColumn();
                    }
                }
            }
          
            IsBeingCreated = true;
            labelTitle.Select();
            LastState = comboBoxDetail.SelectedItem.ToString();
        }




        public void SetValuesForComboBox()
        {
            if (filterType == FiltersType.Type)
            {
                comboBoxDetail.Items.Add(All);
                comboBoxDetail.Items.Add(Member);
                comboBoxDetail.Items.Add(Visitor);
                comboBoxDetail.Items.Add(NoneVisitor);

            }

            else if (filterType == FiltersType.AgeCategory)
            {
                comboBoxDetail.Items.Add(All);
                comboBoxDetail.Items.Add(Adult);
                comboBoxDetail.Items.Add(Child);
            }

            else if (filterType == FiltersType.Gender)
            {
                comboBoxDetail.Items.Add(All);
                comboBoxDetail.Items.Add(ClassClient.ClientGender.Male.ToString());
                comboBoxDetail.Items.Add(ClassClient.ClientGender.Female.ToString());
            }
            else if (filterType == FiltersType.SaveDate)
            {
                comboBoxDetail.Items.Add(All);
                comboBoxDetail.Items.Add(ThisMonth);
                comboBoxDetail.Items.Add(LastMonth);
                comboBoxDetail.Items.Add(ThisYear);
                comboBoxDetail.Items.Add(LastYear);
                comboBoxDetail.Items.Add(CustomDate);

            }

            else if (filterType == FiltersType.LastVisit)
            {
                comboBoxDetail.Items.Add(All);
                comboBoxDetail.Items.Add(ThisMonth);
                comboBoxDetail.Items.Add(LastMonth);
                comboBoxDetail.Items.Add(ThisYear);
                comboBoxDetail.Items.Add(LastYear);
                comboBoxDetail.Items.Add(CustomDate);

            }

            else if (filterType == FiltersType.Registration)
            {
                comboBoxDetail.Items.Add(All);
                comboBoxDetail.Items.Add(ThisMonth);
                comboBoxDetail.Items.Add(LastMonth);
                comboBoxDetail.Items.Add(ThisYear);
                comboBoxDetail.Items.Add(LastYear);
                comboBoxDetail.Items.Add(CustomDate);
            }
            else if (filterType == FiltersType.SessionDone)
            {
                comboBoxDetail.Items.Add(All);
                comboBoxDetail.Items.Add(Last30Days);
                comboBoxDetail.Items.Add(Last90Days);
                comboBoxDetail.Items.Add(Last180Days);
                comboBoxDetail.Items.Add(Last365Days);
            }
            else if (filterType == FiltersType.PackagesRemaining)
            {
                comboBoxDetail.Items.Add(All);
            }
            else if (filterType == FiltersType.Album)
            {
                DataTable dtAlbums = SQLToProject.GetAlbums();
                comboBoxDetail.Items.Add(All);
                foreach (DataRow album in dtAlbums.Rows)
                {
                    comboBoxDetail.Items.Add(album["AlbumType"]);
                }
            }
            else if (filterType == FiltersType.Balance)
            {
                comboBoxDetail.Items.Add(All);
            }
            else if (filterType == FiltersType.SessionLeft)
            {
                comboBoxDetail.Items.Add(All);
            }

            else if (filterType == FiltersType.Payment)
            {
                comboBoxDetail.Items.Add(All);
            }
            else if (filterType == FiltersType.SessionDone)
            {
                comboBoxDetail.Items.Add(All);
            }

            comboBoxDetail.SelectedIndex = 0;//filter is done in here
            SetUCComboBoxWidth(this, comboBoxDetail, labelTitle);

        }//try catch


    }
}
