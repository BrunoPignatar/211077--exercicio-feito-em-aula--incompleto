using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _211077
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            txt_descricao.Focus();
        }

        private void btn_fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        int count = 1;

        private void btn_inserir_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Confirmar a venda?", "Confirmação!",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                count++;
                txt_venda.Text = count.ToString();
                dataGridView.Rows.Add(txt_descricao.Text, txt_qnt.Text, txt_vlr.Text);

                txt_descricao.Clear();
                txt_qnt.Clear();
                txt_vlr.Clear();

                MessageBox.Show("Venda Concluida com Sucesso", "Sucesso!",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            lbl_grade.Text = dataGridView.RowCount.ToString();
            //FAZER A FUNÇÂO DE MOSTRAR TOTAL
            //dataGridView.SelectAll();
            //double total = Convert.ToDouble(lbl_total.Text) + (Convert.ToDouble(dataGridView.CurrentRow.Cells["Quantidade"].Value) * Convert.ToDouble(dataGridView.CurrentRow.Cells["valor_unit"].Value));

            //lbl_total.Text = total.ToString();
            txt_selecionados.Text = dataGridView.SelectedRows.Count.ToString();
        }

        private void btn_remover_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Nenhum Item Selecionado", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DialogResult result = MessageBox.Show("Tem certeza que deseja remover??", "Remover!",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    dataGridView.Rows.RemoveAt(dataGridView.CurrentRow.Index);

                    lbl_grade.Text = dataGridView.RowCount.ToString();

                    //dataGridView.SelectAll();
                    //double total = Convert.ToDouble(lbl_total.Text) + (Convert.ToDouble(dataGridView.CurrentRow.Cells["Quantidade"].Value) * Convert.ToDouble(dataGridView.CurrentRow.Cells["valor_unit"].Value));

                    //lblTotal.Text = total.ToString();

                    txt_selecionados.Text = dataGridView.SelectedRows.Count.ToString();


                    MessageBox.Show("Venda Removida com Sucesso", "Sucesso!",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_selecionados.Text = dataGridView.SelectedRows.Count.ToString();
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            txt_descricao.Clear();
            txt_qnt.Clear();
            txt_vlr.Clear();
        }

        private void btn_novavenda_Click(object sender, EventArgs e)
        {
            txt_descricao.Clear();
            txt_qnt.Clear();
            txt_vlr.Clear();
        }

        private void btn_alterar_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Nenhum Item Selecionado", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                txt_venda.Clear();
                txt_descricao.Text = dataGridView.CurrentRow.Cells["Descricao"].Value.ToString();
                txt_qnt.Text = dataGridView.CurrentRow.Cells["Quantidade"].Value.ToString();
                txt_vlr.Text = dataGridView.CurrentRow.Cells["valor_unit"].Value.ToString();

                btn_att.Visible = true;
            }
        }

        private void btn_att_Click(object sender, EventArgs e)
        {
            dataGridView.CurrentRow.Cells["Descricao"].Value = txt_descricao.Text;
            dataGridView.CurrentRow.Cells["Quantidade"].Value = txt_descricao.Text;
            dataGridView.CurrentRow.Cells["valor_unit"].Value = txt_descricao.Text;

            txt_descricao.Clear();
            txt_qnt.Clear();
            txt_vlr.Clear();
            txt_venda.Text = count.ToString();

            btn_att.Visible = false;
        }
    }
}
