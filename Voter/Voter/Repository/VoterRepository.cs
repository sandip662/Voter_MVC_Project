using System.Data;
using Voter.Interfaces;
using Voter.Models;
using Voter.Utility;

namespace Voter.Repository
{
    public class VoterRepository:IVOTERRepository
    {
        IConfiguration _configuration;
        DbAccess _DbAccess;

        public VoterRepository(IConfiguration configuration)
        {

            _configuration = configuration;
            _DbAccess = new DbAccess(_configuration);
        }

        

        public List<VoterModel> GetVote(int VOTER_KEY)
        {
            try
            {
                string[] ParametersNames = { "@VOTER_KEY" };
                string[] ParametersValues = { VOTER_KEY.ToString() };

                DataSet dataSet = _DbAccess.Ds_Process("SP_GET_VOTER_DB", ParametersNames, ParametersValues);
                List<VoterModel> lst = new List<VoterModel>();
                if (dataSet.Tables.Count > 0)
                {

                    DataTable dt = dataSet.Tables[0];

                    if (dt.Rows.Count > 0)
                    {

                        foreach (DataRow row in dt.Rows)
                        {
                            var obj = new VoterModel();
                            obj.VOTER_KEY = Convert.ToInt32(row["VOTER_KEY"]);
                            obj.NAME = Convert.ToString(row["NAME"]);
                            obj.AGE = Convert.ToInt32(row["AGE"]);
                            obj.GENDER_ID = Convert.ToInt32(row["GENDER_ID"]);
                            obj.GENDER_NAME = Convert.ToString(row["GENDER_NAME"]);
                            obj.STATE_ID = Convert.ToInt32(row["STATE_ID"]);
                            obj.STATE_NAME = Convert.ToString(row["STATE_NAME"]);
                            obj.VOTERCARD_NO = Convert.ToString(row["VOTERCARD_NO"]);
                            lst.Add(obj);

                        }
                    }
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        public int SaveVote(VoterModel model, string REC_TYPE)
        {
            try
            {

                string[] vname = { "@REC_TYPE", "@VOTER_KEY", "@NAME", "@AGE", "@GENDER_ID", "@STATE_ID", "VOTERCARD_NO" };

                string[] vvalue = { REC_TYPE, model.VOTER_KEY.ToString(), model.NAME, model.AGE.ToString(), model.GENDER_ID.ToString(), model.STATE_ID.ToString(), model.VOTERCARD_NO };
                int result = _DbAccess.int_Process("SP_CRUD_VOTER_DB", vname, vvalue);
                    if (result > 0)
                {

                    return result;
                }
                else
                {
                    return result;
                }



            }
            catch (Exception ex)
            {
                throw;
            }


        }





        public int DeleteVote(VoterModel model, string REC_TYPE)
        {
            try
            {

                string[] vname = { "@REC_TYPE", "@VOTER_KEY", "@NAME", "@AGE", "@GENDER_ID", "@STATE_ID", "VOTERCARD_NO" };
                string[] vvalue = { REC_TYPE, model.VOTER_KEY.ToString(), "", "", "", "", "" };
                int result = _DbAccess.int_Process("SP_CRUD_VOTER_DB", vname, vvalue);
                if (result > 0)
                {

                    return result;
                }
                else
                {
                    return result;
                }



            }
            catch (Exception ex)
            {

                throw;
            }
        }






        public List<VoterModel> getState(int STATE_ID)
        {
            try
            {
                string[] ParametersNames = { "@STATE_ID" };
                string[] ParametersValues = { STATE_ID.ToString() };

                DataSet dataSet = _DbAccess.Ds_Process("SP_GET_STATE", ParametersNames, ParametersValues);
                List<VoterModel> lst = new List<VoterModel>();
                if (dataSet.Tables.Count > 0)
                {

                    DataTable dt = dataSet.Tables[0];

                    if (dt.Rows.Count > 0)
                    {

                        foreach (DataRow row in dt.Rows)
                        {
                            var obj = new VoterModel();

                            obj.STATE_ID = Convert.ToInt32(row["STATE_ID"]);
                            obj.STATE_NAME = Convert.ToString(row["STATE_NAME"]);

                            lst.Add(obj);

                        }
                    }
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }



        //public List<VoterModel> getCity(int STATE_ID, int CITY_ID)
        //{
        //    try
        //    {
        //        string[] ParametersNames = { "@STATE_ID", "@CITY_ID" };
        //        string[] ParametersValues = { STATE_ID.ToString(), CITY_ID.ToString() };

        //        DataSet dataSet = _DbAccess.Ds_Process("SP_GET_CITY", ParametersNames, ParametersValues);
        //        List<VoterModel> lst = new List<VoterModel>();
        //        if (dataSet.Tables.Count > 0)
        //        {

        //            DataTable dt = dataSet.Tables[0];

        //            if (dt.Rows.Count > 0)
        //            {

        //                foreach (DataRow row in dt.Rows)
        //                {
        //                    var obj = new VoterModel();
        //                    obj.CITY_ID = Convert.ToInt32(row["CITY_ID"]);
        //                    obj.CITY_NAME = Convert.ToString(row["CITY_NAME"]);
        //                    lst.Add(obj);

        //                }
        //            }
        //        }
        //        return lst;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);

        //    }
        //}



        public List<VoterModel> getGender(int GENDER_ID)
        {
            try
            {
                string[] ParametersNames = { "@GENDER_ID" };
                string[] ParametersValues = { GENDER_ID.ToString() };

                DataSet dataSet = _DbAccess.Ds_Process("SP_GET_GENDER", ParametersNames, ParametersValues);
                List<VoterModel> lst = new List<VoterModel>();
                if (dataSet.Tables.Count > 0)
                {

                    DataTable dt = dataSet.Tables[0];

                    if (dt.Rows.Count > 0)
                    {

                        foreach (DataRow row in dt.Rows)
                        {
                            var obj = new VoterModel();
                            obj.GENDER_ID = Convert.ToInt32(row["GENDER_ID"]);
                            obj.GENDER_NAME = Convert.ToString(row["GENDER_NAME"]);
                            lst.Add(obj);

                        }
                    }
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }
    }
}
