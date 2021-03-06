﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using POSWebRpt.Common;
using POSWebRpt.DAL.DBManager;
using POSWebRpt.Entity;
using Utilities.DbManager;

namespace POSWebRpt.DAL
{
    public class ReportDAL : DataServiceBase
    {
        public static List<ReportEntity> GetBillWiseSaleRefund(ReportCriteria criteria)
        {            
            List<ReportEntity> lstData = new List<ReportEntity>();
            
            using (SqlDataHelper helper = new SqlDataHelper(ConnectionString))
            {
                helper.CommandText = "[dbo].[sp_rpt_SALEREFUNDREGISTER]";
                helper.CommandType = CommandType.StoredProcedure;
                helper.Parameters.Add("@TranType", criteria.TransactionType);
                helper.Parameters.Add("@StartDate", criteria.FromDate);
                helper.Parameters.Add("@EndDate", criteria.ToDate);
                helper.Open();
                helper.ExecuteReader(CommandBehavior.CloseConnection);

                while (helper.DataReader.Read())
                {
                    ReportEntity report = new ReportEntity();
                    report.LoadBillWiseSaleRefund(helper.DataReader);
                    lstData.Add(report);
                }

                helper.Close();
            }

            return lstData;
        }

        public static List<ReportEntity> GetCashierLog(ReportCriteria criteria)
        {
            List<ReportEntity> lstData = new List<ReportEntity>();

            using (SqlDataHelper helper = new SqlDataHelper(ConnectionString))
            {
                helper.CommandText = "[rpt].[]";
                helper.CommandType = CommandType.StoredProcedure;
                helper.Parameters.Add("@", 1);
                helper.Open();
                helper.ExecuteReader(CommandBehavior.CloseConnection);

                while (helper.DataReader.Read())
                {
                    ReportEntity report = new ReportEntity(helper.DataReader);
                    report.LoadCashierLog(helper.DataReader);
                    lstData.Add(report);
                }

                helper.Close();
            }

            return lstData;
        }

        public static List<ReportEntity> GetCashierWiseSale(ReportCriteria criteria)
        {
            List<ReportEntity> lstData = new List<ReportEntity>();

            using (SqlDataHelper helper = new SqlDataHelper(ConnectionString))
            {
                helper.CommandText = "[dbo].[sp_rpt_CASHIERWISESALE]";
                helper.CommandType = CommandType.StoredProcedure;
                helper.Parameters.Add("@Mode", criteria.CashierId);
                helper.Parameters.Add("@StartDate", criteria.FromDate);
                helper.Parameters.Add("@EndDate", criteria.ToDate);
                helper.Open();
                helper.ExecuteReader(CommandBehavior.CloseConnection);

                while (helper.DataReader.Read())
                {
                    ReportEntity report = new ReportEntity();
                    report.LoadCashierWiseSale(helper.DataReader);
                    lstData.Add(report);
                }

                helper.Close();
            }

            return lstData;
        }

        //public static List<ReportEntity> GetCashierWiseSaleSummary(ReportCriteria criteria)
        //{
        //    List<ReportEntity> lstData = new List<ReportEntity>();

        //    using (SqlDataHelper helper = new SqlDataHelper(ConnectionString))
        //    {
        //        helper.CommandText = "[dbo].[sp_rpt_CASHIERWISESALE]";
        //        helper.CommandType = CommandType.StoredProcedure;
        //        helper.Parameters.Add("@", 1);
        //        helper.Open();
        //        helper.ExecuteReader(CommandBehavior.CloseConnection);

        //        while (helper.DataReader.Read())
        //        {
        //            ReportEntity report = new ReportEntity(helper.DataReader);
        //            lstData.Add(report);
        //        }

        //        helper.Close();
        //    }

        //    return lstData;
        //}

        public static List<ReportEntity> GetItemWiseSale(ReportCriteria criteria)
        {
            List<ReportEntity> lstData = new List<ReportEntity>();

            using (SqlDataHelper helper = new SqlDataHelper(ConnectionString))
            {
                helper.CommandText = "[dbo].[sp_rpt_ITEMWISESALE]";
                helper.CommandType = CommandType.StoredProcedure;
                helper.Parameters.Add("@StartDate", criteria.FromDate);
                helper.Parameters.Add("@EndDate", criteria.ToDate);
                helper.Parameters.Add("@CounterID", criteria.CounterId);
                helper.Open();
                helper.ExecuteReader(CommandBehavior.CloseConnection);

                while (helper.DataReader.Read())
                {
                    ReportEntity report = new ReportEntity(helper.DataReader);
                    report.LoadItemWiseSale(helper.DataReader);
                    lstData.Add(report);
                }

                helper.Close();
            }

            return lstData;
        }

        //public static List<ReportEntity> GetItemWiseSaleWithCombo(ReportCriteria criteria)
        //{
        //    List<ReportEntity> lstData = new List<ReportEntity>();

        //    using (SqlDataHelper helper = new SqlDataHelper(ConnectionString))
        //    {
        //        helper.CommandText = "[rpt].[]";
        //        helper.CommandType = CommandType.StoredProcedure;
        //        helper.Parameters.Add("@", 1);
        //        helper.Open();
        //        helper.ExecuteReader(CommandBehavior.CloseConnection);

        //        while (helper.DataReader.Read())
        //        {
        //            ReportEntity report = new ReportEntity(helper.DataReader);
        //            lstData.Add(report);
        //        }

        //        helper.Close();
        //    }

        //    return lstData;
        //}

