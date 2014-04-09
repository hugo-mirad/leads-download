using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace Leads_App
{
    class DAL
    {
        public DAL()
        {
        }

        public void SaveLead(string CustomerName, string ModelName, string ModelYear, string PhoneNumber, string Address1,
                             string Address2, string Price, string Mileage, string BodyStyle, string ExteriorStyle,
                             string InteriorStyle, string Engine, string Transmission, string DriveType, string FuelType,
                             string Doors, string StockNo, string VIN, string URL, string vehicleDesc, string carId)
        {
            try
            {

                SqlDataReader rdr = null;

                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings[Global.DBConnection].ToString();



                SqlCommand cmd = new SqlCommand("Usp_Save_Leads", con);

                cmd.CommandType = CommandType.StoredProcedure;

                string sysName = System.Environment.MachineName;

                con.Open();

                cmd.Parameters.Add(new SqlParameter("@CustomerName", CustomerName));
                cmd.Parameters.Add(new SqlParameter("@ModelName", ModelName));
                cmd.Parameters.Add(new SqlParameter("@ModelYear", ModelYear));
                cmd.Parameters.Add(new SqlParameter("@PhoneNumber", PhoneNumber));
                cmd.Parameters.Add(new SqlParameter("@Address1", Address1));
                cmd.Parameters.Add(new SqlParameter("@Address2", Address2));
                cmd.Parameters.Add(new SqlParameter("@Price", Price));
                cmd.Parameters.Add(new SqlParameter("@Mileage", Mileage));
                cmd.Parameters.Add(new SqlParameter("@BodyStyle", BodyStyle));
                cmd.Parameters.Add(new SqlParameter("@ExteriorStyle", ExteriorStyle));
                cmd.Parameters.Add(new SqlParameter("@InteriorStyle", InteriorStyle));
                cmd.Parameters.Add(new SqlParameter("@Engine", Engine));
                cmd.Parameters.Add(new SqlParameter("@Transmission", Transmission));
                cmd.Parameters.Add(new SqlParameter("@DriveType", DriveType));
                cmd.Parameters.Add(new SqlParameter("@FuelType", FuelType));
                cmd.Parameters.Add(new SqlParameter("@Doors", Doors));
                cmd.Parameters.Add(new SqlParameter("@StockNo", StockNo));
                cmd.Parameters.Add(new SqlParameter("@VIN", VIN));
                cmd.Parameters.Add(new SqlParameter("@URL", URL));
                cmd.Parameters.Add(new SqlParameter("@vehicleDesc", vehicleDesc));
                cmd.Parameters.Add(new SqlParameter("@CarId", carId));
                cmd.Parameters.Add(new SqlParameter("@sysName", sysName));

                cmd.ExecuteNonQuery();

                con.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveLead_Craigslist(string Price, string Model, string Description, string Url, string sPosting,
                                        string CollectedFromState, string PhoneNo, int StaeId, string State_Name, string CusEmailId)
        {
            DataSet ds = new DataSet();
            try
            {

                SqlDataReader rdr = null;

                SqlConnection con = new SqlConnection();

                //added code
                // Global.DBConnection = "DBCarsTest1";
                //above
                con.ConnectionString = ConfigurationManager.ConnectionStrings["DBCars"].ToString();


                string sysName = System.Environment.MachineName;
                SqlCommand cmd = new SqlCommand("Usp_Save_Leads_craigslist", con);
                // Usp_Save_Leads_craigslist
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();

                cmd.CommandTimeout = 5000;

                cmd.Parameters.Add(new SqlParameter("@Price", Price));
                cmd.Parameters.Add(new SqlParameter("@Model", Model));
                cmd.Parameters.Add(new SqlParameter("@Description", Description));
                cmd.Parameters.Add(new SqlParameter("@Url", Url));
                cmd.Parameters.Add(new SqlParameter("@PostingId", sPosting));
                cmd.Parameters.Add(new SqlParameter("@CollectedFromState", CollectedFromState));
                cmd.Parameters.Add(new SqlParameter("@PhoneNo", PhoneNo));
                cmd.Parameters.Add(new SqlParameter("@StaeId", StaeId));
                cmd.Parameters.Add(new SqlParameter("@State_Name", State_Name));
                cmd.Parameters.Add(new SqlParameter("@sysName", sysName));
                cmd.Parameters.Add(new SqlParameter("@CusEmailId", CusEmailId));
                //cmd.Parameters.Add(new SqlParameter("@StateCode", StateCode));

                cmd.ExecuteNonQuery();

                con.Close();


                //cmd.ExecuteNonQuery();

                //con.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            //return ds; 
        }

        public void SaveTransaction_Cars(string stateName, string cityName, string StartStatus, string EndStatus)
        {
            try
            {
                SqlDataReader rdr = null;
                SqlConnection con = new SqlConnection();
                //Added

                //code
                con.ConnectionString = ConfigurationManager.ConnectionStrings["DBCars"].ToString();
                SqlCommand cmd = new SqlCommand("usp_save_tran_Craiglist_new", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.Add(new SqlParameter("@statename", stateName));
                cmd.Parameters.Add(new SqlParameter("@cityname", cityName));
                cmd.Parameters.Add(new SqlParameter("@StartStatus", StartStatus));
                cmd.Parameters.Add(new SqlParameter("@EndStatus  ", EndStatus));
                //cmd.Parameters.Add(new SqlParameter("@state  ", state));
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet SaveLead_CraigslistDealers(string Price, string Model, string Description, string Url, string sPosting,
                                                  string CollectedFromState, string PhoneNo, int StaeId, string State_Name, string CusEmailId)
        {
            DataSet ds = new DataSet();
            // try
            // {

            SqlDataReader rdr = null;

            SqlConnection con = new SqlConnection();

            con.ConnectionString = ConfigurationManager.ConnectionStrings[Global.DBConnection].ToString();


            string sysName = System.Environment.MachineName;
            SqlCommand cmd = new SqlCommand("Usp_Save_Leads_Dealercraigslist", con);

            cmd.CommandType = CommandType.StoredProcedure;

            con.Open();

            cmd.CommandTimeout = 5000;

            cmd.Parameters.Add(new SqlParameter("@Price", Price));
            cmd.Parameters.Add(new SqlParameter("@Model", Model));
            cmd.Parameters.Add(new SqlParameter("@Description", Description));
            cmd.Parameters.Add(new SqlParameter("@Url", Url));
            cmd.Parameters.Add(new SqlParameter("@PostingId", sPosting));
            cmd.Parameters.Add(new SqlParameter("@CollectedFromState", CollectedFromState));
            cmd.Parameters.Add(new SqlParameter("@PhoneNo", PhoneNo));
            cmd.Parameters.Add(new SqlParameter("@StaeId", StaeId));
            cmd.Parameters.Add(new SqlParameter("@State_Name", State_Name));
            cmd.Parameters.Add(new SqlParameter("@sysName", sysName));
            cmd.Parameters.Add(new SqlParameter("@CusEmailId", CusEmailId));

            SqlDataAdapter das = new SqlDataAdapter();

            das.SelectCommand = cmd;

            das.Fill(ds);


            //cmd.ExecuteNonQuery();

            //con.Close();

            //}
            // catch (Exception ex)
            // {
            // throw ex;
            // }
            return ds;
        }

        public void SaveLead_Craigslist_RVS(string Price, string Model, string Description, string Url, string sPosting,
                                            string CollectedFromState, string PhoneNo, int StaeId, string State_Name, string CusEmailId)
        {
            try
            {

                SqlDataReader rdr = null;

                SqlConnection con = new SqlConnection();

                con.ConnectionString = ConfigurationManager.ConnectionStrings[Global.DBConnection].ToString();


                string sysName = System.Environment.MachineName;
                SqlCommand cmd = new SqlCommand("[Usp_Save_Leads_craigslist_RVS]", con);

                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                cmd.CommandTimeout = 5000;
                cmd.Parameters.Add(new SqlParameter("@Price", Price));
                cmd.Parameters.Add(new SqlParameter("@Model", Model));
                cmd.Parameters.Add(new SqlParameter("@Description", Description));
                cmd.Parameters.Add(new SqlParameter("@Url", Url));
                cmd.Parameters.Add(new SqlParameter("@PostingId", sPosting));
                cmd.Parameters.Add(new SqlParameter("@CollectedFromState", CollectedFromState));
                cmd.Parameters.Add(new SqlParameter("@PhoneNo", PhoneNo));
                cmd.Parameters.Add(new SqlParameter("@StaeId", StaeId));
                cmd.Parameters.Add(new SqlParameter("@State_Name", State_Name));

                cmd.Parameters.Add(new SqlParameter("@sysName", sysName));
                cmd.Parameters.Add(new SqlParameter("@CusEmailId", CusEmailId));


                cmd.ExecuteNonQuery();

                con.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveLead_Craigslist_bikes(string Price, string Model, string Description, string Url, string sPosting,
                                              string CollectedFromState, string PhoneNo, int StaeId, string State_Name, string CusEmailId)
        {
            try
            {

                SqlDataReader rdr = null;

                SqlConnection con = new SqlConnection();

                con.ConnectionString = ConfigurationManager.ConnectionStrings["DBBikes"].ToString();


                string sysName = System.Environment.MachineName;
                SqlCommand cmd = new SqlCommand("[Usp_Save_Leads_craigslist_Bikes]", con);

                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                cmd.CommandTimeout = 5000;
                cmd.Parameters.Add(new SqlParameter("@Price", Price));
                cmd.Parameters.Add(new SqlParameter("@Model", Model));
                cmd.Parameters.Add(new SqlParameter("@Description", Description));
                cmd.Parameters.Add(new SqlParameter("@Url", Url));
                cmd.Parameters.Add(new SqlParameter("@PostingId", sPosting));
                cmd.Parameters.Add(new SqlParameter("@CollectedFromState", CollectedFromState));
                cmd.Parameters.Add(new SqlParameter("@PhoneNo", PhoneNo));
                cmd.Parameters.Add(new SqlParameter("@StaeId", StaeId));
                cmd.Parameters.Add(new SqlParameter("@State_Name", State_Name));

                cmd.Parameters.Add(new SqlParameter("@sysName", sysName));
                cmd.Parameters.Add(new SqlParameter("@CusEmailId", CusEmailId));


                cmd.ExecuteNonQuery();

                con.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetCities(int State_id)
        {
            SqlDataReader rdr = null;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection();

            SqlDataAdapter das = new SqlDataAdapter();

            con.ConnectionString = ConfigurationManager.ConnectionStrings["DBCars"].ToString();


            SqlCommand cmd = new SqlCommand("USP_GET_CITIES", con);

            cmd.CommandType = CommandType.StoredProcedure;

            con.Open();

            cmd.Parameters.Add(new SqlParameter("@State_id", State_id));

            das.SelectCommand = cmd;

            das.Fill(ds);

            return ds;


            //SqlDataAdapter daAuthors    = new SqlDataAdapter("Select * From Authors", objConn);

            //// Create an instance of a DataSet, and retrieve data from the Authors table.
            //DataSet dsPubs = new DataSet("Pubs");
            //daAuthors.FillSchema(dsPubs, SchemaType.Source, "Authors");
            //daAuthors.Fill(dsPubs, "Authors");
            //con.Close();
        }

        public DataSet GetStates()
        {
            SqlDataReader rdr = null;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection();

            SqlDataAdapter das = new SqlDataAdapter();

            con.ConnectionString = ConfigurationManager.ConnectionStrings[Global.DBConnection].ToString();


            SqlCommand cmd = new SqlCommand("USP_GET_STATES", con);

            cmd.CommandType = CommandType.StoredProcedure;

            con.Open();

            das.SelectCommand = cmd;

            das.Fill(ds);


            return ds;


            //SqlDataAdapter daAuthors    = new SqlDataAdapter("Select * From Authors", objConn);

            //// Create an instance of a DataSet, and retrieve data from the Authors table.
            //DataSet dsPubs = new DataSet("Pubs");
            //daAuthors.FillSchema(dsPubs, SchemaType.Source, "Authors");
            //daAuthors.Fill(dsPubs, "Authors");
            //con.Close();
        }

        public DataSet GET_STATES_Craiglistcars()
        {
            SqlDataReader rdr = null;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection();
            SqlDataAdapter das = new SqlDataAdapter();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["DBCars"].ToString();//Global.DBConnection
            SqlCommand cmd = new SqlCommand("USP_GET_STATES_Craiglistcars", con);
            cmd.CommandType = CommandType.StoredProcedure;
             con.Open();
            das.SelectCommand = cmd;
            das.Fill(ds);
            return ds;
            //SqlDataAdapter daAuthors    = new SqlDataAdapter("Select * From Authors", objConn);

            //// Create an instance of a DataSet, and retrieve data from the Authors table.
            //DataSet dsPubs = new DataSet("Pubs");
            //daAuthors.FillSchema(dsPubs, SchemaType.Source, "Authors");
            //daAuthors.Fill(dsPubs, "Authors");
            //con.Close();
        }

        public DataSet GET_STATES_Craiglistcars(int stateid)
        {

            SqlDataReader rdr = null;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection();

            SqlDataAdapter das = new SqlDataAdapter();

            con.ConnectionString = ConfigurationManager.ConnectionStrings[Global.DBConnection].ToString();


            SqlCommand cmd = new SqlCommand("USP_GET_STATES_CraiglistcarsNew", con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@stateid", stateid);

            con.Open();

            das.SelectCommand = cmd;

            das.Fill(ds);


            return ds;




            //SqlDataAdapter daAuthors    = new SqlDataAdapter("Select * From Authors", objConn);

            //// Create an instance of a DataSet, and retrieve data from the Authors table.
            //DataSet dsPubs = new DataSet("Pubs");
            //daAuthors.FillSchema(dsPubs, SchemaType.Source, "Authors");
            //daAuthors.Fill(dsPubs, "Authors");
            //con.Close();
        }

        public DataSet GetStates_CarsSite()
        {
            SqlDataReader rdr = null;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection();

            SqlDataAdapter das = new SqlDataAdapter();

            con.ConnectionString = ConfigurationManager.ConnectionStrings[Global.DBConnection].ToString();


            SqlCommand cmd = new SqlCommand("Get_States_Cars_Test", con);

            cmd.CommandType = CommandType.StoredProcedure;

            con.Open();

            das.SelectCommand = cmd;

            das.Fill(ds);


            return ds;

        }

        public DataSet GetZip_ByState_FromCarsSite(int ZipId)
        {
            SqlDataReader rdr = null;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection();

            SqlDataAdapter das = new SqlDataAdapter();

            con.ConnectionString = ConfigurationManager.ConnectionStrings[Global.DBConnection].ToString();


            SqlCommand cmd = new SqlCommand("Get_Zip_ByState_Test", con);

            cmd.CommandType = CommandType.StoredProcedure;

            con.Open();

            cmd.Parameters.Add(new SqlParameter("@ZipId", ZipId));

            das.SelectCommand = cmd;

            das.Fill(ds);


            return ds;


        }

        public void SaveLead_CarsSite(string Phone, string SellerName, string Price, string Model, string Description,
                                      string Mileage, string Url, string StateorCity, string CarId, string zip)
        {
            try
            {

                SqlDataReader rdr = null;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings[Global.DBConnection].ToString();
                string sysName = System.Environment.MachineName;
                SqlCommand cmd = new SqlCommand("usp_save_Car_Leads", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.Add(new SqlParameter("@Phone", Phone));
                cmd.Parameters.Add(new SqlParameter("@SellerName", SellerName));
                cmd.Parameters.Add(new SqlParameter("@Price", Price));
                cmd.Parameters.Add(new SqlParameter("@Model", Model));
                cmd.Parameters.Add(new SqlParameter("@Description", Description));
                cmd.Parameters.Add(new SqlParameter("@Mileage", Mileage));
                cmd.Parameters.Add(new SqlParameter("@Url", Url));
                cmd.Parameters.Add(new SqlParameter("@StateorCity", StateorCity));
                cmd.Parameters.Add(new SqlParameter("@CarId", CarId));
                cmd.Parameters.Add(new SqlParameter("@zip", zip));
                cmd.Parameters.Add(new SqlParameter("@sysName", sysName));
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveLead_CarsSite(string Phone, string SellerName, string Price, string Model,string leadissued,
                                      string Description, string Mileage, string Url, string StateorCity, string CarId, string zip)
        {
            try
            {

                SqlDataReader rdr = null;

                SqlConnection con = new SqlConnection();

                con.ConnectionString = ConfigurationManager.ConnectionStrings[Global.DBConnection].ToString();


                string sysName = System.Environment.MachineName;

                SqlCommand cmd = new SqlCommand("usp_save_Car_LeadsNew_Test", con);

                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();

                cmd.Parameters.Add(new SqlParameter("@Phone", Phone));
                cmd.Parameters.Add(new SqlParameter("@SellerName", SellerName));
                cmd.Parameters.Add(new SqlParameter("@Price", Price));
                cmd.Parameters.Add(new SqlParameter("@Model", Model));
                cmd.Parameters.Add(new SqlParameter("@Description", Description));
                cmd.Parameters.Add(new SqlParameter("@Mileage", Mileage));
                cmd.Parameters.Add(new SqlParameter("@Url", Url));
                cmd.Parameters.Add(new SqlParameter("@StateorCity", StateorCity));
                cmd.Parameters.Add(new SqlParameter("@CarId", CarId));
                cmd.Parameters.Add(new SqlParameter("@zip", zip));
                cmd.Parameters.Add(new SqlParameter("@sysName", sysName));
                cmd.Parameters.Add(new SqlParameter("@leadissued", leadissued));

                cmd.ExecuteNonQuery();

                con.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveLead_Autotrades_CA(string PhoneNo, string Price, string ModelYear, string Description, string State,
                                           string Url, string carId)
        {
            try
            {

                SqlDataReader rdr = null;

                SqlConnection con = new SqlConnection();

                con.ConnectionString = ConfigurationManager.ConnectionStrings[Global.DBConnection].ToString();

                string sysName = System.Environment.MachineName;

                SqlCommand cmd = new SqlCommand("USP_SaveAutoTrades_CA", con);

                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();

                cmd.Parameters.Add(new SqlParameter("@PhoneNo", PhoneNo));
                cmd.Parameters.Add(new SqlParameter("@Price", Price));
                cmd.Parameters.Add(new SqlParameter("@ModelYear", ModelYear));
                cmd.Parameters.Add(new SqlParameter("@Description", Description));
                cmd.Parameters.Add(new SqlParameter("@State ", State));
                cmd.Parameters.Add(new SqlParameter("@Url", Url));
                cmd.Parameters.Add(new SqlParameter("@carId", carId));
                cmd.Parameters.Add(new SqlParameter("@sysName", sysName));




                cmd.ExecuteNonQuery();

                con.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet AllSalesFromCarsDB()
        {
            SqlDataReader rdr = null;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection();

            SqlDataAdapter das = new SqlDataAdapter();

            con.ConnectionString = ConfigurationManager.ConnectionStrings["CarsDBNew"].ToString();


            SqlCommand cmd = new SqlCommand("GET_ALL_SALES_CARLEADS", con);

            cmd.CommandType = CommandType.StoredProcedure;

            con.Open();

            das.SelectCommand = cmd;

            das.Fill(ds);


            return ds;


            //SqlDataAdapter daAuthors    = new SqlDataAdapter("Select * From Authors", objConn);

            //// Create an instance of a DataSet, and retrieve data from the Authors table.
            //DataSet dsPubs = new DataSet("Pubs");
            //daAuthors.FillSchema(dsPubs, SchemaType.Source, "Authors");
            //daAuthors.Fill(dsPubs, "Authors");
            //con.Close();
        }

        public DataSet GetSalesTodayProcess(string TodayDate)
        {
            SqlDataReader rdr = null;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection();

            SqlDataAdapter das = new SqlDataAdapter();

            con.ConnectionString = ConfigurationManager.ConnectionStrings[Global.DBConnection].ToString();


            SqlCommand cmd = new SqlCommand("get_leads_CollectedToday", con);

            cmd.CommandType = CommandType.StoredProcedure;

            con.Open();

            cmd.Parameters.Add(new SqlParameter("@Date", TodayDate));

            das.SelectCommand = cmd;

            das.Fill(ds);

            return ds;


            //SqlDataAdapter daAuthors    = new SqlDataAdapter("Select * From Authors", objConn);

            //// Create an instance of a DataSet, and retrieve data from the Authors table.
            //DataSet dsPubs = new DataSet("Pubs");
            //daAuthors.FillSchema(dsPubs, SchemaType.Source, "Authors");
            //daAuthors.Fill(dsPubs, "Authors");
            //con.Close();
        }

        public DataSet GetSalesTodayProcess_RVsCraiglist(string TodayDate)
        {
            SqlDataReader rdr = null;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection();

            SqlDataAdapter das = new SqlDataAdapter();

            con.ConnectionString = ConfigurationManager.ConnectionStrings[Global.DBConnection].ToString();


            SqlCommand cmd = new SqlCommand("get_leads_CollectedToday_RVsCraiglist", con);

            cmd.CommandType = CommandType.StoredProcedure;

            con.Open();

            cmd.Parameters.Add(new SqlParameter("@Date", TodayDate));

            das.SelectCommand = cmd;

            das.Fill(ds);

            return ds;


            //SqlDataAdapter daAuthors    = new SqlDataAdapter("Select * From Authors", objConn);

            //// Create an instance of a DataSet, and retrieve data from the Authors table.
            //DataSet dsPubs = new DataSet("Pubs");
            //daAuthors.FillSchema(dsPubs, SchemaType.Source, "Authors");
            //daAuthors.Fill(dsPubs, "Authors");
            //con.Close();
        }

        public DataSet GetCity_ByState_Craiglist(int StateID)
        {
            SqlDataReader rdr = null;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection();

            SqlDataAdapter das = new SqlDataAdapter();

            con.ConnectionString = ConfigurationManager.ConnectionStrings[Global.DBConnection].ToString();


            SqlCommand cmd = new SqlCommand("USP_GET_CITIES_CraiglistCars", con);

            cmd.CommandType = CommandType.StoredProcedure;

            con.Open();

            cmd.Parameters.Add(new SqlParameter("@STATEID", StateID));

            das.SelectCommand = cmd;

            das.Fill(ds);


            return ds;


            //SqlDataAdapter daAuthors    = new SqlDataAdapter("Select * From Authors", objConn);

            //// Create an instance of a DataSet, and retrieve data from the Authors table.
            //DataSet dsPubs = new DataSet("Pubs");
            //daAuthors.FillSchema(dsPubs, SchemaType.Source, "Authors");
            //daAuthors.Fill(dsPubs, "Authors");
            //con.Close();
        }

        public void SaveTransaction_Cars(int StateId, string StartStatus, string EndStatus)
        {
            try
            {
               SqlDataReader rdr = null;
                SqlConnection con = new SqlConnection();
                //Added
                //code
                con.ConnectionString = ConfigurationManager.ConnectionStrings[Global.DBConnection].ToString();
                SqlCommand cmd = new SqlCommand("usp_save_tran_Craiglist", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.Add(new SqlParameter("@stateid", StateId));
                cmd.Parameters.Add(new SqlParameter("@StartStatus", StartStatus));
                cmd.Parameters.Add(new SqlParameter("@EndStatus  ", EndStatus));
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void del_history(string query)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings[Global.DBConnection].ToString();
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
        }

        public void SaveTransaction_Cars(string statename, string zipcode, int startstatus, int endstatus, string state)
        {
            try
            {
                SqlDataReader rdr = null;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings[Global.DBConnection].ToString();
                SqlCommand cmd = new SqlCommand("usp_save_tran_cars", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.Add(new SqlParameter("@statename", statename));
                cmd.Parameters.Add(new SqlParameter("@zipcode", zipcode));
                cmd.Parameters.Add(new SqlParameter("@startstatus", startstatus));
                cmd.Parameters.Add(new SqlParameter("@endstatus", endstatus));
                cmd.Parameters.Add(new SqlParameter("@state", state));
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetCities_CarsSite(string state)
        {
            SqlDataReader rdr = null;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection();
            SqlDataAdapter das = new SqlDataAdapter();
            con.ConnectionString = ConfigurationManager.ConnectionStrings[Global.DBConnection].ToString();
            SqlCommand cmd = new SqlCommand("usp_getCities_CarsSite", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.Add(new SqlParameter("@STATE", state));
            das.SelectCommand = cmd;
            das.Fill(ds);
            return ds;
        }

        #region carpost
        public void SaveLead_CarPost(string title1, string title2, string title3, string title4, string title5, string title6, string title7, 
            string title8, string title9,string title11,string title12,string phone,string zip,string url,string state,string city)
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings[Global.DBConnection].ToString();
                string sysName = System.Environment.MachineName;
                SqlCommand cmd = new SqlCommand("usp_save_CarPost_Leads", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                //title price  mileage  extcolor doors engine  trans fuel drive description sellername phone zip url
                cmd.Parameters.Add(new SqlParameter("@title", title1));
                cmd.Parameters.Add(new SqlParameter("@price", title2));
                cmd.Parameters.Add(new SqlParameter("@mileage", title3));
                cmd.Parameters.Add(new SqlParameter("@extcolor", title4));
                cmd.Parameters.Add(new SqlParameter("@doors", title5));
                cmd.Parameters.Add(new SqlParameter("@engine", title6));
                cmd.Parameters.Add(new SqlParameter("@trans", title7));
                cmd.Parameters.Add(new SqlParameter("@fuel", title8));
                cmd.Parameters.Add(new SqlParameter("@drive", title9));
                cmd.Parameters.Add(new SqlParameter("@description", title11));
                cmd.Parameters.Add(new SqlParameter("@phone", phone));
                cmd.Parameters.Add(new SqlParameter("@sellername", title12));
                cmd.Parameters.Add(new SqlParameter("@zip", zip));
                cmd.Parameters.Add(new SqlParameter("@url", url));
                cmd.Parameters.Add(new SqlParameter("@state", state));
                cmd.Parameters.Add(new SqlParameter("@city", city));
                cmd.Parameters.Add(new SqlParameter("@sysname", sysName));

                cmd.ExecuteNonQuery();

                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); 
                //throw ex;
            }
        }
        public DataSet GetZip_CarPost()
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection();
            SqlDataAdapter das = new SqlDataAdapter();
            con.ConnectionString = ConfigurationManager.ConnectionStrings[Global.DBConnection].ToString();
            SqlCommand cmd = new SqlCommand("Get_Zip_CarPost", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            das.SelectCommand = cmd;
            das.Fill(ds);
            return ds;
        }
        public DataSet GetStates_CarPost()
        {
            SqlDataReader rdr = null;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection();

            SqlDataAdapter das = new SqlDataAdapter();

            con.ConnectionString = ConfigurationManager.ConnectionStrings[Global.DBConnection].ToString();


            SqlCommand cmd = new SqlCommand("Get_States_CarPost", con);

            cmd.CommandType = CommandType.StoredProcedure;

            con.Open();

            das.SelectCommand = cmd;

            das.Fill(ds);


            return ds;

        }
        public void SaveTransaction_CarPost(string statename, string zipcode, int startstatus, int endstatus, string state)
        {
            try
            {
                SqlDataReader rdr = null;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings[Global.DBConnection].ToString();
                SqlCommand cmd = new SqlCommand("usp_save_tran_carpost", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.Add(new SqlParameter("@statename", statename));
                cmd.Parameters.Add(new SqlParameter("@zipcode", zipcode));
                cmd.Parameters.Add(new SqlParameter("@startstatus", startstatus));
                cmd.Parameters.Add(new SqlParameter("@endstatus", endstatus));
                cmd.Parameters.Add(new SqlParameter("@state", state));
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetCities_CarPost(string state)
        {
            SqlDataReader rdr = null;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection();
            SqlDataAdapter das = new SqlDataAdapter();
            con.ConnectionString = ConfigurationManager.ConnectionStrings[Global.DBConnection].ToString();
            SqlCommand cmd = new SqlCommand("usp_getCities_CarPost", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.Add(new SqlParameter("@STATE", state));
            das.SelectCommand = cmd;
            das.Fill(ds);
            return ds;
        }
        public void saveTran_CarPost(string zipcode, int startstatus, int endstatus)
        {
            try
            {

                SqlDataReader rdr = null;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings[Global.DBConnection].ToString();
                SqlCommand cmd = new SqlCommand("usp_saveTran_CarPost", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                
                cmd.Parameters.Add(new SqlParameter("@zipcode", zipcode));
                cmd.Parameters.Add(new SqlParameter("@startstatus", startstatus));
                cmd.Parameters.Add(new SqlParameter("@endstatus", endstatus));
               
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region ClassifiedsValley
        public void SaveLead_ClassifiedsValley(string title, string city, string state,string sname,string price,
            string desc, string PhoneNumber, string url)
        {
            Global.DBConnection = "DBCars";
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings[Global.DBConnection].ToString();
                string sysName = System.Environment.MachineName;
                SqlCommand cmd = new SqlCommand("Usp_Save_Leads_ClassifiedsValley", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                //title price  mileage  extcolor doors engine  trans fuel drive description sellername phone zip url
                cmd.Parameters.Add(new SqlParameter("@title", title));
                cmd.Parameters.Add(new SqlParameter("@sname", sname));
                cmd.Parameters.Add(new SqlParameter("@state", state));
                cmd.Parameters.Add(new SqlParameter("@city", city));
                cmd.Parameters.Add(new SqlParameter("@price", price));
                cmd.Parameters.Add(new SqlParameter("@PhoneNumber", PhoneNumber));
                cmd.Parameters.Add(new SqlParameter("@url", url));
                cmd.Parameters.Add(new SqlParameter("@desc", desc));
                cmd.Parameters.Add(new SqlParameter("@sysname", sysName));


                cmd.ExecuteNonQuery();

                con.Close();

            }
            catch (Exception ex)
            {
                //throw ex;
            }
        }
        #endregion
        #region ClassifiedsCiti 
        //title,desc,location,place,name,phno,price,url
        public void SaveLead_ClassifiedsCiti(string title, string desc, string location, string state,string city, string name,
            string phno, string price, string url)
        {
            Global.DBConnection = "DBCars";
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings[Global.DBConnection].ToString();
                string sysName = System.Environment.MachineName;
                SqlCommand cmd = new SqlCommand("Usp_Save_Leads_ClassifiedsCiti", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                //title,desc,location,place,name,phno,price,url
                cmd.Parameters.Add(new SqlParameter("@title", title));
                cmd.Parameters.Add(new SqlParameter("@sname", name));
                cmd.Parameters.Add(new SqlParameter("@location", location));
                cmd.Parameters.Add(new SqlParameter("@state", state));
                cmd.Parameters.Add(new SqlParameter("@city", city));
                cmd.Parameters.Add(new SqlParameter("@price", price));
                cmd.Parameters.Add(new SqlParameter("@phno", phno));
                cmd.Parameters.Add(new SqlParameter("@url", url));
                cmd.Parameters.Add(new SqlParameter("@desc", desc));
                cmd.Parameters.Add(new SqlParameter("@sysname", sysName));


                cmd.ExecuteNonQuery();

                con.Close();

            }
            catch (Exception ex)
            {
                //throw ex;
            }
        }
        #endregion
        public void SaveLeadsData(string PostingId, string CarId, string Title, string PhoneNo, string Price, string Url, string sellername,
            string State_Name, string City, string Address, string Zip, string Mileage, string State_ID,
            string Description, string Model, string Extcolor, string Doors,
            string Engine, string Trans, string Fuel, string Drive, string CusEmailId)
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["DBCars"].ToString();
                string sysName = System.Environment.MachineName;
                SqlCommand cmd = new SqlCommand("USP_SAVE_LEADSDATA", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.Add(new SqlParameter("@PostingId", PostingId));
                cmd.Parameters.Add(new SqlParameter("@CarId", CarId));
                cmd.Parameters.Add(new SqlParameter("@Title", Title));
                cmd.Parameters.Add(new SqlParameter("@PhoneNo", PhoneNo));
                cmd.Parameters.Add(new SqlParameter("@Price", Price));
                cmd.Parameters.Add(new SqlParameter("@Url", Url));
                cmd.Parameters.Add(new SqlParameter("@sellername", sellername));
                cmd.Parameters.Add(new SqlParameter("@State_Name", State_Name));
                cmd.Parameters.Add(new SqlParameter("@City", City));
                cmd.Parameters.Add(new SqlParameter("@Address", Address));
                cmd.Parameters.Add(new SqlParameter("@Zip", Zip));
                cmd.Parameters.Add(new SqlParameter("@Mileage", Mileage));
                cmd.Parameters.Add(new SqlParameter("@State_ID", State_ID));
                cmd.Parameters.Add(new SqlParameter("@Description", Description));
                cmd.Parameters.Add(new SqlParameter("@Model", Model));
                cmd.Parameters.Add(new SqlParameter("@Extcolor", Extcolor));
                cmd.Parameters.Add(new SqlParameter("@Doors", Doors));
                cmd.Parameters.Add(new SqlParameter("@Engine", Engine));
                cmd.Parameters.Add(new SqlParameter("@Trans", Trans));
                cmd.Parameters.Add(new SqlParameter("@Fuel", Fuel));
                cmd.Parameters.Add(new SqlParameter("@Drive", Drive));
                cmd.Parameters.Add(new SqlParameter("@CusEmailId", CusEmailId));
                cmd.Parameters.Add(new SqlParameter("@sysname", sysName));
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                //throw ex;
            }
        }
    }
}
