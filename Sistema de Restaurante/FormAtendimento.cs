﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurante
{
    public partial class FormAtendimento : Form
    {
        public FormAtendimento()
        {
            InitializeComponent();
        }

        private void FormAtendimento_Load(object sender, EventArgs e)
        {
            atualizarDGV();
        }

        private void dtpInicial_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Back) || (e.KeyCode == Keys.Delete))
            {
                dtpInicial.CustomFormat = " ";
            }
        }

        private void dtpFinal_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Back) || (e.KeyCode == Keys.Delete))
            {
                dtpFinal.CustomFormat = " ";
            }
        }

        private void dtpInicial_ValueChanged(object sender, EventArgs e)
        {
            atualizarDGV();
        }

        private void dtpFinal_ValueChanged(object sender, EventArgs e)
        {
            atualizarDGV();
        }

        public void atualizarDGV()
        {
            string datainicial = "";
            string datafinal = "";
            if (dtpInicial.CustomFormat != " " && dtpFinal.CustomFormat == " ")
            {
                datainicial = dtpInicial.Value.ToString("yyyy-MM-dd");
                DateTime hoje = DateTime.Now;
                datafinal = hoje.ToString("yyyy-MM-dd");
            }
            else if (dtpInicial.CustomFormat == " " && dtpFinal.CustomFormat != " ")
            {
                datafinal = dtpFinal.Value.ToString("yyyy-MM-dd");
                DateTime hoje = DateTime.MinValue;
                datainicial = hoje.ToString("yyyy-MM-dd");
            }
            else if (dtpInicial.CustomFormat != " " && dtpFinal.CustomFormat != " ")
            {
                datainicial = dtpInicial.Value.ToString("yyyy-MM-dd");
                datafinal = dtpFinal.Value.ToString("yyyy-MM-dd");
            }
            else
            {
                DateTime hoje = DateTime.Now;
                datainicial = hoje.ToString("yyyy-MM-dd");
                datafinal = hoje.ToString("yyyy-MM-dd");
            }
            Pedidos pedido = new Pedidos();
            List<Pedidos> lista = pedido.ListarAtendimento(datainicial, datafinal);
            dgvAtendentes.DataSource = lista;
            dgvAtendentes.Columns.Remove("IdPedido");
            dgvAtendentes.Columns.Remove("Cliente");
            dgvAtendentes.Columns.Remove("Mesa");
            dgvAtendentes.Columns.Remove("Pessoas");
            dgvAtendentes.Columns.Remove("Data");
            dgvAtendentes.Columns.Remove("Status");
            dgvAtendentes.Columns[3].HeaderText = "Pedidos Completados";
            dgvAtendentes.Columns[4].HeaderText = "Pratos Entregues";
            dgvAtendentes.Columns.Remove("endereco");
            dgvAtendentes.Columns.Remove("complemento");
            dgvAtendentes.Columns.Remove("bairro");
            dgvAtendentes.Columns.Remove("telefone");
        }

        private void dgvAtendentes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string datainicial = "";
                string datafinal = "";
                if (dtpInicial.CustomFormat != " " && dtpFinal.CustomFormat == " ")
                {
                    datainicial = dtpInicial.Value.ToString("yyyy-MM-dd");
                    DateTime hoje = DateTime.Now;
                    datafinal = hoje.ToString("yyyy-MM-dd");
                }
                else if (dtpInicial.CustomFormat == " " && dtpFinal.CustomFormat != " ")
                {
                    datafinal = dtpFinal.Value.ToString("yyyy-MM-dd");
                    DateTime hoje = DateTime.MinValue;
                    datainicial = hoje.ToString("yyyy-MM-dd");
                }
                else if (dtpInicial.CustomFormat != " " && dtpFinal.CustomFormat != " ")
                {
                    datainicial = dtpInicial.Value.ToString("yyyy-MM-dd");
                    datafinal = dtpFinal.Value.ToString("yyyy-MM-dd");
                }
                else
                {
                    DateTime hoje = DateTime.Now;
                    datainicial = hoje.ToString("yyyy-MM-dd");
                    datafinal = hoje.ToString("yyyy-MM-dd");
                }
                DataGridViewRow row = this.dgvAtendentes.Rows[e.RowIndex];
                Pedidos pedido = new Pedidos();
                List<Pedidos> lista = pedido.ListarPedidos((int)row.Cells[0].Value, datainicial, datafinal);
                dgvPedidos.DataSource = lista;
                dgvPedidos.Columns.Remove("IdAtendente");
                dgvPedidos.Columns.Remove("Atendente");
                dgvPedidos.Columns.Remove("CPF");
                dgvPedidos.Columns.Remove("NumeroPedidos");
                dgvPedidos.Columns.Remove("NumeroPratos");
                dgvPedidos.Columns.Remove("endereco");
                dgvPedidos.Columns.Remove("bairro");
                dgvPedidos.Columns.Remove("complemento");
                dgvPedidos.Columns.Remove("telefone");
                dgvPedidos.Columns[5].HeaderText = "Situação";
            }
        }

        private void dgvPedidos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvPedidos.Rows[e.RowIndex];
                FormDetalhesPedido dp = new FormDetalhesPedido((int)row.Cells[0].Value);
                dp.Show();
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pbFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