        public static List<ReportEntity> GetCounterWiseSaleSummary(ReportCriteria criteria)
        {
            List<ReportEntity> lstData = new List<ReportEntity>();

            using (SqlDataHelper helper = new SqlDataHelper(ConnectionString))
            {
                helper.CommandText = "[dbo].[sp_rpt_ITEMWISESALE]";
                helper.CommandType = CommandType.StoredProcedure;
                helper.Parameters.Add("@StartDate", criteria.FromDate);
                helper.Parameters.Add("@EndDate", criteria.ToDate);
                helper.Open();
                helper.ExecuteReader(CommandBehavior.CloseConnection);

                while (helper.DataReader.Read())
                {
                    ReportEntity report = new ReportEntity(helper.DataReader);
                    report.LoadCounterWiseSaleSummary(helper.DataReader);
                    lstData.Add(report);
                }

                helper.Close();
            }

            return lstData;
        }

        public static List<ReportEntity> GetSaleRegister(ReportCriteria criteria)
        {
            List<ReportEntity> lstData = new List<ReportEntity>();

            using (SqlDataHelper helper = new SqlDataHelper(ConnectionString))
            {
                helper.CommandText = "[dbo].[sp_rpt_SALESREGISTER]";
                helper.CommandType = CommandType.StoredProcedure;
                helper.Parameters.Add("@StartDate", criteria.FromDate);
                helper.Parameters.Add("@EndDate", criteria.ToDate);
                helper.Open();
                helper.ExecuteReader(CommandBehavior.CloseConnection);

                while (helper.DataReader.Read())
                {
                    ReportEntity report = new ReportEntity(helper.DataReader);
                    report.LoadSalesRegister(helper.DataReader);
                    lstData.Add(report);
                }

                helper.Close();
            }

            return lstData;
        }

        public static List<ReportEntity> GetStockLedger(ReportCriteria criteria)
        {
            List<ReportEntity> lstData = new List<ReportEntity>();

            using (SqlDataHelper helper = new SqlDataHelper(ConnectionString))
            {
                helper.CommandText = "[rpt].[sp_rpt_STOCKREGISTER]";
                helper.CommandType = CommandType.StoredProcedure;
                helper.Parameters.Add("@StartDate", criteria.FromDate);
                helper.Parameters.Add("@EndDate", criteria.ToDate);
                //helper.Parameters.Add("@Mode", criteria.FromDate);
                //helper.Parameters.Add("@OBDate", criteria.FromDate);
                //helper.Parameters.Add("@ItemCode", criteria.FromDate);
                helper.Open();
                helper.ExecuteReader(CommandBehavior.CloseConnection);

                while (helper.DataReader.Read())
                {
                    ReportEntity report = new ReportEntity(helper.DataReader);
                    report.LoadStockLedger(helper.DataReader);
                    lstData.Add(report);
                }

                helper.Close();
            }

            return lstData;
        }

        public static List<ReportEntity> GetItemWiseVat(ReportCriteria criteria)
        {
            List<ReportEntity> lstData = new List<ReportEntity>();

            using (SqlDataHelper helper = new SqlDataHelper(ConnectionString))
            {
                helper.CommandText = "[dbo].[sp_rpt_ITEMWISEVAT]";
                helper.CommandType = CommandType.StoredProcedure;
                helper.Parameters.Add("@StartDate", criteria.FromDate);
                helper.Parameters.Add("@EndDate", criteria.ToDate);
                helper.Open();
                helper.ExecuteReader(CommandBehavior.CloseConnection);

                while (helper.DataReader.Read())
                {
                    ReportEntity report = new ReportEntity(helper.DataReader);
                    report.LoadItemWiseVat(helper.DataReader);
                    lstData.Add(report);
                }

                helper.Close();
            }

            return lstData;
        }

        public static List<ReportEntity> GetRestaurantWiseVat(ReportCriteria criteria)
        {
            List<ReportEntity> lstData = new List<ReportEntity>();

            using (SqlDataHelper helper = new SqlDataHelper(ConnectionString))
            {
                helper.CommandText = "[dbo].[sp_rpt_ITEMWISEVAT]";
                helper.CommandType = CommandType.StoredProcedure;
                helper.Parameters.Add("@StartDate", criteria.FromDate);
                helper.Parameters.Add("@EndDate", criteria.ToDate);
                helper.Open();
                helper.ExecuteReader(CommandBehavior.CloseConnection);

                while (helper.DataReader.Read())
                {
                    ReportEntity report = new ReportEntity(helper.DataReader);
                    report.LoadRestaurantWiseVat(helper.DataReader);
                    lstData.Add(report);
                }

                helper.Close();
            }

            return lstData;
        }

        public static DataSet GetAllItemGroup()
        {
            //string ProcName = "sp_Manage_ITEMGROUP";

            List<ReportEntity> lstData = new List<ReportEntity>();

            using (SqlDataHelper helper = new SqlDataHelper(ConnectionString))
            {
                helper.CommandText = "[dbo].[sp_Manage_ITEMGROUP]";
                helper.CommandType = CommandType.StoredProcedure;
                helper.Parameters.Add("@Mode", "T");
                helper.Parameters.Add("@ItemRefID", 0);
                helper.Parameters.Add("@pk_GroupID", 0);
                helper.Parameters.Add("@UserID", 1);
                helper.Parameters.Add("@Result", 0);

                helper.Open();
                return helper.ExecuteDataSet();
    

                //helper.ExecuteReader(CommandBehavior.CloseConnection);

                //while (helper.DataReader.Read())
                //{
                //    ReportEntity report = new ReportEntity();
                //    report.LoadCashierWiseSale(helper.DataReader);
                //    lstData.Add(report);
                //}

                //helper.Close();
            }

           
        }
    }
}
