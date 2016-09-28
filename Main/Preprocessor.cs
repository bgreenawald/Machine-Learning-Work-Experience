using System;
using System.Collections.Generic;
using Deedle;

namespace Membership_Application
{
    public class Preprocessor
    {

        //------------------------------------------------------------------------------------------------------------------------------------------------------------------//

        //Fields

        //Columns that we would like to remove
        private readonly List<string> badCols = new List<string>
                { "PERSON_ID", "APP_TYPE", "STATUS", "STARTDATE", "ENDDATE", "APPROVED_MONTHS", "QUALIFIED_FLG", "X_EMPLOYER_NAME", "JOB_CATEGOY"};

        //Raw data set 
        private Frame<int, string> data_full;

        //Data set after filtering operations
        private Frame<int, string> data_filtered;
        private Frame<int, string> data_extra;
        public int progress = 1;

        //------------------------------------------------------------------------------------------------------------------------------------------------------------------//

        //Constructors
        static Preprocessor() { }

        public Preprocessor(string path) {
            this.data_full = Frame.ReadCsv(path);
            progress = 2;
            filterColumns();
            progress = 3;
            filterRows();
            progress = 4;
        }

 
        public Preprocessor(string path, ref int progress)
        {
            this.data_full = Frame.ReadCsv(path);
            progress = 2;
            filterColumns();
            progress = 3;
            filterRows();
            progress = 4;
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------//

        //Methods

        //Removes the columns from the data that we do not want
        public void filterColumns()
        {
            foreach(string col in badCols)
            {
                this.data_full.DropColumn(col);
            }
        }

        public void filterRows()
        {
            
            this.data_filtered = Frame.FromRows(data_full.Rows.Where(kvp => ((kvp.Value.GetAs<string>("APPROVAL_STATUS").Trim() == "Approved"
                 || kvp.Value.GetAs<string>("APPROVAL_STATUS").Trim() == "Rejected") && kvp.Value.GetAs<string>("MEM_TYPE").Trim() == "Regular")
                 && kvp.Value.GetAs<string>("JOB_DESCRIPTION").Trim() != "#NAME?" ));

            this.data_filtered = Frame.FromRows(this.data_filtered.Rows.Where(kvp => kvp.Value.GetAs<DateTime>("CREATED").Year > 2011));
            this.data_filtered = Frame.FromRows(this.data_filtered.Rows.Where(kvp => kvp.Key < 50000));
            this.data_extra = Frame.FromRows(this.data_full.Rows.Where(kvp => kvp.Key >= 50000));



        }

        //Returns the data
        public Frame<int, string> getDataFull()
        {
            return this.data_full; 
        }

        public Frame<int, string> getDataFiltered()
        {
            return this.data_filtered;
        }

       public Frame<int, string> getDataExtra()
        {
            return this.data_extra;
        }
    }
}
