using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

using Esercizio01.Model;

namespace Esercizio01.Control
{
    internal class clsOfferteController
    {
        private adoNetSQL sqlOfferta;
        private bool pErrore;
        private string pStrSQL;
        private List<clsOfferte> listaOfferte;

        public clsOfferte Offerta;
        public string msgErrore;

        public clsOfferteController()
        {
            string pathDB = Application.StartupPath + "\\CatalogoLibri.mdf";
            sqlOfferta = new adoNetSQL(pathDB);
            Offerta = new clsOfferte();
            Offerta.ValOfferta = ' ';
            msgErrore = string.Empty;
        }

        public bool aggiungi()
        {
            pErrore = false;

            sqlOfferta.cmd.Parameters.AddWithValue("@DesOfferta", Offerta.DesOfferta);
            sqlOfferta.cmd.Parameters.AddWithValue("@ScontoOfferta", Offerta.ScontoOfferta);
            sqlOfferta.cmd.Parameters.AddWithValue("@ValOfferta", Offerta.ValOfferta);

            pStrSQL = "INSERT INTO Offerte (DesOfferta, ScontoOfferta, ValOfferta) VALUES(@DesOfferta, @ScontoOfferta, @ValOfferta)";

            try
            {
                int Risultato = sqlOfferta.eseguiNonQuery(pStrSQL, CommandType.Text);
            }
            catch (Exception ex)
            {
                msgErrore = "ATTENZIONE !! " + ex.Message;
                pErrore = true;
            }
            finally
            {
                if (!pErrore) msgErrore = "Offerta inserita correttamente !!!";
            }

            return pErrore;
        }

        public bool modifica()
        {
            pErrore = false;

            sqlOfferta.cmd.Parameters.AddWithValue("@idOfferta", Offerta.IdOfferta);
            sqlOfferta.cmd.Parameters.AddWithValue("@DesOfferta", Offerta.DesOfferta);
            sqlOfferta.cmd.Parameters.AddWithValue("@ScontoOfferta", Offerta.ScontoOfferta);
            sqlOfferta.cmd.Parameters.AddWithValue("@ValOfferta", Offerta.ValOfferta);

            pStrSQL = "UPDATE Offerte SET DesOfferta = @DesOfferta, ScontoOfferta = @ScontoOfferta, ValOfferta = @ValOfferta WHERE idOfferta = @idOfferta";

            try
            {
                int Risultato = sqlOfferta.eseguiNonQuery(pStrSQL, CommandType.Text);
            }
            catch (Exception ex)
            {
                msgErrore = "ATTENZIONE !! " + ex.Message;
                pErrore = true;
            }
            finally
            {
                if (!pErrore)
                    msgErrore = "Offerta modificata correttamente !!!";
            }

            return pErrore;
        }

        public bool chkOfferta()
        {
            bool controllo = true;
            string Risultato = string.Empty;

            sqlOfferta.cmd.Parameters.AddWithValue("@DesOfferta", Offerta.DesOfferta);

            pStrSQL = "SELECT COUNT(*) FROM Offerte WHERE DesOfferta = @DesOfferta";

            try
            {
                Risultato = sqlOfferta.eseguiScalar(pStrSQL, CommandType.Text);
            }
            catch (Exception ex)
            {
                msgErrore = "ATTENZIONE !! " + ex.Message;
                controllo = false;
            }
            finally
            {
                if (controllo)
                    if (Convert.ToInt32(Risultato) != 0)
                    {
                        msgErrore = $"l'offerta [{Offerta.DesOfferta}] è già presente !!!";
                        controllo = false;
                    }

            }

            return controllo;
        }

        public List<clsOfferte> elencoOfferte()
        {
            listaOfferte = new List<clsOfferte>();

            pStrSQL = "SELECT * FROM Offerte WHERE ValOfferta = '' ";

            caricaListaOfferte();

            return listaOfferte;
        }

        public List<clsOfferte> elencoOfferteAnnullate()
        {
            listaOfferte = new List<clsOfferte>();

            pStrSQL = "SELECT * FROM Offerte WHERE ValOfferta = 'A'";

            caricaListaOfferte();

            return listaOfferte;
        }

        private void caricaListaOfferte()
        {
            SqlDataReader dataReader;

            pErrore = false;

            try
            {
                dataReader = sqlOfferta.creaLettore(pStrSQL, CommandType.Text);
                while (dataReader.Read())
                {
                    clsOfferte detOfferta = new clsOfferte();
                    detOfferta.IdOfferta = Convert.ToInt16(dataReader["IdOfferta"]);
                    detOfferta.DesOfferta = dataReader["DesOfferta"].ToString();
                    detOfferta.ScontoOfferta = Convert.ToInt16(dataReader["ScontoOfferta"]);
                    detOfferta.ValOfferta = Convert.ToChar(dataReader["ValOfferta"]);
                    listaOfferte.Add(detOfferta);
                }
            }
            catch (Exception ex)
            {
                msgErrore = "ATTENZIONE !! " + ex.Message;
                pErrore = true;
            }
            finally
            {
                if (!pErrore)
                {
                    msgErrore = "Lista creata con Successo !!";
                    sqlOfferta.chiudiLettore();
                }
            }
        }

        public clsOfferte datiOfferta()
        {
            pErrore = false;
            clsOfferte modOfferta = new clsOfferte();
            DataTable tabellaOfferte = null;

            sqlOfferta.cmd.Parameters.AddWithValue("@IdOfferta", Offerta.IdOfferta);

            pStrSQL = "SELECT DesOfferta, ScontoOfferta, ValOfferta FROM Offerte WHERE IdOfferta = @IdOfferta";

            try
            {
                tabellaOfferte = sqlOfferta.eseguiQuery(pStrSQL, CommandType.Text);
            }
            catch (Exception ex)
            {
                msgErrore = ex.Message;
                pErrore = true;
            }
            finally
            {
                if (!pErrore)
                {
                    modOfferta.DesOfferta = tabellaOfferte.Rows[0].ItemArray[0].ToString();
                    modOfferta.ScontoOfferta = Convert.ToInt32(tabellaOfferte.Rows[0].ItemArray[1]);
                    modOfferta.ValOfferta = Convert.ToChar(tabellaOfferte.Rows[0].ItemArray[2]);
                }
            }

            return modOfferta;
        }

        public List<clsOfferte> elencoOfferteLibri()
        {
            pErrore = false;
            listaOfferte = new List<clsOfferte>();
            SqlDataReader dataReader;

            pStrSQL = "SELECT IdOfferta, DesOfferta FROM Offerte WHERE ValOfferta = ''";

            try
            {
                dataReader = sqlOfferta.creaLettore(pStrSQL, CommandType.Text);
                while (dataReader.Read())
                {
                    clsOfferte detOfferta = new clsOfferte();
                    detOfferta.IdOfferta = Convert.ToInt32(dataReader["IdOfferta"]);
                    detOfferta.DesOfferta = dataReader["DesOfferta"].ToString();
                    listaOfferte.Add(detOfferta);
                }
            }
            catch (Exception ex)
            {
                msgErrore = ex.Message;
                pErrore = true;
            }
            finally
            {
                msgErrore = "Lista creata con Successo !!!";
                sqlOfferta.chiudiLettore();
            }

            return listaOfferte;
        }
    }
}
