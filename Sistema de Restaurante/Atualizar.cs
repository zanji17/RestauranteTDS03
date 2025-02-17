﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Restaurante
{
    class Atualizar
    {
        //Home Cozinha
        public static string CountCozinha(int PConfirmados)
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Programas\\Restaurante\\Sistema de Restaurante\\Restaurante.mdf;Integrated Security=True");
            con.Open();
            string sql = "SELECT COUNT(*) as confirmados FROM Pedidos INNER JOIN PedidosPratosProdutos ON Pedidos.IdPedido = PedidosPratosProdutos.IdPedido INNER JOIN PratosProdutos ON PedidosPratosProdutos.IdPratoProduto = PratosProdutos.IdPratoProduto WHERE PedidosPratosProdutos.status='Confirmado' AND cozinha='S' AND Pedidos.status = 'Aberto'";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            if ((int)dr["confirmados"] == PConfirmados)
            {
                con.Close();
                return "não";
            }
            else
            {
                con.Close();
                return "sim";
            }
        }
        //--------------------------------------------------------------

        //Home Atendente
        public static string CountMeusPedidos(int atendente, int pedidos)
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Programas\\Restaurante\\Sistema de Restaurante\\Restaurante.mdf;Integrated Security=True");
            con.Open();
            string sql = "SELECT COUNT(*) as pedidos FROM Pedidos WHERE status='Aberto' AND IdAtendente='" + atendente + "' AND mesa != 'Delivery'";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            if ((int)dr["pedidos"] == pedidos)
            {
                return "não";
            }
            else
            {
                return "sim";
            }
        }

        public static string CountTodosPedidos(int atendente, int pedidos)
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Programas\\Restaurante\\Sistema de Restaurante\\Restaurante.mdf;Integrated Security=True");
            con.Open();
            string sql = "SELECT COUNT(*) as pedidos FROM Pedidos WHERE status='Aberto' AND IdAtendente!='" + atendente + "' AND mesa != 'Delivery'";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            if ((int)dr["pedidos"] == pedidos)
            {
                return "não";
            }
            else
            {
                return "sim";
            }
        }
        //---------------------------------------------------------------

        //Home Caixa
        public static string CountPedidosCaixa(int pedidos)
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Programas\\Restaurante\\Sistema de Restaurante\\Restaurante.mdf;Integrated Security=True");
            con.Open();
            string sql = "SELECT COUNT(*) as pedidos FROM Pedidos WHERE status='Aberto' AND mesa != 'Delivery' ";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            if ((int)dr["pedidos"] == pedidos)
            {
                return "não";
            }
            else
            {
                return "sim";
            }
        }
        //------------------------------------------------------------------------------

        //Delivery
        public static string CountPedidosDelivery(int pedidos)
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Programas\\Restaurante\\Sistema de Restaurante\\Restaurante.mdf;Integrated Security=True");
            con.Open();
            string sql = "SELECT COUNT(*) as pedidos FROM Pedidos WHERE status='Aberto' AND mesa='Delivery'";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            if ((int)dr["pedidos"] == pedidos)
            {
                return "não";
            }
            else
            {
                return "sim";
            }
        }

        //Registros
        public static string CountPronto(int PProntos, int IdPedido)
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Programas\\Restaurante\\Sistema de Restaurante\\Restaurante.mdf;Integrated Security=True");
            con.Open();
            string sql = "SELECT COUNT(*) as Pronto FROM Pedidos INNER JOIN PedidosPratosProdutos ON Pedidos.IdPedido = PedidosPratosProdutos.IdPedido INNER JOIN PratosProdutos ON PedidosPratosProdutos.IdPratoProduto = PratosProdutos.IdPratoProduto WHERE PedidosPratosProdutos.status='Pronto' AND cozinha='S' AND Pedidos.status = 'Aberto' AND Pedidos.IdPedido = '"+IdPedido+"'";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if ((int)dr["Pronto"] == PProntos)
                {
                    con.Close();
                    return "não";
                }
                else
                {
                    con.Close();
                    return "sim";
                }
            }
            else
            {
                if (PProntos == 0)
                {
                    con.Close();
                    return "não";
                }
                else
                {
                    con.Close();
                    return "sim";
                }
            }
        }

        public static string VerPronto(int IdPedido)
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Programas\\Restaurante\\Sistema de Restaurante\\Restaurante.mdf;Integrated Security=True");
            con.Open();
            string sql = "SELECT COUNT(*) as Pronto FROM Pedidos INNER JOIN PedidosPratosProdutos ON Pedidos.IdPedido = PedidosPratosProdutos.IdPedido INNER JOIN PratosProdutos ON PedidosPratosProdutos.IdPratoProduto = PratosProdutos.IdPratoProduto WHERE PedidosPratosProdutos.status='Pronto' AND cozinha='S' AND Pedidos.status = 'Aberto' AND Pedidos.IdPedido = '" + IdPedido + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            if ((int)dr["Pronto"] > 0)
            {
                con.Close();
                return "sim";
            }
            else
            {
                con.Close();
                return "não";
            }
        }
    }
}
