using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidad;


namespace Cliente
{
    public partial class Busqueda : Form
    {

        public Busqueda()
        {
            InitializeComponent();
        }
        //Arreglo a utilizarse para llenar el datatable
        string[,] cd = new string[50, 6];
        int i = 0;
        //datatable a llenarse con el arreglo de acuerdo a las respuestas del servidor
        DataTable listado = new DataTable();
        
        //Validaciones para el evento de click en buscar
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (rdbNombreCancion.Checked == false && rdbNombreAlbum.Checked == false && rdbClasificacion.Checked == false && rdbAutor.Checked == false)
            {
                MessageBox.Show("Es necesario que seleccione un criterio de búsqueda");
            }
            else if (txtParametro.Text == "")
            {
                MessageBox.Show("No ha escrito un parámetro a buscarse");
            }
            else
            {
                //si algún radio button está seleccionado y el textbox tiene algún valor se llena el datatable con el contenido de la matriz
                listado = llenarDataGrid();
                dataGridView1.DataSource = listado.DefaultView;
                rdbAutor.Enabled = false;
                rdbClasificacion.Enabled = false;
                rdbNombreAlbum.Enabled = false;
                rdbNombreCancion.Enabled = false;
            }  
        }

        private void ClienteForm2_Load(object sender, EventArgs e)
        {
            Menu_Principal.conexionTcp.OnDataRecieved += MensajeRecibidoDesdeElServidor;
            rdbAutor.Enabled = false;
            rdbClasificacion.Enabled = false;
            rdbNombreAlbum.Enabled = false;
            rdbNombreCancion.Enabled = false;
            txtParametro.Focus();

        }


        private void rdbNombreCancion_CheckedChanged(object sender, EventArgs e)
        {
            lblParametroBuscar.Text = "Título de la canción: ".ToString();
            if (Menu_Principal.conexionTcp.TcpClient.Connected && txtParametro.Text!="")
            {
                //Se envía el paquete de solicitud al servidor
                var msgPack = new PaqueteCliente("LISTAR_POR_CANCION", string.Format("{0}", txtParametro.Text));
                Menu_Principal.conexionTcp.EnviarPaquete(msgPack);
                //Se resetea el datatable y el arreglo bidimensional
                listado.Clear();
                listado.Reset();
                Array.Clear(cd, 0, cd.Length);
                i = 0;
            }
        }

        private void rdbClasificacion_CheckedChanged(object sender, EventArgs e)
        {
            lblParametroBuscar.Text = "Valor de clasificación: ".ToString();
            if (Menu_Principal.conexionTcp.TcpClient.Connected && txtParametro.Text != "" && validarRangoClasificacion()==true)
            {
                //Se envía el paquete de solicitud al servidor
                var msgPack = new PaqueteCliente("LISTAR_POR_CLASIFICACION", string.Format("{0}", txtParametro.Text));
                Menu_Principal.conexionTcp.EnviarPaquete(msgPack);
                // Se resetea el datatable y se limpia el arreglo
                listado.Clear();
                listado.Reset();
                Array.Clear(cd, 0, cd.Length);
                i = 0;
            }
            else if (validarRangoClasificacion()==false)
            {
                MessageBox.Show("El valor ingresado está fuera del rango de valores de clasificación ", "Alerta", MessageBoxButtons.OK);
            }
        }

        private void rdbNombreAlbum_CheckedChanged(object sender, EventArgs e)
        {
            lblParametroBuscar.Text = "Nombre del álbum: ".ToString();
            if (Menu_Principal.conexionTcp.TcpClient.Connected && txtParametro.Text != "")
            {
                //Se envía el paquete de solicitud al servidor
                var msgPack = new PaqueteCliente("LISTAR_POR_ALBUM", string.Format("{0}", txtParametro.Text));
                Menu_Principal.conexionTcp.EnviarPaquete(msgPack);
                //Se limpia el datatable y el arreglo
                listado.Clear();
                listado.Reset();
                Array.Clear(cd, 0, cd.Length);
                i = 0;
            }
        }

