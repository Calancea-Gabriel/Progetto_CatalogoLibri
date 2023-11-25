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
    class clsRepartiController
    {

        private adoNetSQL sqlReparto;
        private bool pErrore;
        private string pStrSQL;
        private List<clsReparti> listaReparti;

        public clsReparti Reparto;
        public string msgErrore;

        public clsRepartiController()
        {
            string pathDB = Application.StartupPath + "\\CatalogoLibri.mdf";
            sqlReparto = new adoNetSQL(pathDB);
            Reparto = new clsReparti();
            Reparto.ValReparto = ' ';
            msgErrore = string.Empty;
        }

        public bool aggiungi()
        {
            pErrore = false;

            sqlReparto.cmd.Parameters.AddWithValue("@CdReparto", Reparto.CodReparto);
            sqlReparto.cmd.Parameters.AddWithValue("@DeReparto", Reparto.DesReparto);
            sqlReparto.cmd.Parameters.AddWithValue("@VReparto", Reparto.ValReparto);

            pStrSQL = "INSERT INTO Reparti " +
                        " (CodReparto, DesReparto, ValReparto) " +
                        " VALUES(@CdReparto, @DeReparto, @VReparto)";

            try
            {
                int Risultato = sqlReparto.eseguiNonQuery(pStrSQL, CommandType.Text);
            }
            catch (Exception ex)
            {
                msgErrore = "ATTENZIONE !! " + ex.Message;
                pErrore = true;
            }
            finally
            {
                if(!pErrore)
                    msgErrore = "Reparto inserito correttamente !!!";
            }

            return pErrore;
        }

        public bool modifica()
        {
            pErrore = false;

            sqlReparto.cmd.Parameters.AddWithValue("@CdReparto", Reparto.CodReparto);
            sqlReparto.cmd.Parameters.AddWithValue("@DeReparto", Reparto.DesReparto);
            sqlReparto.cmd.Parameters.AddWithValue("@VReparto", Reparto.ValReparto);

            pStrSQL = "UPDATE Reparti SET " +
                        "DesReparto = @DeReparto, ValReparto = @VReparto " +
                        "WHERE CodReparto = @CdReparto";

            try
            {
                int Risultato = sqlReparto.eseguiNonQuery(pStrSQL, CommandType.Text);
            }
            catch (Exception ex)
            {
                msgErrore = "ATTENZIONE !! " + ex.Message;
                pErrore = true;
            }
            finally
            {
                if (!pErrore)
                    msgErrore = "Reparto modificato correttamente !!!";
            }


            return pErrore;
        }

        public bool chkReparto()
        {
            bool controllo = true;
            string Risultato = string.Empty;

            sqlReparto.cmd.Parameters.AddWithValue("@CdReparto", Reparto.CodReparto);

            pStrSQL = "SELECT COUNT(*) FROM Reparti " +
                        "WHERE CodReparto = @CdReparto";

            try
            {
                Risultato = sqlReparto.eseguiScalar(pStrSQL, CommandType.Text);
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
                        msgErrore = $"Il Reparto [{Reparto.CodReparto}] è già presente !!!";
                        controllo = false;
                    }

            }

            return controllo;
        }

        public List<clsReparti> elencoReparti()
        {
            listaReparti = new List<clsReparti>();

            pStrSQL = "SELECT * FROM Reparti WHERE ValReparto = '' ";

            caricaListaReparti();

            return listaReparti;
        }

        public List<clsReparti> elencoRepartiAnnullati()
        {
            listaReparti = new List<clsReparti>();

            pStrSQL = "SELECT * FROM Reparti WHERE ValReparto = 'A'";

            caricaListaReparti();

            return listaReparti;
        }

        private void caricaListaReparti()
        {
            
            SqlDataReader dataReader;

            pErrore = false;

            try
            {
                dataReader = sqlReparto.creaLettore(pStrSQL, CommandType.Text);
                while (dataReader.Read())
                {
                    clsReparti detReparto = new clsReparti();
                    detReparto.CodReparto = dataReader["CodReparto"].ToString();
                    detReparto.DesReparto = dataReader["DesReparto"].ToString();
                    detReparto.ValReparto = Convert.ToChar(dataReader["ValReparto"]);
                    listaReparti.Add(detReparto);
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
                    sqlReparto.chiudiLettore();
                }
            }

        }

        public clsReparti datiReparto()
        {
            pErrore = false;
            clsReparti modReparto = new clsReparti();
            DataTable tabellaReparti = null;

            sqlReparto.cmd.Parameters.AddWithValue("@CdReparto", Reparto.CodReparto);

            pStrSQL = "SELECT DesReparto, ValReparto FROM Reparti " +
                        "WHERE CodReparto = @CdReparto";

            try
            {
                tabellaReparti = sqlReparto.eseguiQuery(pStrSQL, CommandType.Text);
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
                    modReparto.CodReparto = Reparto.CodReparto;
                    modReparto.DesReparto = tabellaReparti.Rows[0].ItemArray[0].ToString();
                    modReparto.ValReparto = Convert.ToChar(tabellaReparti.Rows[0].ItemArray[1]);
                }
            }

            return modReparto;
        }

        public List<clsReparti> elencoRepartiLibri()
        {
            pErrore = false;
            listaReparti = new List<clsReparti>();
            SqlDataReader dataReader;

            pStrSQL = "SELECT CodReparto, DesReparto FROM Reparti WHERE ValReparto = ''";

            try
            {
                dataReader = sqlReparto.creaLettore(pStrSQL, CommandType.Text);
                while (dataReader.Read())
                {
                    clsReparti detReparto = new clsReparti();
                    detReparto.CodReparto = dataReader["CodReparto"].ToString();
                    detReparto.DesReparto = dataReader["DesReparto"].ToString();
                    listaReparti.Add(detReparto);
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
                sqlReparto.chiudiLettore();
            }

            return listaReparti;
        }
    }
}
