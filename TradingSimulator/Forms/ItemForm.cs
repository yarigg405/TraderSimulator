﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TradingSimulator.Classes;

namespace TradingSimulator.Forms
{
    public partial class ItemForm : Form
    {
        public Item item;

        public ItemForm(Item item)
        {
            InitializeComponent();
            this.item = item;

            LoadForm();
        }

        private void LoadForm()
        {
            LoadComboBox();

            itemName.Text = item.name;
            rarityNumericUpDown.Value = item.rarity;

            if (item.Category != null)
                categoryComboBox.SelectedItem = item.Category;



        }

        private void LoadComboBox()
        {
            var context = Program.dataBase;
            foreach (var category in context.itemCategories)
            {
                categoryComboBox.Items.Add(category);
            }


        }






        private void itemName_TextChanged(object sender, EventArgs e)
        {
            item.name = itemName.Text;
        }

        private void rarityNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            item.rarity = (int)rarityNumericUpDown.Value;
        }

        private void categoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            item.Category = (ItemCategory)categoryComboBox.SelectedItem;
        }



        private void okButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