        private void rdbAutor_CheckedChanged(object sender, EventArgs e)
        {
            lblParametroBuscar.Text = "Autor: ".ToString();
            if (Menu_Principal.conexionTcp.TcpClient.Connected && txtParametro.Text != "")
            {
                //Se envía el paquete de solicitud al servidor
                var msgPack = new PaqueteCliente("LISTAR_POR_AUTOR", string.Format("{0}", txtParametro.Text));
                Menu_Principal.conexionTcp.EnviarPaquete(msgPack);
                //Se limpia el datatable y el arreglo
                listado.Clear();
                listado.Reset();
                Array.Clear(cd, 0, cd.Length);
                i = 0;
            }
        }


        private void ClienteForm2_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        public void MensajeRecibidoDesdeElServidor(string datos)
        {
            //Se obtiene el comando del paquete recibido desde el servidor
            var paquete = new PaqueteCliente(datos);
            string comando = paquete.Comando;
            //Si el comando es RESPUESTA_LISTAR_POR
            //Se obtendrá el contenido de la respuesta de acuerdo a la solicitud del cliente, se deserializará el contenido
            //en una lista de valores y se irá llenando el arreglo 
            if (comando == "RESPUESTA_LISTAR_POR_")
            {
                string conten = paquete.Contenido;
                List<string> val = MapaCliente.Deserializar(conten);          
                cd[i, 0] = val[0];
                cd[i, 1] = val[1];
                cd[i, 2] = val[2];
                cd[i, 3] = val[3];
                cd[i, 4] = val[4];
                cd[i, 5] = val[5];
               //Para que todos los valores lleguen adecuadamente
                System.Threading.Thread.Sleep(30);
                i++;
                //  Se llena el datatable con los valores de la matriz
                llenarDataGrid();
            }
           //NOOK
           //Respuestas del servidor cuando alguna petición del cliente no se ha realizado correctamente
           //Muestra mensajes con el detalle del error
            if (comando=="NOOK_LISTAR_POR_CANCION")
            {
                string contenido = paquete.Contenido;
                MessageBox.Show(contenido);
            }
            if (comando == "NOOK_LISTAR_POR_ALBUM")
            {
                string contenido = paquete.Contenido;
                MessageBox.Show(contenido);
            }
            if (comando == "NOOK_LISTAR_POR_AUTOR")
            {
                string contenido = paquete.Contenido;
                MessageBox.Show(contenido);
            }
            if (comando == "NOOK_LISTAR_POR_CLASIFICACION")
            {
                string contenido = paquete.Contenido;
                MessageBox.Show(contenido);
            }
            //OK
            //COMANDO OK PARA LA ELIMINACIÓN DE CANCIONES
            if (comando == "OK_ELIMINAR")
            {
                string contenido = paquete.Contenido;
                MessageBox.Show(contenido);

            }
           
        }
        //Método retorna un datatable lleno con el arreglo que contiene los datos de respuesta del servidor
        public DataTable llenarDataGrid()
        {
            DataTable d= new DataTable();
            d.Columns.Add("N");
            d.Columns.Add("CANCION");
            d.Columns.Add("ÁLBUM");
            d.Columns.Add("POSICIÓN");
            d.Columns.Add("AUTOR");
            d.Columns.Add("CLASIFICACIÓN");
            //System.Diagnostics.Debug.WriteLine("ESGTO ES LO QUE ESTAS BUSCANSOOO: "+cd[0, 1]);
            for (int i = 0; i < cd.GetLength(0); i++)
            {
               d.Rows.Add(cd[i, 0], cd[i, 1], cd[i, 2], cd[i, 3], cd[i, 4], cd[i, 5]);
            }
            return d;
        }
        private void txtParametro_TextChanged(object sender, EventArgs e)
        {
            rdbAutor.Enabled = true;
            rdbClasificacion.Enabled = true;
            rdbNombreAlbum.Enabled = true;
            rdbNombreCancion.Enabled = true;
        }
        
      
        private void txtParametro_MouseUp(object sender, MouseEventArgs e)
        {
            rdbAutor.Checked = false;
            rdbClasificacion.Checked = false;
            rdbNombreAlbum.Checked = false;
            rdbNombreCancion.Checked = false;
            Array.Clear(cd, 0, cd.Length);
        }

