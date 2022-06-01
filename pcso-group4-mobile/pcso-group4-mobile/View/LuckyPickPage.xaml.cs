using Newtonsoft.Json;
using pcso_group4_mobile.ViewModel;
using System.Collections.ObjectModel;
using System.Net.Http.Headers;
using System.Linq;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using pcso_group4_mobile.Model;


namespace pcso_group4_mobile.View;

public partial class LuckyPickPage : ContentPage
{

    public LuckyPickPage(LuckyPickViewModel luckyPickViewModel)
    {
        InitializeComponent();
        BindingContext = luckyPickViewModel;    
    }

}
