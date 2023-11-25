using Esercizio01.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;

namespace Esercizio01.Control
{
    internal class clsLibriController
    {
        private adoNetSQL sqlLibri;
        private bool pErrore;
        private string pStrSQL;
        private List<clsLibri> listaLibri;

        public clsLibri Libro;
        public string msgErrore;

        public clsLibriController()
        {
            string pathDB = Application.StartupPath + "\\CatalogoLibri.mdf";
            sqlLibri = new adoNetSQL(pathDB);
            Libro = new clsLibri();
            Libro.ValLibro = ' ';
            msgErrore = string.Empty;
        }

        public bool aggiungi()
        {
            pErrore = false;

            sqlLibri.cmd.Parameters.AddWithValue("@TitoloLibro", Libro.TitLibro);
            sqlLibri.cmd.Parameters.AddWithValue("@ImgLibro", Libro.ImgLibro);
            sqlLibri.cmd.Parameters.AddWithValue("@PrezzoLibro", Libro.PrzLibro);
            sqlLibri.cmd.Parameters.AddWithValue("@DataLibro", Libro.DataLibro);
            sqlLibri.cmd.Parameters.AddWithValue("@NPagineLibro", Libro.NPagLibro);
            sqlLibri.cmd.Parameters.AddWithValue("@CodRepLibro", Libro.CodRepLibro);
            sqlLibri.cmd.Parameters.AddWithValue("@IdOffLibro", Libro.IdOffLibro);
            sqlLibri.cmd.Parameters.AddWithValue("@IdEdiLibro", Libro.IdEdiLibro);
            sqlLibri.cmd.Parameters.AddWithValue("@ValLibro", Libro.ValLibro);

            pStrSQL = "INSERT INTO Libri (TitoloLibro, ImgLibro, PrezzoLibro, DataLibro, NPagineLibro, CodRepLibro, IdOffLibro, IdEdiLibro, ValLibro) " +
                                  "VALUES(@TitoloLibro, @ImgLibro, @PrezzoLibro, @DataLibro, @NPagineLibro, @CodRepLibro, @IdOffLibro, @IdEdiLibro, @ValLibro)";

            try
            {
                int Risultato = sqlLibri.eseguiNonQuery(pStrSQL, CommandType.Text);
            }
            catch (Exception ex)
            {
                msgErrore = "ATTENZIONE !! " + ex.Message;
                pErrore = true;
            }
            finally
            {
                if (!pErrore) msgErrore = "Libro inserito correttamente !!!";
            }

            return pErrore;
        }

        public bool modifica()
        {
            pErrore = false;

            sqlLibri.cmd.Parameters.AddWithValue("@IdLibro", Libro.IdLibro);
            sqlLibri.cmd.Parameters.AddWithValue("@TitoloLibro", Libro.TitLibro);
            sqlLibri.cmd.Parameters.AddWithValue("@ImgLibro", Libro.ImgLibro);
            sqlLibri.cmd.Parameters.AddWithValue("@PrezzoLibro", Libro.PrzLibro);
            sqlLibri.cmd.Parameters.AddWithValue("@DataLibro", Libro.DataLibro);
            sqlLibri.cmd.Parameters.AddWithValue("@NPagineLibro", Libro.NPagLibro);
            sqlLibri.cmd.Parameters.AddWithValue("@CodRepLibro", Libro.CodRepLibro);
            sqlLibri.cmd.Parameters.AddWithValue("@IdOffLibro", Libro.IdOffLibro);
            sqlLibri.cmd.Parameters.AddWithValue("@IdEdiLibro", Libro.IdEdiLibro);
            sqlLibri.cmd.Parameters.AddWithValue("@ValLibro", Libro.ValLibro);

            pStrSQL = "UPDATE Libri SET TitoloLibro = @TitoloLibro, ImgLibro = @ImgLibro, PrezzoLibro = @PrezzoLibro, " +
                "DataLibro = @DataLibro, NPagineLibro = @NPagineLibro, CodRepLibro = @CodRepLibro, IdOffLibro = @IdOffLibro, " +
                "IdEdiLibro = @IdEdiLibro, ValLibro = @ValLibro WHERE IdLibro = @IdLibro";


            try
            {
                int Risultato = sqlLibri.eseguiNonQuery(pStrSQL, CommandType.Text);
            }
            catch (Exception ex)
            {
                msgErrore = "ATTENZIONE !! " + ex.Message;
                pErrore = true;
            }
            finally
            {
                if (!pErrore)
                    msgErrore = "Libro modificato correttamente !!!";
            }
            return pErrore;
        }

        public List<clsLibri> elencoLibri()
        {
            listaLibri = new List<clsLibri>();

            pStrSQL = "SELECT * FROM Libri WHERE ValLibro = ''";

            caricaListaLibri();

            return listaLibri;
        }

