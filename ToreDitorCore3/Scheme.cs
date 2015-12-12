using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using HyperTomlProcessor;

namespace ToreDitorCore
{
    public class Scheme
    {
        private static Scheme _instance = null;
        public static Scheme GetInstance() {
            _instance = _instance ?? new Scheme();
            return _instance;
        }

        public Scheme()
        {
            this.Static = DynamicToml.CreateTable();
        }

        public Schemes.Dynamic Dynamic = new Schemes.Dynamic();

        private dynamic _static;
        public dynamic Static
        {
            get
            {
                return this._static;
            }
            set
            {
                this._static = value;

                if (this._static.IsDefined("appearance"))
                {
                    if (this._static.appearance.IsDefined("theme"))
                    {
                        this.Dynamic.CurrentTheme = this.Themes[this._static.appearance.theme];

                        if (this._static.appearance.IsDefined("theme-side")) {
                            this.Dynamic.CurrentStyle = this.Dynamic.CurrentTheme.Style[
                                Schemes.Theme.ThemeSide.FromString(this._static.appearance["theme-side"])
                            ];
                        } else
                        {
                            this.Dynamic.CurrentStyle = this.Dynamic.CurrentTheme.Style[Schemes.Theme.ThemeSide.Light];
                        }

                        return;
                    }
                }

                this.Dynamic.CurrentTheme = new Schemes.Theme();
                this.Dynamic.CurrentStyle = this.Dynamic.CurrentTheme.Style[Schemes.Theme.ThemeSide.Light];
            }
        }
        public Schemes.Themes Themes = new Schemes.Themes();
    }
}
