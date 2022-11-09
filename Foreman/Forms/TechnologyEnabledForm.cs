using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Foreman
{
    public partial class TechnologyEnabledForm : Form
    {
		private Dictionary<Button, bool> TechnologiesButtons;
		private readonly DataCache DCache;
		private const int MaxColumns = 14;
		private const int IconSize = 48;
		private static Color EnabledPackBGColor = Color.DarkGreen;
		private static Color DisabledPackBGColor = Color.DarkRed;

		private Dictionary<Item, double> sciPackSetEnabled;
		private Dictionary<Item, double> sciPackSetDisabled;
		public TechnologyEnabledForm(DataCache cache)
        {

            DCache = cache;

            InitializeComponent();


            IconList.Images.Clear();
            IconList.Images.Add(DataCache.UnknownIcon);
			TechnologiesButtons = new Dictionary<Button, bool>();
			sciPackSetEnabled = new Dictionary<Item, double>();
			sciPackSetDisabled = new Dictionary<Item, double>();

			PopulateTechnologyList();
        }

        public void PopulateTechnologyList()
        {
			int E = 0;
			int D = 0;
			int rowCount = (DCache.Technologies.Count / MaxColumns) + (DCache.Technologies.Count % MaxColumns > 0 ? 1 : 0);
			int columnCount = (DCache.Technologies.Count / rowCount) + (DCache.Technologies.Count % rowCount > 0 ? 1 : 0);
			for (int i = 0; i < columnCount; i++)
				TechnologyTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, IconSize));
			TechnologyTable.ColumnStyles.RemoveAt(0);
			TechnologyTable.ColumnCount = TechnologyTable.ColumnStyles.Count;
			for (int i = 0; i < rowCount; i++)
				TechnologyTable.RowStyles.Add(new RowStyle(SizeType.Absolute, IconSize));
			TechnologyTable.RowStyles.RemoveAt(0);
			TechnologyTable.RowCount = TechnologyTable.RowStyles.Count;


			TechnologyTable.Height = IconSize;
			
			DCache.SortTechnologies();

			foreach (Technology tech in DCache.TechnologiesSorted)
			{

				NFButton button = new NFButton();
				
				button.ForeColor = Color.Gray;
				button.BackgroundImageLayout = ImageLayout.Center;
				button.BackgroundImage = new Bitmap(tech.Icon, IconSize-4, IconSize-4);
				button.UseVisualStyleBackColor = false;
				button.FlatStyle = FlatStyle.Flat;
				button.FlatAppearance.BorderSize = 0;
				button.FlatAppearance.BorderColor = Color.Black;
				button.TabStop = false;
				button.Margin = new Padding(0);
				button.Size = new Size(1, 1);
				button.Dock = DockStyle.Fill;
				button.Tag = tech;
				button.Enabled = Enabled;
				button.BackColor = tech.Enabled ? EnabledPackBGColor : DisabledPackBGColor;
				button.MouseHover += new EventHandler(Button_MouseHover);
				button.MouseLeave += new EventHandler(Button_MouseLeave);
				button.Click += new EventHandler(Button_Click);

				TechnologyTable.Controls.Add(button);
				TechnologiesButtons.Add(button, tech.Enabled);
				if (tech.Enabled)
				{
					E++;
				} else { D++; }
				AddTechPacksToList(tech);
			}
			labelD.Text = "Disabled: " + D;
			foreach (Item item in sciPackSetDisabled.Keys)
			{
				labelD.Text += "\n\r";
				labelD.Text += item.LFriendlyName + ": " + String.Format("{0:n0}", sciPackSetDisabled[item]);
			}
			labelE.Text = "Enabled: " + E;
			foreach (Item item in sciPackSetEnabled.Keys)
			{
				labelE.Text += "\n\r";
				labelE.Text += item.LFriendlyName + ": " + String.Format("{0:n0}", sciPackSetEnabled[item]);
			}

		}


		private void btnConfirm_Click(object sender, EventArgs e)
        {
            UpdateSettings();
            DialogResult = DialogResult.OK;
            this.Close();
        }

		private void UpdateSettings()
		{
			foreach (Button button in TechnologiesButtons.Keys)
			{
				Technology tech = (Technology)button.Tag;
				tech.Enabled = button.BackColor == EnabledPackBGColor ? true : false;
			}

			// recipes
			HashSet<DataObjectBase> EnabledRecipies = new HashSet<DataObjectBase>();
			foreach (Technology tech in DCache.Technologies.Values)
			{
				if (tech.Available && tech.Enabled)
				{
					EnabledRecipies.UnionWith(tech.UnlockedRecipes);
				}
			}
			foreach (Recipe rec in DCache.Recipes.Values)
			{
				rec.Enabled = false;
				if (EnabledRecipies.Contains(rec))
					rec.Enabled = true;
			}

			// assemblers
			// if you can produce assembler - you can use it
			foreach (Assembler assembler in DCache.Assemblers.Values)
			{
				bool enabled = false;
				foreach (Recipe rec in DCache.Recipes.Values)
					if (rec.Enabled)
					{
						foreach (Item item in rec.ProductList)
						{
							if (item.Name == assembler.Name)
							{
								enabled = true;
								break;
							}
						};
					}

				assembler.Enabled = enabled;
			}

			//modules
			foreach (Module module in DCache.Modules.Values)
			{
				bool enabled = false;
				foreach (Recipe rec in DCache.Recipes.Values)
					if (rec.Enabled)
					{
						foreach (Item item in rec.ProductList)
						{
							if (item.Name == module.Name)
							{
								enabled = true;
								break;
							}
						};
					}

				module.Enabled = enabled;
			}

			//beacon
		}

		private void Button_Click(object sender, EventArgs e)
		{
			Button techButton = (Button)sender;
			Technology tech = techButton.Tag as Technology;
			bool enabled = !TechnologiesButtons[techButton];
			TechnologiesButtons[techButton] = enabled;
			techButton.BackColor = enabled ? EnabledPackBGColor : DisabledPackBGColor;
		}

		private void Button_MouseHover(object sender, EventArgs e)
		{
			Control control = (Control)sender;
			if (control.Tag is DataObjectBase dob)
			{
				ToolTip.SetText(dob.FriendlyName);
				ToolTip.Show(this, Point.Add(PointToClient(Control.MousePosition), new Size(15, 5)));
			}
		}

		private void Button_MouseLeave(object sender, EventArgs e)
		{
			ToolTip.Hide((Control)sender);
		}

		public void AddTechPacksToList(Technology tech)
		{
			foreach (Item pack in tech.SciPackSet.Keys)
			{
				if (tech.Enabled)
				{
					if (sciPackSetEnabled.ContainsKey(pack))
						sciPackSetEnabled[pack] += (tech.SciPackSet[pack] * tech.ResearchCost);
					else
					{
						sciPackSetEnabled.Add(pack, (tech.SciPackSet[pack] * tech.ResearchCost));
					}
				}
				else 
				{
					if (sciPackSetDisabled.ContainsKey(pack))
						sciPackSetDisabled[pack] += (tech.SciPackSet[pack] * tech.ResearchCost);
					else
					{
						sciPackSetDisabled.Add(pack, (tech.SciPackSet[pack] * tech.ResearchCost));
					}
				}
			}
		}
	}
}