        public List<clsLibri> elencoLibriAnnullati()
        {
            listaLibri = new List<clsLibri>();

            pStrSQL = "SELECT * FROM Libri WHERE ValLibro = 'A' ";

            caricaListaLibri();

            return listaLibri;
        }

        private void caricaListaLibri()
        {
            SqlDataReader dataReader;

            pErrore = false;

            try
            {
                dataReader = sqlLibri.creaLettore(pStrSQL, CommandType.Text);
                while (dataReader.Read())
                {
                    clsLibri detLibro = new clsLibri();
                    detLibro.IdLibro = Convert.ToInt16(dataReader["IdLibro"]);
                    detLibro.TitLibro = dataReader["TitoloLibro"].ToString();
                    detLibro.ImgLibro = dataReader["ImgLibro"].ToString();
                    detLibro.PrzLibro = Convert.ToDecimal(dataReader["PrezzoLibro"]);
                    detLibro.DataLibro = Convert.ToDateTime(dataReader["DataLibro"]);
                    detLibro.NPagLibro = Convert.ToInt16(dataReader["NPagineLibro"]);
                    detLibro.CodRepLibro = dataReader["CodRepLibro"].ToString();
                    detLibro.IdOffLibro = Convert.ToInt16(dataReader["IdOffLibro"]);
                    detLibro.IdEdiLibro = Convert.ToInt16(dataReader["IdEdiLibro"]);
                    detLibro.ValLibro = Convert.ToChar(dataReader["ValLibro"]);
                    listaLibri.Add(detLibro);
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
                    sqlLibri.chiudiLettore();
                }
            }
        }

        public List<clsLibri> elencoLibriByOfferta()
        {
            listaLibri = new List<clsLibri>();

            sqlLibri.cmd.Parameters.AddWithValue("@IdOffLibro", Libro.IdOffLibro);

            pStrSQL = "SELECT * FROM Libri WHERE IdOffLibro = @IdOffLibro AND ValLibro = ''";

            caricaListaLibri();

            return listaLibri;
        }

        public List<clsLibri> elencoLibriByReparto()
        {
            listaLibri = new List<clsLibri>();

            sqlLibri.cmd.Parameters.AddWithValue("@CodRepLibro", Libro.CodRepLibro);

            pStrSQL = "SELECT * FROM Libri WHERE CodRepLibro = @CodRepLibro AND ValLibro = ''";

            caricaListaLibri();

            return listaLibri;
        }

        public List<clsLibri> elencoLibriByOffertaAnnullati()
        {
            listaLibri = new List<clsLibri>();

            sqlLibri.cmd.Parameters.AddWithValue("@IdOffLibro", Libro.IdOffLibro);

            pStrSQL = "SELECT * FROM Libri WHERE IdOffLibro = @IdOffLibro AND ValLibro = 'A'";

            caricaListaLibri();

            return listaLibri;
        }

        public List<clsLibri> elencoLibriByRepartoAnnullati()
        {
            listaLibri = new List<clsLibri>();

            sqlLibri.cmd.Parameters.AddWithValue("@CodRepLibro", Libro.CodRepLibro);

            pStrSQL = "SELECT * FROM Libri WHERE CodRepLibro = @CodRepLibro AND ValLibro = 'A'";

            caricaListaLibri();

            return listaLibri;
        }

        public clsLibri datiLibro()
        {
            pErrore = false;
            clsLibri modLibro = new clsLibri();
            DataTable tabellaLibri = null;

            sqlLibri.cmd.Parameters.AddWithValue("@IdLibro", Libro.IdLibro);

            pStrSQL = "SELECT * FROM Libri WHERE IdLibro = @IdLibro";

            try
            {
                tabellaLibri = sqlLibri.eseguiQuery(pStrSQL, CommandType.Text);
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
                    modLibro.TitLibro = tabellaLibri.Rows[0].ItemArray[1].ToString();
                    modLibro.ImgLibro = tabellaLibri.Rows[0].ItemArray[2].ToString();
                    modLibro.PrzLibro = Convert.ToDecimal(tabellaLibri.Rows[0].ItemArray[3]);
                    modLibro.DataLibro = Convert.ToDateTime(tabellaLibri.Rows[0].ItemArray[4]);
                    modLibro.NPagLibro = Convert.ToInt32(tabellaLibri.Rows[0].ItemArray[5]);
                    modLibro.CodRepLibro = tabellaLibri.Rows[0].ItemArray[6].ToString();
                    modLibro.IdOffLibro = Convert.ToInt32(tabellaLibri.Rows[0].ItemArray[7]);
                    modLibro.IdEdiLibro = Convert.ToInt32(tabellaLibri.Rows[0].ItemArray[8]);
                    modLibro.ValLibro = Convert.ToChar(tabellaLibri.Rows[0].ItemArray[9]);
                }
            }

            return modLibro;
        }


    }
}
