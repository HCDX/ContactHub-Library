using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace IMDLL
{
    public class Email
    {
        public int EmailID;
        public string MsgContent;
        public int senderID;
        public DateTime Emaildate;
        public int groupiD;
        public int Nbre;
        public int typeSMS;
        public string Destinataires;
        public int MsgEnvoye;
        public int MsgEchoue;
        public string strobject;
        public string piecejointe;
        public int programme;

        public int SaveEmail(Email newEmail, out string savingReport)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[13];

                param[0] = new SqlParameter("@EmailID", newEmail.EmailID);
                param[1] = new SqlParameter("@MsgContent", newEmail.MsgContent);
                param[2] = new SqlParameter("@senderID", newEmail.senderID);
                param[3] = new SqlParameter("@Emaildate", newEmail.Emaildate);
                param[4] = new SqlParameter("@groupiD", newEmail.groupiD);
                param[5] = new SqlParameter("@Nbre", newEmail.Nbre);
                param[6] = new SqlParameter("@typeSMS", newEmail.typeSMS);
                param[7] = new SqlParameter("@Destinataires", newEmail.Destinataires);
                param[8] = new SqlParameter("@MsgEnvoye", newEmail.MsgEnvoye);
                param[9] = new SqlParameter("@MsgEchoue", newEmail.MsgEchoue);
                param[10] = new SqlParameter("@object", newEmail.strobject);
                param[11] = new SqlParameter("@piecejointe", newEmail.piecejointe);
                param[12] = new SqlParameter("@programme", newEmail.programme);

                savingReport = " Data Has been Saved.";

                return clsSqlHelper.executeNonQuery_SP("sp_addEmail", param);

            }

            catch (Exception ex)
            {

                savingReport = ex.Message;
                return 0;

            }
        }

        public int UpdateEmail(Email newEmail, out string savingReport)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[12];

                param[0] = new SqlParameter("@EmailID", newEmail.EmailID);
                param[1] = new SqlParameter("@MsgContent", newEmail.MsgContent);
                param[2] = new SqlParameter("@senderID", newEmail.senderID);
                param[3] = new SqlParameter("@Emaildate", newEmail.Emaildate);
                param[4] = new SqlParameter("@groupiD", newEmail.groupiD);
                param[5] = new SqlParameter("@Nbre", newEmail.Nbre);
                param[6] = new SqlParameter("@typeSMS", newEmail.typeSMS);
                param[7] = new SqlParameter("@Destinataires", newEmail.Destinataires);
                param[8] = new SqlParameter("@MsgEnvoye", newEmail.MsgEnvoye);
                param[9] = new SqlParameter("@MsgEchoue", newEmail.MsgEchoue);
                param[10] = new SqlParameter("@object", newEmail.strobject);
                param[11] = new SqlParameter("@piecejointe", newEmail.piecejointe);

                savingReport = " Data Has been Saved.";

                return clsSqlHelper.executeNonQuery_SP("sp_updateEmail", param);

            }

            catch (Exception ex)
            {

                savingReport = ex.Message;
                return 0;

            }
        }

    }
}