        /*Metodo para Eliminar la cancion seleccionada
         * Los criterios para eliminar la cancion son:
         * Que se debe seleccionar de la lista el ID de la cancion
         * para asi al dar clic en Eliminar se elimine la cancion de la base de datos.
        */
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtParametro.Text))
            {
                MessageBox.Show("Por favor ingrese un parametro de busqueda.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else 
            {
                string indice;
                string columna = dataGridView1.CurrentCell.ColumnIndex.ToString();
                Console.WriteLine(columna);

                if ((columna == "0"))
                {
                    string control_vacio;
                    control_vacio = dataGridView1.CurrentCell.Value.ToString();
                    if (string.IsNullOrWhiteSpace(control_vacio))
                    {
                        MessageBox.Show("Por favor seleccione un campo que no este vacio!!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else 
                    {
                        indice = dataGridView1.CurrentCell.Value.ToString();
                        if (Menu_Principal.conexionTcp.TcpClient.Connected)
                        {
                            var msgPack = new PaqueteCliente("eliminar_cancion", string.Format("{0}", indice));
                            Menu_Principal.conexionTcp.EnviarPaquete(msgPack);
                            this.Close();
                        }
                    }   
                }
                else
                {
                    MessageBox.Show("Por favor seleccione el numero ID", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }

        //Metodo para Eliminar una cancion con el mismo criterio de seleccionar el ID y eliminar la cancion.
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtParametro.Text))
            {
                MessageBox.Show("Por favor ingrese un parametro de busqueda.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else 
            {
                int id;
                string columna = dataGridView1.CurrentCell.ColumnIndex.ToString();
                if (columna == "0")
                {
                    string control_vacio;
                    control_vacio = dataGridView1.CurrentCell.Value.ToString();
                    if (string.IsNullOrWhiteSpace(control_vacio))
                    {
                        MessageBox.Show("Por favor seleccione un campo que no este vacio!!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        DataGridViewRow row = dataGridView1.CurrentRow;
                        if (row == null)
                        {
                            return;
                        }
                        //Se envian los datos seleccionados al siguiente formulario
                        id = Int32.Parse(dataGridView1.CurrentCell.Value.ToString());
                        string nombre = row.Cells["CANCION"].Value.ToString();
                        string album = row.Cells["ÁLBUM"].Value.ToString();
                        int posicion = Int32.Parse(row.Cells["POSICIÓN"].Value.ToString());
                        string autor = row.Cells["AUTOR"].Value.ToString();
                        Editar editar = new Editar(id, nombre, album, posicion, autor);
                        editar.Show();
                    }    
                }
                else
                {
                    MessageBox.Show("Por favor seleccione el numero ID", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }
        //Método para validar si el rango ingresado en la búsqueda por clasificación está entre 1 y 5
        public bool validarRangoClasificacion()
        {
            bool rango = false;
            bool valorClasificacion = int.TryParse(txtParametro.Text, out _);
            if (valorClasificacion)
            {
                if(Int32.Parse(txtParametro.Text)>=1 && Int32.Parse(txtParametro.Text) < 6)
                {
                    rango = true;
                }
                else
                {
                    rango = false;
                }
            
            }
         
            else
            {
                rango = false;
            }
            return rango;
        }

        private void btnClasificar_Click(object sender, EventArgs e)
        {
            

            if (string.IsNullOrWhiteSpace(txtParametro.Text))
            {
                MessageBox.Show("Por favor ingrese un parametro de busqueda.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int id;
                string columna = dataGridView1.CurrentCell.ColumnIndex.ToString();
                if (columna == "0")
                {
                    string control_vacio;
                    control_vacio = dataGridView1.CurrentCell.Value.ToString();
                    if (string.IsNullOrWhiteSpace(control_vacio))
                    {
                        MessageBox.Show("Por favor seleccione un campo que no este vacio!!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        DataGridViewRow row = dataGridView1.CurrentRow;
                        if (row == null)
                        {
                            return;
                        }
                        //Se envian los datos seleccionados al siguiente formulario
                        id = Int32.Parse(dataGridView1.CurrentCell.Value.ToString());
                        string nombre = row.Cells["CANCION"].Value.ToString();
                        string album = row.Cells["ÁLBUM"].Value.ToString();
                        int posicion = Int32.Parse(row.Cells["POSICIÓN"].Value.ToString());
                        string autor = row.Cells["AUTOR"].Value.ToString();

                        Clasificar clasificar_form = new Clasificar(id, nombre, album, posicion, autor);
                        clasificar_form.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Por favor seleccione el numero ID", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
