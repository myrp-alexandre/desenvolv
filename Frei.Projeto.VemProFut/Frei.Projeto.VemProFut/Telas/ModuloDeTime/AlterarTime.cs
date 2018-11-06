﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Frei.Projeto.VemProFut.Utilitarios;
using Frei.Projeto.VemProFut.DB.Time;
using Frei.Projeto.VemProFut.Utilitarios.ImagenPlugin;

namespace Frei.Projeto.VemProFut.Telas.ModuloDeTime
{
    public partial class AlterarTime : UserControl
    {
        public AlterarTime()
        {
            InitializeComponent();
        }

        public void CarregarCampos(string idTime)
        {
            TimeBusiness business = new TimeBusiness();
            List<TimeViewDTO> times = business.ConsultarporId(Convert.ToInt32(idTime));
            TimeViewDTO time = times[0];

            txtnome.Text = time.nm_nomeclube;
            txtidade.Text = time.nm_nome_mascara;
            txtbairro.Text = time.br_bairro;
            txtcidade.Text = time.cd_cidade;
            txtcomplemento.Text = time.cp_complemento_endereco;
            txtnumerocasa.Text = time.nr_numero;
            txtobservacoes.Text = time.obs_onservacoes;
            txtcomplemento.Text = time.cp_complemento_endereco;
            mktrg.Text = time.cn_cnpj;
            txtaltura.Text = time.so_site_oficial;
            mkttelefone.Text = time.tf_telefone_fixo;
            mktcelular.Text = time.tl_celular;
            dtpdatacadastro.Text = time;
            txtposicao.Text = time.fd_fundadores;
            pbfotoTime.Image = ImagemPlugin.ConverterParaImagem();
            txtpais.Text = time.ps_pais;
            mktcep.Text = time.cp_cep;
            txtrua.Text = time.ra_rua;
            


        }

        private void btnBuscarLg_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFile = new OpenFileDialog();
                DialogResult result = openFile.ShowDialog();

                if (result == DialogResult.OK)
                {
                    pbfotoTime.ImageLocation = openFile.FileName;
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("ERRO!\n " + erro.Message,
                                "Back's",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            APICorreios correios = new APICorreios();
            CorreiosDTO dto = correios.CEPDADOS(mktcep.Text);
            txtuf.Text = dto.UF;
            txtcidade.Text = dto.Cidade;
            txtbairro.Text = dto.Bairro;
            txtrua.Text = dto.Rua;
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            TimeDTO dto = new TimeDTO();
            dto.br_bairro = txtbairro.Text;
            dto.cd_cidade = txtcidade.Text;
            dto.cp_cep = Convert.ToInt32(mktcep.Text);
            dto.cn_cnpj = Convert.ToInt32(mktrg.Text);
            dto.cp_complemento_endereco = txtcomplemento.Text;
            dto.dt_data_cadastro = dtpdatacadastro.Text;
            dto.em_email = txtapelido.Text;
            dto.so_site_oficial = txtaltura.Text;
            dto.tf_telefone_fixo = Convert.ToInt32(mkttelefone.Text);
            dto.tl_celular = Convert.ToInt32(mktcelular.Text);
            dto.fd_fundadores = txtposicao.Text;
            dto.lg_logo = ImagemPlugin.ConverterParaString(pbfotoTime.Image);
            dto.nm_estadio = txtpedo.Text;
            dto.nm_nomeclube = txtnome.Text;
            dto.nm_nome_mascara = txtcidade.Text;
            dto.nr_numero = Convert.ToInt32(txtnumerocasa.Text);
            dto.obs_onservacoes = txtobservacoes.Text;
            dto.ps_pais = txtpais.Text;
            dto.ra_rua = txtrua.Text;
            dto.tf_telefone_fixo = 

            TimeBusiness business = new TimeBusiness();
            business.Alterar(dto);
        }
    }
}
