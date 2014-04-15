using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Configuration;
using System.Net;

namespace Leads_App
{
    public partial class Form1 : Form
    {
        DAL objDal = new DAL();
        public int varexit = 0;
        public int varcount = 0;
        DateTime sdate = DateTime.Now;
        DateTime edate = DateTime.Now.AddDays(-2);TimeSpan ts = new TimeSpan(0, 0, 0);
        Boolean stopclo = true; Boolean stopcld = true; Boolean stopclrv = true; Boolean stopcars = true; Boolean stopcarposts = true;
        public int SessionStateid = 0;
        string content = string.Empty;
        public Form1()
        {            
            InitializeComponent();
            sdate = sdate.Date + ts;
            edate = edate.Date + ts;
        }
        #region AutoTrades_CA
        private void getLeadsAutoTrades_CA()
        {

            int urlNums = 100;
            int a = 1, b = 0;



            ////  mainURL = "http://" + CStatesNames.SelectedItem + ".craigslist.org/cgi-bin/autos.cgi?&category=cta/";



            string sURL = string.Empty;


            for (int j = 1; j <= urlNums; j++)
            {
                b = (j - 1) * 25;
                string URl = string.Empty;
                //b=1975 Ontario  a==1
                //b=1200   a==1 Yukon
                if (cmbAutoCA.Text == "British Columbia")
                {

                    //URl = "http://www.autotrader.ca/a/pv/Used/all/all/all/?cat2=7&lloc=British+Columbia&cty=Vancouver&prv=British+Columbia&";
                    //URl = URl + "ctr=Canada&vpt=49.0673013708205%2c-123.50711590917%2c49.4535738591128%2c-122.721012424493%2c&dftC=True&rprv=True";
                    //URl = URl + "&pRng=4000%2c&adtype=Private&hprc=True&st=" + a + "&rcs=" + b + "";

                    URl = "  http://www.autotrader.ca/a/pv/Used/all/all/all/?cat2=7&lloc=British+Columbia&cty=V";
                    URl = URl + "  ancouver&prv=British+Columbia&ctr=Canada&vpt=49.0673013708205%2c-123.50711590917%2c49.4535738591128%2c-122.7210124";
                    URl = URl + " 24493%2c&dftC=True&rprv=True&pRng=4000%2c&adtype=Private&hprc=True&st=" + a + "&rcs=" + b + "";
                }
                else if (cmbAutoCA.Text == "Alberta")
                {

                    URl = "http://www.autotrader.ca/a/pv/Used/all/all/all/?cat2=7&lloc=Alberta&cty=Calgary&prv=Alberta&ctr=Canada&vpt=50.85";
                    URl = URl + "19000273506%2c-114.471113982568%2c51.2381725156429%2c-113.655319163647%2c&dftC=True&rprv=True&pRng=4000%2c&adtype=Private&hprc=";
                    URl = URl + "True&st=" + a + "&rcs=" + b + "";
                }
                else if (cmbAutoCA.Text == "Manitoba")
                {

                    URl = "www.autotrader.ca/a/pv/Used/all/all/all/?cat2=7&lloc=Manitoba&cty=Winnipeg&prv=Manitoba&ctr=Canada&vpt=49.706361";
                    URl = URl + "1903236%2c-97.5389035793473%2c50.0926336786159%2c-96.7425078897288%2c&dftC=True&rprv=True&pRng=4000%2c&adtype=Private&hprc=True";
                    URl = URl + "&st=" + a + "&rcs=" + b + "";
                }
                else if (cmbAutoCA.Text == "Ontario")
                {
                    URl = "  http://www.autotrader.ca/a/pv/Used/all/all/all/?cat2=7&lloc=Ontario&cty=";
                    URl = URl + "   Toronto&prv=Ontario&ctr=Canada&vpt=43.4168299973413%2c-79.8107645429352%2c43.8803573695361%2c-";
                    URl = URl + "      78.959906034976%2c&dftC=True&rprv=True&pRng=4000%2c&adtype=Private&hprc=True&st=" + a + "&rcs=" + b + "";
                    //URl = "www.autotrader.ca/a/pv/Used/all/all/all/?cat2=7&lloc=Ontario&cty=Toronto&prv=Ontario&ctr=Canada&vpt=43.416829997";
                    //URl = URl + "3413%2c-79.8107645429352%2c43.8803573695361%2c-78.959906034976%2c&dftC=True&rprv=True&pRng=4000%2c&adtype=Private&hprc=True&st=";
                    //URl = URl + "" + a + "&rcs=" + b + "";
                }
                else if (cmbAutoCA.Text == "Yukon")
                {

                    URl = "     http://www.autotrader.ca/a/pv/Used/all/all/all/?cat2=7&lloc=YUKON&cty=:";
                    URl = URl + "       Whitehorse&ctr=Canada&vpt=60.6648982323266%2c-135.205612854466%2c60.7769170596323%2c-1";
                    URl = URl + "       34.900747534535%2c&dftC=True&rprv=True&pRng=4000%2c&adtype=Private&hprc=True&st=" + a + "&rcs=" + b + "";

                    //URl = "www.autotrader.ca/a/pv/Used/all/all/all/?cat2=7&lloc=Yukon&cty=Whitehorse&ctr=Canada&vpt=60.6648982323266%2c-135";
                    //URl = URl + ".205612854466%2c60.7769170596323%2c-134.900747534535%2c&dftC=True&rprv=True&pRng=4000%2c&hprc=True&st=&st=" + a + "&rcs=" + b + "";

                }
                else if (cmbAutoCA.Text == "Saskatchewan")
                {


                    URl = "     http://www.autotrader.ca/a/pv/Used/all/all/all/?cat2=7&lloc=YUKON&cty=:";
                    URl = URl + "       Whitehorse&ctr=Canada&vpt=60.6648982323266%2c-135.205612854466%2c60.7769170596323%2c-1";
                    URl = URl + "       34.900747534535%2c&dftC=True&rprv=True&pRng=4000%2c&adtype=Private&hprc=True&st=" + a + "&rcs=" + b + "";


                    //URl = "www.autotrader.ca/a/pv/Used/all/all/all/?cat2=7&lloc=Saskatchewan&cty=Regina&prv=Saskatchewan&ctr=Canada&vpt=50.";
                    //URl = URl + "312902988279%2c-104.877451716832%2c50.5832934689313%2c-104.312896672548%2c&dftC=True&rprv=True&pRng=4000%2c&adtype=Private&hprc";
                    //URl = URl + "=True&st=" + a + "&rcs=" + b + "";
                }


                FillCurrentPageData(URl);
                String str = string.Empty;

                //Regex regexindividualURL = new Regex("<div class=\"used_result_container premium_result\">(.*?)</div>");
                //System.Collections.ArrayList individualCararraylistURL = new System.Collections.ArrayList();
                //str = content;
                //str = content.Replace('\n', ' ');
                //System.Text.RegularExpressions.MatchCollection regexindividualCollecURL = null;
                //regexindividualCollecURL = regexindividualURL.Matches(str);
                //individualCararraylistURL.Clear();
                //individualCararraylistURL.InsertRange(individualCararraylistURL.Count, regexindividualCollecURL);

                Regex regexmileageColumn = new Regex("<div class=\"at_infoAndPriceArea at_marginL\">(.*?)</div>");
                System.Collections.ArrayList individualCarmileageColumnarraylist = new System.Collections.ArrayList();
                str = content;
                str = content.Replace('\n', ' ');
                System.Text.RegularExpressions.MatchCollection regexmileageColumn1 = null;
                regexmileageColumn1 = regexmileageColumn.Matches(str);
                individualCarmileageColumnarraylist.Clear();
                individualCarmileageColumnarraylist.InsertRange(individualCarmileageColumnarraylist.Count, regexmileageColumn1);


                for (int x = 0; x < individualCarmileageColumnarraylist.Count; x++)
                {
                    string mainURL = ConfigurationManager.AppSettings["MainUrl_AutoTraders_Ca"].ToString();
                    string snextURl = individualCarmileageColumnarraylist[x].ToString();
                    snextURl = snextURl.Substring(snextURl.IndexOf("href="), snextURl.IndexOf("</a>") - snextURl.IndexOf("href="));
                    snextURl = snextURl.Replace("href=", "");
                    snextURl=snextURl.Substring(0,snextURl.IndexOf('>'));
                    snextURl = snextURl.Replace("&amp;", "&");
                    snextURl = snextURl.Replace("'", "");
                    char[] sep = { '=' };
                    string[] sSplit = snextURl.Split(sep);
                    string subURL = string.Empty;
                    subURL = sSplit[2].Replace("id", "");
                    subURL = subURL.Replace("\"", "");



                    mainURL = mainURL + subURL;

                    //FillCurrentPageData(mainURL);
                    FillCurrentPageData(snextURl);

                    System.Collections.ArrayList Sellerlist = new System.Collections.ArrayList();
                    Regex regexobjSellerInfo = new Regex("<div class=\"cs_phone\">(.*?)</div>");
                    str = content;
                    str = content.Replace('\n', ' ');
                    System.Text.RegularExpressions.MatchCollection regexSellerlist = null;
                    regexSellerlist = regexobjSellerInfo.Matches(str);
                    Sellerlist.Clear();
                    Sellerlist.InsertRange(Sellerlist.Count, regexSellerlist);

                    string Phone = string.Empty;

                    if (Sellerlist.Count != 0)
                    {


                        Phone = Sellerlist[0].ToString();
                    }



                    char[] sepPhone = { '>' };

                    string[] sSplitPhone = Phone.Split(sep);
                    if (sSplitPhone.Length > 4)
                    {



                        Phone = sSplitPhone[8].ToString();

                        Phone = Phone.Replace("display:none;float:left;padding-top:4px;padding-right:5px;color:#488E48", "");
                        Phone = Phone.Replace("<strong>", "");
                        Phone = Phone.Replace("</strong></span>", " ");
                        Phone = Phone.Replace(" <span style", "");
                        Phone = Phone.Replace(">", "");
                        Phone = Phone.Replace("\"", " ");
                        Phone = Phone.Replace("\r", " ");
                        // Phone = Phone.Replace("            ", " ");

                        System.Collections.ArrayList Sellerlistdescription = new System.Collections.ArrayList();
                        Regex regexobjdescriptionInfo = new Regex("<span itemprop=\"name\">(.*?)</div>");
                        str = content;
                        str = content.Replace('\n', ' ');
                        System.Text.RegularExpressions.MatchCollection regexdescriptionlist = null;
                        regexdescriptionlist = regexobjdescriptionInfo.Matches(str);
                        Sellerlistdescription.Clear();
                        Sellerlistdescription.InsertRange(Sellerlistdescription.Count, regexdescriptionlist);

                        string description = Sellerlistdescription[0].ToString();
                        description = description.Replace("<span itemprop=\"name\">", "");
                        description = description.Replace("<h1 class=\"title_matchPageSize\" style=\"width: 480px; display: inline;\">", "");
                        description = description.Replace("</span></div>", "");
                        description = description.Replace("\r", "");
                        description = description.Replace("</h1>", "");



                        System.Collections.ArrayList SellerlistPrice = new System.Collections.ArrayList();
                        Regex regexobjPriceInfo = new Regex("<span itemprop=\"offer\">(.*?)</span>");
                        str = content;
                        str = content.Replace('\n', ' ');
                        System.Text.RegularExpressions.MatchCollection regexPricelist = null;
                        regexPricelist = regexobjPriceInfo.Matches(str);
                        SellerlistPrice.Clear();
                        SellerlistPrice.InsertRange(SellerlistPrice.Count, regexPricelist);

                        string Price = SellerlistPrice[0].ToString();
                        Price = Price.Replace("<span itemprop=\"offer\">", "");
                        Price = Price.Replace("<span id=\"ctl00_PageContentPlaceHolder_financing_lblPriceValue\"", "");
                        Price = Price.Replace("class=\"loadfinancing_green_text\">", "");
                        Price = Price.Replace("</span>", "");
                        Price = Price.Replace("\r", "");

                        System.Collections.ArrayList SellerlistYear = new System.Collections.ArrayList();
                        Regex regexobjYearInfo = new Regex("<td style=\"width:50%;\">(.*?)</span>");
                        str = content;
                        str = content.Replace('\n', ' ');
                        System.Text.RegularExpressions.MatchCollection regexYearlist = null;
                        regexYearlist = regexobjYearInfo.Matches(str);
                        SellerlistYear.Clear();
                        SellerlistYear.InsertRange(SellerlistYear.Count, regexYearlist);

                        string year = SellerlistYear[0].ToString();
                        year = year.Replace("<td style=\"width:50%;\">", "");
                        year = year.Replace("<strong>Year: </strong>", "");
                        year = year.Replace("<strong>Make: </strong><span itemprop=\"brand\">Dodge</span>", "");
                        year = year.Replace("</td>", "");
                        year = year.Replace("\r", "");
                        year = year.Replace(" <strong>Make: </strong><span itemprop=\"brand\">", "");
                        year = year.Replace("</span>", "");

                        char[] sep1 = { '/' };

                        string[] sSplit1 = mainURL.Split(sep1);

                        string CarId = sSplit1[8].ToString();

                        objDal.SaveLead_Autotrades_CA(Phone, Price, year, description, cmbAutoCA.Text.ToString(), mainURL, CarId);

                    }

                }

            }
        }
        #endregion
        #region Cars.com
        private void GetLeadsFromCarsSite( string state,string zipcode)
        {
            varcount = 0;
            string year = ""; string make = ""; string description = ""; string seller = ""; string phno = ""; string price = ""; string mileage = "";
            int result = 1;
            int a = 0, b = 0; int year1 = 0;
            string mainURL = ConfigurationManager.AppSettings["MainURLCarsSite"].ToString();
            string sURL = string.Empty;

            string resurl = "http://www.cars.com/for-sale/used/_/N-ma9Zm5d?PMmt=0-0-0&crSrtFlds=stkTypId-feedSegId&feedSegId=28705";
            resurl = resurl + "&isDealerGrouping=false&rd=30&rpp=250&sf1Dir=DESC&sf1Nm=price&sf2Dir=ASC&sf2Nm=miles&rn=" + a + "";
            resurl = resurl + "&stkTypId=28881&zc=" + txtZipCars.Text + "&slrTypeId=28879&searchSource=GN_REFINEMENT";
            FillCurrentPageData(resurl);
            String resstr = string.Empty;
            Regex restest = new Regex("<div class=\"listingsResultNumber\" id=\"sp_lrn\">(.*?)</div>");
            System.Collections.ArrayList restestlist = new System.Collections.ArrayList();
            resstr = content;
            resstr = content.Replace('\n', ' ');
            System.Text.RegularExpressions.MatchCollection restestmatch = null;
            restestmatch = restest.Matches(resstr);
            restestlist.Clear();
            restestlist.InsertRange(restestlist.Count, restestmatch);
            if (restestlist.Count > 0)
            {
                string results = restestlist[0].ToString();
                results = Regex.Replace(results, @"\<.+?\>", "");
                results = results.Substring(results.IndexOf("of"));
                if(results.IndexOf("Vehicles") != -1)
                    results = results.Substring(0, results.IndexOf("Vehicles"));
                else
                    results = results.Substring(0, results.IndexOf("Vehicle"));
                results = results.Replace("of", "").Trim();
                result = Convert.ToInt32(results);
                result = (result / 250) + 1;
                if (result > 19)
                    result = 19;
                else if (result < 1)
                    result = 1;
            }
            try
            {
                if (stopcars)
                {
                    for (int j = 1; j <= result; j++)
                    {
                        a = (j - 1) * 250;
                        if (txtZipCars.Text.Length == 4)
                        {
                            txtZipCars.Text = "0" + txtZipCars.Text;
                        }
                        //string sURL1 = "http://www.cars.com/for-sale/searchresults.action?sf1Dir=DESC&prMn=4000";
                        //sURL1 = sURL1 + "&rd=100000&zc=" + txtZipCars.Text + "&rd=30&PMmt=0-0-0&stkTypId=28881&slrTypeId=28879&sf2Dir=ASC";
                        //sURL1 = sURL1 + "&sf1Nm=price&sf2Nm=miles&rpp=250&feedSegId=28705&searchSource=UTILITY&crSrtFlds=stkTypId-feedSegId";
                        //sURL1 = sURL1 + "-pseudoPrice-slrTypeId&pgId=2102&rn=" + a + "";

                        //string sURL1 = "http://www.cars.com/for-sale/used/_/N-ma9Zm5d?feedSegId=28705&rpp=250&sf2Nm=miles&sf1Nm=price&sf2Dir=ASC";
                        //sURL1 = sURL1 + "&stkTypId=28881&PMmt=0-0-0&zc=" + txtZipCars.Text + "&rd=30&sf1Dir=DESC&searchSource=UTILITY";
                        //sURL1 = sURL1 + "&crSrtFlds=stkTypId-feedSegId&pgId=2102&rn=" + a + "";

                        string sURL1 = "http://www.cars.com/for-sale/used/_/N-ma9Zm5d?PMmt=0-0-0&crSrtFlds=stkTypId-feedSegId&feedSegId=28705";
                        sURL1 = sURL1 + "&isDealerGrouping=false&rd=30&rpp=250&sf1Dir=DESC&sf1Nm=price&sf2Dir=ASC&sf2Nm=miles&rn=" + a + "";
                        sURL1 = sURL1 + "&stkTypId=28881&zc=" + txtZipCars.Text + "&slrTypeId=28879&searchSource=GN_REFINEMENT";
                        FillCurrentPageData(sURL1);
                        String str = string.Empty;
                        Regex test = new Regex("<div class=\"row vehicle\"(.*?)>(.*?)</div>(.*?)</div>(.*?)</div>(.*?)</div>(.*?)</div>(.*?)</div>");
                        System.Collections.ArrayList testlist = new System.Collections.ArrayList();
                        str = content;
                        str = content.Replace('\n', ' ');
                        System.Text.RegularExpressions.MatchCollection testmatch = null;
                        str = str.Substring(str.IndexOf("<div class=\"col38 no-padding\" id=\"resultswrapper\">"));
                        testmatch = test.Matches(str);
                        testlist.Clear();
                        testlist.InsertRange(testlist.Count, testmatch);
                        if (stopcars)
                        {
                            for (int i = 0; i < testlist.Count; i++)
                            {
                                if (stopcars)
                                {
                                    string url1 = "";
                                    string all = testlist[i].ToString();
                                    //all=Regex.Replace(description, @"\<.+?\>", "");
                                    all = all.Replace("&amp;", "&");
                                    all = all.Substring(all.IndexOf("<a name=\"&lid=md-ymmt\""));
                                    string url = all.Substring(0, all.IndexOf(">"));
                                    all = all.Replace(url, "");
                                    url = url.Replace("<a name=\"&lid=md-ymmt\" rel=\"nofollow\" href=\"", "");
                                    url = url.Replace("\"", "");
                                    string carid = url.Substring(url.IndexOf("listingId="));
                                    carid = carid.Substring(0, carid.IndexOf("&"));
                                    carid = carid.Replace("listingId=", "").Trim();
                                    url1 = "www.cars.com" + url;
                                    all = all.Replace("\r", "");

                                    if (all.Contains("<span class=\"modelYearSort\">"))
                                    {
                                        year = all.Substring(0, all.IndexOf("</span>"));
                                        year = year.Replace("<span class=\"modelYearSort\">", "");
                                        year = year.Replace(">", "").Trim();
                                        all = all.Substring(all.IndexOf(year + "</span>"));
                                        year1 = Convert.ToInt32(year);
                                    }
                                    else year = "";
                                    if (all.Contains("<span class=\"mmtSort\">"))
                                    {
                                        all = all.Substring(all.IndexOf("<span class=\"mmtSort\">"));
                                        make = all.Substring(0, all.IndexOf("</span>"));
                                        make = Regex.Replace(make, @"\<.+?\>", "").Trim();
                                        make = year + make;
                                    }
                                    else make = "";
                                    if (all.Contains("<p class=\"description\">"))
                                    {
                                        all = all.Substring(all.IndexOf("<p class=\"description\">"));
                                        description = all.Substring(0, all.IndexOf("</p>"));
                                        description = Regex.Replace(description, @"\<.+?\>", "").Trim();
                                    }
                                    else description = "";
                                    if (all.Contains("<div class=\"seller\">"))
                                    {
                                        all = all.Substring(all.IndexOf("<div class=\"seller\">"));
                                        seller = all.Substring(0, all.IndexOf("</p>"));
                                        seller = Regex.Replace(seller, @"\<.+?\>", "").Trim();
                                    }
                                    else seller = "";
                                    if (all.Contains("<span class=\"seller-phone\">"))
                                    {
                                        all = all.Substring(all.IndexOf("<span class=\"seller-phone\">"));
                                        all = all.Replace("<span class=\"seller-phone\">", "");
                                        phno = all.Substring(0, all.IndexOf("<"));
                                        phno = Regex.Replace(phno, @"\<.+?\>", "").Trim();
                                        phno = phno.Replace("(Mobile)", "");
                                        phno = phno.Replace("&nbsp;", "").Trim();
                                        phno = phno.Replace("-", "");
                                        string[] digits = Regex.Split(phno, @"\D+");
                                        string PhoneNumber = string.Empty;

                                        for (int p = 0; p < digits.Length; p++)
                                        {
                                            if ((digits[p].Length == 10))
                                            {
                                                phno = digits[p];
                                            }
                                        }
                                    }
                                    else phno = "";
                                    if (all.Contains("<span class=\"priceSort\">"))
                                    {
                                        all = all.Substring(all.IndexOf("<span class=\"priceSort\">"));
                                        price = all.Substring(0, all.IndexOf("</span>"));
                                        price = Regex.Replace(price, @"\<.+?\>", "").Trim();
                                    }
                                    else price = "";
                                    if (all.Contains("<span class=\"milesSort\">"))
                                    {
                                        all = all.Substring(all.IndexOf("<span class=\"milesSort\">"));
                                        mileage = all.Substring(0, all.IndexOf("</span>"));
                                        mileage = Regex.Replace(mileage, @"\<.+?\>", "").Trim();
                                    }
                                    else mileage = "";
                                    string State = cmbStatesCars.Text.ToString();
                                    string zip = txtZipCars.Text;
                                    if (phno != "")
                                    {
                                        //if (year1 > 1900 && year1 < 1991)
                                        //{
                                        //    objDal.SaveLead_CarsSite(phno, seller, price, make,"1", description, mileage, url1, State, carid, zip);
                                        //}
                                        //else
                                        objDal.SaveLead_CarsSite(phno, seller, price, make, description, mileage, url1, State, carid, zip);
                                    }
                                    varcount = varcount + 1;
                                    label2.Text = Convert.ToInt32(varcount).ToString();
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
            #region old


            //Regex regexindividualURL = new Regex("<a name=\"&lid=md-ymmt\" rel=\"nofollow\" (.*?)<span>");
            //System.Collections.ArrayList individualCararraylistURL = new System.Collections.ArrayList();
            ////str = testlist[i].ToString();
            //str = content.Replace('\n', ' ');
            //System.Text.RegularExpressions.MatchCollection regexindividualCollecURL = null;
            //regexindividualCollecURL = regexindividualURL.Matches(str);
            //individualCararraylistURL.Clear();
            //individualCararraylistURL.InsertRange(individualCararraylistURL.Count, regexindividualCollecURL);

            //Regex regexindividual = new Regex("<span class=\"priceSort\">(.*?)</span>");
            //System.Collections.ArrayList individualCararraylist = new System.Collections.ArrayList();
            //str = content;
            //str = content.Replace('\n', ' ');
            //System.Text.RegularExpressions.MatchCollection regexindividualCollec = null;
            //regexindividualCollec = regexindividual.Matches(str);
            //individualCararraylist.Clear();
            //individualCararraylist.InsertRange(individualCararraylist.Count, regexindividualCollec);

            //Regex regexindividualModel = new Regex("<span class=\"mmtSort\">(.*?)</span>");
            //System.Collections.ArrayList individualCararraylistModel = new System.Collections.ArrayList();
            //str = content;
            //str = content.Replace('\n', ' ');
            //System.Text.RegularExpressions.MatchCollection regexindividualCollecModel = null;
            //regexindividualCollecModel = regexindividualModel.Matches(str);
            //individualCararraylistModel.Clear();
            //individualCararraylistModel.InsertRange(individualCararraylistModel.Count, regexindividualCollecModel);

            //Regex regexmileageColumn = new Regex("<span class=\"milesSort\">(.*?)</span>");
            //System.Collections.ArrayList individualCarmileageColumnarraylist = new System.Collections.ArrayList();
            //str = content;
            //str = content.Replace('\n', ' ');
            //System.Text.RegularExpressions.MatchCollection regexmileageColumn1 = null;
            //regexmileageColumn1 = regexmileageColumn.Matches(str);
            //individualCarmileageColumnarraylist.Clear();
            //individualCarmileageColumnarraylist.InsertRange(individualCarmileageColumnarraylist.Count, regexmileageColumn1);

            //Regex regexvehicleDescription = new Regex("<p class=\"description\">(.*?)</p>");
            //System.Collections.ArrayList vehicleDescriptionCararraylist = new System.Collections.ArrayList();
            //str = content;
            //str = content.Replace('\n', ' ');
            //System.Text.RegularExpressions.MatchCollection regexvehicleDescriptionCollec = null;
            //regexvehicleDescriptionCollec = regexvehicleDescription.Matches(str);
            //vehicleDescriptionCararraylist.Clear();
            //vehicleDescriptionCararraylist.InsertRange(vehicleDescriptionCararraylist.Count, regexvehicleDescriptionCollec);

            //Regex regexvehicleDescription1 = new Regex("<span class=\"modelYearSort\">(.*?)</span>");
            //System.Collections.ArrayList vehicleDescriptionCararraylist1 = new System.Collections.ArrayList();
            //str = content;
            //str = content.Replace('\n', ' ');
            //System.Text.RegularExpressions.MatchCollection regexvehicleDescriptionCollec1 = null;
            //regexvehicleDescriptionCollec1 = regexvehicleDescription1.Matches(str);
            //vehicleDescriptionCararraylist1.Clear();
            //vehicleDescriptionCararraylist1.InsertRange(vehicleDescriptionCararraylist1.Count, regexvehicleDescriptionCollec1);

            //Regex regexsellerName = new Regex("<p class=\"seller-name\">(.*?)</p>");
            //System.Collections.ArrayList sellerNamelist = new System.Collections.ArrayList();
            //str = content;
            //str = content.Replace('\n', ' ');
            //System.Text.RegularExpressions.MatchCollection regexsellerName1 = null;
            //regexsellerName1 = regexsellerName.Matches(str);
            //sellerNamelist.Clear();
            //sellerNamelist.InsertRange(sellerNamelist.Count, regexsellerName1);


            ////<span class="seller-phone">
            //Regex regexsellerPhone11 = new Regex("<span class=\"seller-phone\">(.*?)</span>");
            //System.Collections.ArrayList sellerPhonelist1 = new System.Collections.ArrayList();
            //str = content;
            //str = content.Replace('\n', ' ');
            //System.Text.RegularExpressions.MatchCollection sellerPhonematch1 = null;
            //sellerPhonematch1 = regexsellerPhone11.Matches(str);
            //sellerPhonelist1.Clear();
            //sellerPhonelist1.InsertRange(sellerPhonelist1.Count, sellerPhonematch1);

            //for (int i = 0; i < testlist.Count; i++)
            //{

            //    string ModelYear = vehicleDescriptionCararraylist1[i].ToString();
            //    ModelYear = ModelYear.Replace("<span class=\"modelYearSort\">", "");
            //    ModelYear = ModelYear.Replace("</span>", "");


            //    string priceColumn = individualCararraylist[i].ToString();
            //    priceColumn = priceColumn.Replace("<span class=\"priceSort\">", "");
            //    priceColumn = priceColumn.Replace("</span>", "");

            //    string mileageColumn = individualCarmileageColumnarraylist[i].ToString();
            //    mileageColumn = mileageColumn.Replace("<span class=\"milesSort\">", "");
            //    //mileageColumn = mileageColumn.Replace("</div>", "");
            //    mileageColumn = mileageColumn.Replace(".</span>", "");

            //    string vehicleDescription = vehicleDescriptionCararraylist[i].ToString();
            //    vehicleDescription = vehicleDescription.Replace("<p class=\"description\">", "");
            //    vehicleDescription = vehicleDescription.Replace("<span class=\"exteriorColorSort\">", "");
            //    vehicleDescription = vehicleDescription.Replace("<span class=\"comma-sort\">", "");
            //    vehicleDescription = vehicleDescription.Replace("<span class=\"doorCountSort\">", "");
            //    vehicleDescription = vehicleDescription.Replace("<span class=\"driveTrainSort\">", "");
            //    vehicleDescription = vehicleDescription.Replace("<span class=\"bodyStyleNameSort\">", "");
            //    vehicleDescription = vehicleDescription.Replace("<span class=\"transmissionSort\">", "");
            //    vehicleDescription = vehicleDescription.Replace("<span class=\"period-sort\">", "");
            //    vehicleDescription = vehicleDescription.Replace("<span class=\"engineDescriptionSort\">", "");
            //    vehicleDescription = vehicleDescription.Replace("</span>", "");
            //    vehicleDescription = vehicleDescription.Replace("</p>", "");
            //    string sellerName = sellerNamelist[i].ToString();
            //    sellerName = sellerName.Replace("<p class=\"seller-name\">", "");
            //    sellerName = sellerName.Replace("<span class=\"\">", "");
            //    sellerName = sellerName.Replace("<span class=\"kind\">", "");
            //    sellerName = sellerName.Replace("<span class=\"seller-distance muted locationSort\">", "");
            //    sellerName = sellerName.Replace("</span>", "");
            //    sellerName = sellerName.Replace("</p>", "").Trim();
            //    sellerName = sellerName.Replace('\r', ' ').Trim();
            //    sellerName = sellerName.Replace('\t', ' ').Trim();

            //    string Model = individualCararraylistModel[i].ToString();
            //    Model = Model.Replace("<span class=\"mmtSort\">", "");
            //    Model = Model.Replace("</span>", "");
            //    Model = ModelYear + " " + Model;
            //    string State = cmbStatesCars.Text.ToString();

            //    string CarId = "";


            //    CarId = individualCararraylistURL[i].ToString();

            //    char[] sep = { '<' };

            //    string[] sSplit = CarId.Split(sep);



            //    int index = sSplit[1].IndexOf("href=");

            //    int Endindex = sSplit[1].IndexOf(">");

            //    string sMainUrl = sSplit[1].ToString().Substring(index, Endindex - index);



            //    sMainUrl = sMainUrl.Replace("href=", "");
            //    sMainUrl = mainURL + "" + sMainUrl;
            //    sMainUrl = sMainUrl.Replace("\"", "");
            //    sMainUrl = sMainUrl.Replace("amp;", "");


            //    FillCurrentPageData(sMainUrl);

            //    Regex regexsellerPhone = new Regex("<span class=\"data\">(.*?)</div>");
            //    System.Collections.ArrayList sellerPhoneCararraylist = new System.Collections.ArrayList();
            //    str = content;
            //    str = content.Replace('\n', ' ');
            //    System.Text.RegularExpressions.MatchCollection regexsellerPhone1 = null;
            //    regexsellerPhone1 = regexsellerPhone.Matches(str);
            //    sellerPhoneCararraylist.Clear();
            //    sellerPhoneCararraylist.InsertRange(sellerPhoneCararraylist.Count, regexsellerPhone1);
            //    if (sellerPhoneCararraylist.Count > 1)
            //    {
            //        sellerphone = sellerPhoneCararraylist[1].ToString();

            //        sellerphone = sellerphone.Replace("<", "&lt;");
            //        sellerphone = sellerphone.Replace(">", "&gt;");
            //        //sellerphone =//Convert the double quote
            //        sellerphone = sellerphone.Replace("\"", "&quot;");

            //        sellerphone = sellerphone.Replace(";&#48", "0");
            //        sellerphone = sellerphone.Replace(";&#49", "1");
            //        sellerphone = sellerphone.Replace(";&#50", "2");
            //        sellerphone = sellerphone.Replace(";&#51", "3");
            //        sellerphone = sellerphone.Replace(";&#52", "4");
            //        sellerphone = sellerphone.Replace(";&#53", "5");
            //        sellerphone = sellerphone.Replace(";&#54", "6");
            //        sellerphone = sellerphone.Replace(";&#55", "7");
            //        sellerphone = sellerphone.Replace(";&#56", "8");
            //        sellerphone = sellerphone.Replace(";&#57", "9");
            //        sellerphone = sellerphone.Replace(";&#45", "-");
            //        sellerphone = sellerphone.Replace("<div class=\"sellerPhone\">", "");
            //        sellerphone = sellerphone.Replace("</div>", "");
            //        sellerphone = sellerphone.Replace("&nbsp;", "");
            //        sellerphone = sellerphone.Replace(";", "");
            //    }

            //    string[] digits = Regex.Split(sellerphone, @"\D+");

            //    string PhoneNumber = string.Empty;

            //    for (int p = 0; p < digits.Length; p++)
            //    {
            //        if ((digits[p].Length == 3 && digits[p + 1].Length == 3 && digits[p + 2].Length == 4) || (digits[p].Length == 10))
            //        {
            //            if (digits[p].Length == 3 && digits[p + 1].Length == 3 && digits[p + 2].Length == 4)
            //            {
            //                PhoneNumber = digits[p] + digits[p + 1] + digits[p + 2];
            //            }
            //        }
            //    }

            //    string ListingID = string.Empty;
            //    int s = sMainUrl.IndexOf("istingId=");
            //    int k = sMainUrl.IndexOf("&listingRecNum");
            //    ListingID = sMainUrl.Substring(s, k - s);
            //    CarId = ListingID;
            //    CarId = CarId.Replace("istingId=", "");
            //    string zip = txtZipCars.Text;
            //    if (PhoneNumber != "")
            //    {
            //        objDal.SaveLead_CarsSite(PhoneNumber, sellerName, priceColumn, Model, vehicleDescription, mileageColumn, sMainUrl, State, CarId, zip);
            //        varcount = varcount + 1;
            //    }

            //    label2.Text = Convert.ToInt32(varcount).ToString();
            //}

            #endregion
        }
        #endregion Cars.com          
        #region craigslistLeads
        private void GetLeadsForcraigslist()
        {
            int urlNums = 10;
            int a = 0, b = 0;





            string mainURL = ConfigurationManager.AppSettings["MainUrlCraigslist"].ToString();

            //if (CCityNames.SelectedItem != null)
            //{
            //    mainURL = "http://" + CCityNames.SelectedItem + ".craigslist.org/cgi-bin/autos.cgi?&category=cta/";
            //}
            //else
            {
                mainURL = "http://" + cmbState.Text + ".craigslist.org/cto";
            }




            for (int j = 1; j <= urlNums; j++)
            {
                a = (j - 1) * 100;


                if (CCityNames.Text != "")
                {
                    if (a == 0)
                    {

                        mainURL = "http://" + CCityNames.Text + ".craigslist.org/search/cto?query=&srchType=T&minAsk=4000&maxAsk=";
                        //  http://abilene.craigslist.org/search/cto?query=&srchType=T&minAsk=4000&maxAsk=
                    }
                    else
                    {
                        mainURL = "http://" + CCityNames.Text + ".craigslist.org/search/cto?query=&srchType=T&minAsk=10000&maxAsk=&s=" + a + "";
                        //  http://abilene.craigslist.org/search/cto?query=&srchType=T&minAsk=4000&maxAsk=&s=100
                    }
                }
                else
                {
                    mainURL = "http://" + cmbState.Text + ".craigslist.org/search/cto?query=&srchType=T&minAsk=4000&maxAsk=";
                }
                FillCurrentPageData(mainURL);

                String str = string.Empty;


                Regex regexindividual = new Regex("<p class=\"row\">(.*?)</p>");



                System.Collections.ArrayList individualCararraylist = new System.Collections.ArrayList();
                str = content;
                str = content.Replace('\n', ' ');
                System.Text.RegularExpressions.MatchCollection regexindividualCollec = null;
                regexindividualCollec = regexindividual.Matches(str);
                individualCararraylist.Clear();
                individualCararraylist.InsertRange(individualCararraylist.Count, regexindividualCollec);

                for (int x = 0; x < individualCararraylist.Count; x++)
                {


                    string snextURl = individualCararraylist[x].ToString();

                    char[] sep = { '<' };

                    string[] sSplit = snextURl.Split(sep);

                    string subURL = string.Empty;
                    subURL = sSplit[4].Replace("a href=\"", "");
                    // .Split("href=".ToString());
                    int index = subURL.IndexOf(">");

                    int Endindex = sSplit[2].IndexOf(">");

                    string sMainUrl = subURL.ToString().Substring(0, index);


                    sMainUrl = sMainUrl.Replace("\"", "");

                    System.Collections.ArrayList Modellist = new System.Collections.ArrayList();

                    Regex regexobjState = new Regex("<font size=\"-1\">(.*?)</font>");
                    str = snextURl;
                    str = snextURl.Replace('\n', ' ');
                    System.Text.RegularExpressions.MatchCollection regexindividualModel = null;
                    regexindividualModel = regexobjState.Matches(str);
                    Modellist.Clear();
                    Modellist.InsertRange(Modellist.Count, regexindividualModel);

                    string sModel = sSplit[4];

                    index = sModel.IndexOf(">");

                    sModel = sModel.Substring(index, sModel.Length - index);

                    sModel = sModel.Replace(">", "");
                    sModel = sModel.Replace("-", "");


                    string sPrice = sSplit[5].Replace("/a> \t\t\t ", "");


                    FillCurrentPageData(sMainUrl);


                    Regex regexindividual1 = new Regex("<div id=\"userbody\">(.*?)</div>");



                    System.Collections.ArrayList individualCararraylist1 = new System.Collections.ArrayList();
                    str = content;
                    str = content.Replace('\n', ' ');
                    System.Text.RegularExpressions.MatchCollection regexindividualCollec1 = null;
                    regexindividualCollec1 = regexindividual1.Matches(str);
                    individualCararraylist1.Clear();
                    individualCararraylist1.InsertRange(individualCararraylist1.Count, regexindividualCollec1);

                    string vehicleDesc = string.Empty;
                    if (individualCararraylist1.Count != 0)
                    {

                        vehicleDesc = individualCararraylist1[0].ToString().Replace("<div id=\"userbody\">", "");

                        //vehicleDesc = vehicleDesc.Replace("<br><br><ul class=\"blurbs\"> <li> <!-- CLTAG GeographicArea=san angelo -->Location: san angelo <li>it's NOT ok to contact this poster with services or other commercial interests</ul> <!-- END CLTAGS -->\t\t<table summary=\"craigslist hosted images\"> \t\t\t<tr> \t\t\t\t<td align=\"center\"><img src=\"http://images.craigslist.org/5Z55W65P23nc3p73l9ba5c963ebbeb7f815c8.jpg\" alt=\"image 0\"></td> \t\t\t\t<td align=\"center\"><img src=\"http://images.craigslist.org/5O35Z55Q13ma3o13l3ba5781c2c967e7b1d99.jpg\" alt=\"image 1\"></td> \t\t\t</tr> \t\t\t<tr> \t\t\t\t<td align=\"center\"><img src=\"http://images.craigslist.org/5O35Y25R23n53m33laba51c82d73ac3d9146e.jpg\" alt=\"image 2\"></td> \t\t\t\t<td align=\"center\"><img src=\"http://images.craigslist.org/5O45P35X03m83pd3l2ba5d3be8335fad61282.jpg\" alt=\"image 3\"></td> \t\t\t</tr> \t\t</table>  </div>", "");

                        index = vehicleDesc.IndexOf("<table");
                        if (index != -1)
                        {
                            vehicleDesc = vehicleDesc.Substring(0, index);
                        }

                    }

                    string[] sPostingId = sMainUrl.Split('/');
                    string sPosting = string.Empty;

                    if (sPostingId.Length == 6)
                    {
                        sPosting = sPostingId[5].Replace(".html", "");
                    }
                    else if (sPostingId.Length == 5)
                    {

                        sPosting = sPostingId[4].Replace(".html", "");
                    }

                    string CollectedFromState = CCityNames.Text.ToString();

                    string sentence = vehicleDesc;
                    //
                    // Get all digit sequence as strings from data(Description).
                    //
                    string[] digits = Regex.Split(sentence, @"\D+");

                    string PhoneNumber = string.Empty;

                    for (int p = 0; p < digits.Length; p++)
                    {
                        if ((digits[p].Length == 3 && digits[p + 1].Length == 3 && digits[p + 2].Length == 4) || (digits[p].Length == 10))
                        {
                            if (digits[p].Length == 3 && digits[p + 1].Length == 3 && digits[p + 2].Length == 4)
                            {
                                PhoneNumber = digits[p] + digits[p + 1] + digits[p + 2];


                            }
                            else if (digits[p].Length == 10)
                            {

                                if (sPosting == PhoneNumber)
                                {
                                    PhoneNumber = "";
                                }
                                else
                                {
                                    PhoneNumber = digits[p];
                                }
                            }
                        }
                    }
                    vehicleDesc = vehicleDesc.Replace("http://", "");
                    vehicleDesc = vehicleDesc.Replace("<br>", "");
                    vehicleDesc = vehicleDesc.Replace("<", "");
                    vehicleDesc = vehicleDesc.Replace(">", "");
                    vehicleDesc = vehicleDesc.Replace("<a href=", "");
                    vehicleDesc = vehicleDesc.Replace("<li>", "");
                    vehicleDesc = vehicleDesc.Replace("/", "");

                    string CusEmailId = string.Empty;

                    System.Collections.ArrayList vehicleMainDesclist = new System.Collections.ArrayList();
                    Regex regexobjvehicleMain = new Regex("<div id=\"vehicle-info\">(.*?)</div>");
                    str = content;
                    str = content.Replace('\n', ' ');
                    System.Text.RegularExpressions.MatchCollection regexvehicleListMain = null;
                    regexvehicleListMain = regexobjvehicleMain.Matches(str);
                    vehicleMainDesclist.Clear();
                    vehicleMainDesclist.InsertRange(vehicleMainDesclist.Count, regexvehicleListMain);


                    if (vehicleMainDesclist.Count > 0)
                    {
                        CusEmailId = vehicleMainDesclist[0].ToString();

                        string[] EmailId = CusEmailId.Split('<');
                        CusEmailId = EmailId[2];
                        EmailId = CusEmailId.Split('>');
                        CusEmailId = EmailId[1];
                    }

                    //   objDal.SaveLead_Craigslist(sPrice, sModel, vehicleDesc, sMainUrl, sPosting, CollectedFromState, PhoneNumber, Convert.ToInt32(cmbState.SelectedValue.ToString()), cmbState.Text, CusEmailId);

                    varcount = varcount + 1;
                    label2.Text = Convert.ToInt32(varcount).ToString();


                }
            }
            MessageBox.Show("Leads Collected Successfully change another zipcode");

        }
        public void GetLeadsForcraigslist(string StateN, string CityN, int StateID)
        {
            varcount = 0;
            int urlNums = 26; int a = 0, b = 0; string Modellist1 = "";
            string sprice = ""; string sPosting = "  "; string CollectedFromState = "";
            string CusEmailId = ""; string date = ""; string year = ""; string yearCar = "";
            string mainURL = ConfigurationManager.AppSettings["MainUrlCraigslist"].ToString();
            {
                mainURL = "http://" + StateN + ".craigslist.org/cto";
            }
            if (stopclo)
            {
                for (int j = 0; j <= urlNums; j++)
                {
                    try
                    {
                        if (stopclo)
                        {

                            #region if
                            a = (j) * 100;
                            if (CCityNames.Text != "")
                            {
                                if (a == 0)
                                {
                                    mainURL = "http://" + CityN + ".craigslist.org/search/cto?query=&srchType=A&minAsk=2500";
                                    //  http://abilene.craigslist.org/search/cto?query=&srchType=T&minAsk=4000&maxAsk=
                                }
                                else
                                {
                                    mainURL = "http://" + CityN + ".craigslist.org/search/cto?query=&srchType=A&minAsk=2500&s=" + a + "";
                                    //  http://abilene.craigslist.org/search/cto?query=&srchType=T&minAsk=4000&maxAsk=&s=100
                                }
                            }
                            else
                            {
                                mainURL = "http://" + StateN + ".craigslist.org/search/cto?query=&srchType=T&minAsk=2500";
                            }
                            FillCurrentPageData(mainURL);
                            String str = string.Empty;

                            Regex regexindividual = new Regex("<span class=\"pl\">(.*?)</span>(.*?)</span>(.*?)</span>(.*?)</span>");
                            System.Collections.ArrayList individualCararraylist = new System.Collections.ArrayList();
                            str = content;
                            str = content.Replace('\n', ' ');
                            System.Text.RegularExpressions.MatchCollection regexindividualCollec = null;
                            regexindividualCollec = regexindividual.Matches(str);
                            individualCararraylist.Clear();
                            individualCararraylist.InsertRange(individualCararraylist.Count, regexindividualCollec);
                            if (individualCararraylist.Count > 0)
                            {
                                for (int x = 0; x < individualCararraylist.Count; x++)
                                {
                                    if (stopclo)
                                    {
                                        #region if
                                        Regex dateregex = new Regex("<span class=\"date\">(.*?)</span>");
                                        System.Collections.ArrayList datelist = new System.Collections.ArrayList();
                                        str = individualCararraylist[x].ToString();
                                        str = str.Replace('\n', ' ');
                                        System.Text.RegularExpressions.MatchCollection dateregexmatch = null;
                                        dateregexmatch = dateregex.Matches(str);
                                        datelist.Clear();
                                        datelist.InsertRange(datelist.Count, dateregexmatch);
                                        for (int abc = 0; abc < datelist.Count; abc++)
                                        {
                                            date = datelist[abc].ToString().Replace("<span class=\"date\">", "");
                                            date = date.Replace("</span>", "");
                                            DateTime new1 = DateTime.Parse(date);
                                            new1 = new1.Date + ts;
                                            if (!(new1 >= edate && new1 <= sdate))
                                            {
                                                return;
                                            }
                                            else
                                            {
                                                #region for
                                                String SubURL3 = individualCararraylist[x].ToString();
                                                int tindex = SubURL3.IndexOf("<a href=");
                                                int etindex = SubURL3.Length;
                                                string SubURL1 = SubURL3.ToString().Substring(tindex, etindex - tindex);
                                                int tindex1 = SubURL1.IndexOf("\"");
                                                int etindex1 = SubURL1.IndexOf(">");
                                                string SubURL2 = SubURL1.ToString().Substring(tindex1, etindex1 - tindex1);
                                                string sMainUrl = SubURL2.Replace("\"", "");
                                                sMainUrl = "http://" + CityN + ".craigslist.org" + sMainUrl;
                                                FillCurrentPageData(sMainUrl);
                                                string Details = string.Empty;
                                                Regex CarData = new Regex("<section id=\"postingbody\">(.*?)</section>");
                                                System.Collections.ArrayList individualpnslyvmailarraylistURL = new System.Collections.ArrayList();
                                                Details = content;
                                                Details = content.Replace('\n', ' ');
                                                System.Text.RegularExpressions.MatchCollection regexindividualpnslyvmailCollecURL = null;
                                                regexindividualpnslyvmailCollecURL = CarData.Matches(Details);
                                                individualpnslyvmailarraylistURL.Clear();
                                                individualpnslyvmailarraylistURL.InsertRange(individualpnslyvmailarraylistURL.Count, regexindividualpnslyvmailCollecURL);
                                                string vehicleDesc = string.Empty;
                                                if (individualpnslyvmailarraylistURL.Count != 0)
                                                {
                                                    vehicleDesc = individualpnslyvmailarraylistURL[0].ToString().Replace("<section id=\"postingbody\">", "");
                                                    vehicleDesc = vehicleDesc.Replace("</section>", "");
                                                    vehicleDesc = vehicleDesc.Replace("\t", "");
                                                    vehicleDesc = vehicleDesc.Replace("<br>", "");
                                                    vehicleDesc = vehicleDesc.Replace("=&gt;", "");//.Trim();
                                                }
                                                string sentence = vehicleDesc;//.Replace(" ","").Trim();
                                                sentence = sentence.ToLower(); sentence = sentence.Replace(" ", "").Trim();
                                                sentence = sentence.Replace("one", "1"); sentence = sentence.Replace("two", "2"); sentence = sentence.Replace("three", "3");
                                                sentence = sentence.Replace("four", "4"); sentence = sentence.Replace("five", "5"); sentence = sentence.Replace("six", "6");
                                                sentence = sentence.Replace("seven", "7"); sentence = sentence.Replace("eight", "8"); sentence = sentence.Replace("nine", "9");
                                                sentence = sentence.Replace("zero", "0"); sentence = sentence.Replace("o", "0");
                                                sentence = Regex.Replace(sentence, @"[^a-zA-Z0-9]", "");
                                                string[] digits = Regex.Split(sentence, @"\D+");
                                                string PhoneNumber = string.Empty;

                                                for (int p = 0; p < digits.Length; p++)
                                                {
                                                    if (digits[p].Length == 10)
                                                    {
                                                        PhoneNumber = digits[p];
                                                    }
                                                    if (digits[p].Length == 11)
                                                    {
                                                        PhoneNumber = digits[p].ToString();//.Substring(1);
                                                        if (PhoneNumber.IndexOf('0') == 0 || PhoneNumber.IndexOf('1') == 0)
                                                            PhoneNumber = PhoneNumber.Substring(1);
                                                        else if (PhoneNumber.IndexOf('0') == 10)
                                                            PhoneNumber = PhoneNumber.Substring(0,10);
                                                    }
                                                }
                                                
                                                vehicleDesc = vehicleDesc.Replace("http://", "");
                                                vehicleDesc = vehicleDesc.Replace("<br>", "");
                                                vehicleDesc = vehicleDesc.Replace("<", "");
                                                vehicleDesc = vehicleDesc.Replace(">", "");
                                                vehicleDesc = vehicleDesc.Replace("<a href=", "");
                                                vehicleDesc = vehicleDesc.Replace("<li>", "");
                                                vehicleDesc = vehicleDesc.Replace("/", "");
                                                if (PhoneNumber != "")
                                                {
                                                    CollectedFromState = CityN.ToString();
                                                    string Ttl = string.Empty;
                                                    Regex title = new Regex("<h2 class=\"postingtitle\">(.*?)</h2>");
                                                    System.Collections.ArrayList individualtitlemailarraylistURL = new System.Collections.ArrayList();
                                                    Ttl = content;
                                                    Ttl = content.Replace('\n', ' ');
                                                    System.Text.RegularExpressions.MatchCollection regexindividualtitlemailCollecURL = null;
                                                    regexindividualtitlemailCollecURL = title.Matches(Ttl);
                                                    individualtitlemailarraylistURL.Clear();
                                                    individualtitlemailarraylistURL.InsertRange(individualtitlemailarraylistURL.Count, regexindividualtitlemailCollecURL);
                                                    if (individualtitlemailarraylistURL.Count > 0)
                                                    {
                                                        for (int mdl = 0; mdl < individualtitlemailarraylistURL.Count; mdl++)
                                                        {
                                                            String Modelcar = individualtitlemailarraylistURL[mdl].ToString();
                                                            string[] sepem = { "$", "&#x0024;" };
                                                            string[] msplit = Modelcar.Split(sepem, StringSplitOptions.None);

                                                            Modellist1 = msplit[0].ToString();
                                                            if (Modellist1.Contains("</span> "))
                                                            {
                                                                Modellist1 = Modellist1.Substring(Modellist1.IndexOf("</span>")).Replace("</span>", "").Trim();
                                                                Modellist1 = Modellist1.Replace("=&gt;", "").Trim();
                                                                Modellist1 = Regex.Replace(Modellist1, "[^a-zA-Z0-9]", " ");
                                                                year = Regex.Replace(Modellist1, "[^a-zA-Z0-9]", " ");
                                                                string[] year1 = Regex.Split(year, @"\D+");
                                                                
                                                                for (int ab = 0; ab < year1.Length; ab++)
                                                                {
                                                                    if (year1[ab].Length == 4)
                                                                    {
                                                                        yearCar = year1[ab];
                                                                    }
                                                                }
                                                                if (msplit.Length > 1)
                                                                {
                                                                    sprice = msplit[1].ToString();
                                                                    sprice = sprice.Replace("</h2>", "");
                                                                    sprice = Regex.Replace(sprice, "[^0-9]", "");
                                                                }
                                                            }
                                                        }
                                                    }

                                                    #region cusemail
                                                    //System.Collections.ArrayList vehicleMainDesclist = new System.Collections.ArrayList();
                                                    //Regex regexobjvehicleMain = new Regex("<section class=\"dateReplyBar\">(.*?)</section>");
                                                    //str = content;
                                                    //str = content.Replace('\n', ' ');
                                                    //System.Text.RegularExpressions.MatchCollection regexvehicleListMain = null;
                                                    //regexvehicleListMain = regexobjvehicleMain.Matches(str);
                                                    //vehicleMainDesclist.Clear();
                                                    //vehicleMainDesclist.InsertRange(vehicleMainDesclist.Count, regexvehicleListMain);
                                                    //if (vehicleMainDesclist.Count > 0)
                                                    //{
                                                    //    CusEmailId = vehicleMainDesclist[0].ToString();
                                                    //    string[] EmailId = CusEmailId.Split('<');
                                                    //    CusEmailId = EmailId[9];
                                                    //    if (CusEmailId.Contains("@"))
                                                    //    {
                                                    //        int tindex3 = CusEmailId.IndexOf("mailto:");
                                                    //        int etindex3 = CusEmailId.IndexOf("?");
                                                    //        CusEmailId = CusEmailId.ToString().Substring(tindex3, etindex3 - tindex3);
                                                    //        CusEmailId = CusEmailId.Replace("mailto:", "");
                                                    //        CusEmailId = CusEmailId.Replace("aside class=\"flags\">", "");

                                                    //    }
                                                    //}
                                                    //if (vehicleMainDesclist.Count == 0)
                                                    //{
                                                    //    System.Collections.ArrayList vehicleMainDesclist1 = new System.Collections.ArrayList();
                                                    //    Regex regexobjvehicleMain1 = new Regex("<div id=\"returnemail\">(.*?)</div>");
                                                    //    str = content;
                                                    //    str = content.Replace('\n', ' ');
                                                    //    System.Text.RegularExpressions.MatchCollection regexvehicleListMain1 = null;
                                                    //    regexvehicleListMain1 = regexobjvehicleMain1.Matches(str);
                                                    //    vehicleMainDesclist1.Clear();
                                                    //    vehicleMainDesclist1.InsertRange(vehicleMainDesclist1.Count, regexvehicleListMain1);
                                                    //    if (vehicleMainDesclist1.Count > 0)
                                                    //    {
                                                    //        CusEmailId = vehicleMainDesclist1[0].ToString();
                                                    //        string[] EmailId = CusEmailId.Split('<');
                                                    //        CusEmailId = EmailId[9];
                                                    //        EmailId = CusEmailId.Split('>');
                                                    //        CusEmailId = EmailId[1];
                                                    //        CusEmailId = CusEmailId.Replace("aside class=\"flags\">", "");
                                                    //    }
                                                    //}
                                                    //#region old
                                                    ////String SubURL3 = individualCararraylist[x].ToString();
                                                    ////int tindex = SubURL3.IndexOf("<a href=");
                                                    ////int etindex = SubURL3.Length;
                                                    ////string SubURL1 = SubURL3.ToString().Substring(tindex, etindex - tindex);
                                                    ////int tindex1 = SubURL1.IndexOf("\"");
                                                    ////int etindex1 = SubURL1.IndexOf(">");
                                                    ////string SubURL2 = SubURL1.ToString().Substring(tindex1, etindex1 - tindex1);
                                                    ////string sMainUrl = SubURL2.Replace("\"", "");
                                                    ////sMainUrl = "http://" + CityN + ".craigslist.org" + sMainUrl;                              
                                                    ////FillCurrentPageData(sMainUrl);
                                                    ////string Ttl = string.Empty;
                                                    ////Regex title = new Regex("<h2 class=\"postingtitle\">(.*?)</h2>");
                                                    //// // Regex CarData = new Regex("<section class=\"userbody\">(.*?)</section>(.*?)</section>(.*?)</section>");
                                                    ////System.Collections.ArrayList individualtitlemailarraylistURL = new System.Collections.ArrayList();
                                                    ////Ttl = content;
                                                    ////                        Ttl = content.Replace('\n', ' ');
                                                    ////                        System.Text.RegularExpressions.MatchCollection regexindividualtitlemailCollecURL = null;
                                                    ////                        regexindividualtitlemailCollecURL = title.Matches(Ttl);
                                                    ////                        individualtitlemailarraylistURL.Clear();
                                                    ////                        individualtitlemailarraylistURL.InsertRange(individualtitlemailarraylistURL.Count, regexindividualtitlemailCollecURL);


                                                    ////                        if (individualtitlemailarraylistURL.Count > 0)
                                                    ////                        {
                                                    ////                            for (int mdl = 0; mdl < individualtitlemailarraylistURL.Count; mdl++)
                                                    ////                            {
                                                    ////                                String Modelcar = individualtitlemailarraylistURL[mdl].ToString();
                                                    ////                                char[] sepem = { '$' };
                                                    ////                                string[] msplit = Modelcar.Split(sepem);

                                                    ////                                for (int n = 0; n < msplit.Length; n++)
                                                    ////                                {
                                                    ////                                    Modellist1 = msplit[0].ToString();
                                                    ////                                    if (Modellist1.Contains("</span> "))
                                                    ////                                    {

                                                    ////                                        int tindex21 = Modellist1.IndexOf("</span>");
                                                    ////                                        int etindex21 = Modellist1.Length;
                                                    ////                                        string ttl = Modellist1.ToString().Substring(tindex21, etindex21 - tindex21);
                                                    ////                                        Modellist1 = ttl.Replace("</span>", "").Trim();

                                                    ////                                        sprice = msplit[1].ToString();

                                                    ////                                        sprice = sprice.Replace("</h2>", "");
                                                    ////                                        char[] sepemm = { ' ' };
                                                    ////                                        string[] msplit12 = sprice.Split(sepemm);
                                                    ////                                        sprice = msplit12[0].ToString();


                                                    ////                                    }

                                                    ////                                }
                                                    ////                            }


                                                    ////                            string Details = string.Empty;
                                                    ////                            Regex CarData = new Regex("<section id=\"postingbody\">(.*?)</section>");
                                                    ////                            // Regex CarData = new Regex("<section class=\"userbody\">(.*?)</section>(.*?)</section>(.*?)</section>");
                                                    ////                            System.Collections.ArrayList individualpnslyvmailarraylistURL = new System.Collections.ArrayList();
                                                    ////                            Details = content;
                                                    ////                            Details = content.Replace('\n', ' ');
                                                    ////                            System.Text.RegularExpressions.MatchCollection regexindividualpnslyvmailCollecURL = null;
                                                    ////                            regexindividualpnslyvmailCollecURL = CarData.Matches(Details);
                                                    ////                            individualpnslyvmailarraylistURL.Clear();
                                                    ////                            individualpnslyvmailarraylistURL.InsertRange(individualpnslyvmailarraylistURL.Count, regexindividualpnslyvmailCollecURL);





                                                    ////                            string vehicleDesc = string.Empty;
                                                    ////                            if (individualpnslyvmailarraylistURL.Count != 0)
                                                    ////                            {

                                                    ////                                vehicleDesc = individualpnslyvmailarraylistURL[0].ToString().Replace("<section id=\"postingbody\">", "");
                                                    ////                                vehicleDesc = vehicleDesc.Replace("</section>", "");
                                                    ////                                vehicleDesc = vehicleDesc.Replace("\t", "");
                                                    ////                                vehicleDesc = vehicleDesc.Replace("<br>", "");
                                                    ////                            }

                                                    ////                            Regex posting = new Regex("<div class=\"postinginfos\">(.*?)</div>");
                                                    ////                            // Regex CarData = new Regex("<section class=\"userbody\">(.*?)</section>(.*?)</section>(.*?)</section>");
                                                    ////                            System.Collections.ArrayList individualpostingmailarraylistURL = new System.Collections.ArrayList();
                                                    ////                            Details = content;
                                                    ////                            Details = content.Replace('\n', ' ');
                                                    ////                            System.Text.RegularExpressions.MatchCollection regexindividualpostingmailCollecURL = null;
                                                    ////                            regexindividualpostingmailCollecURL = posting.Matches(Details);
                                                    ////                            individualpostingmailarraylistURL.Clear();
                                                    ////                            individualpostingmailarraylistURL.InsertRange(individualpostingmailarraylistURL.Count, regexindividualpostingmailCollecURL);


                                                    ////                            if (individualpostingmailarraylistURL.Count > 0)
                                                    ////                            {
                                                    ////                                String post = individualpostingmailarraylistURL[0].ToString();

                                                    ////                                int tindex2 = post.IndexOf("Posting ID:");
                                                    ////                                int etindex2 = post.IndexOf("</p>");
                                                    ////                                sPosting = post.ToString().Substring(tindex2, etindex2 - tindex2);
                                                    ////                                sPosting = sPosting.Replace("Posting ID:", "");

                                                    ////                            }

                                                    ////                           //string[] sPostingId = sMainUrl.Split('/');
                                                    ////                            //string sPosting = string.Empty;

                                                    ////                            //if (sPostingId.Length == 6)
                                                    ////                            //{
                                                    ////                            //    sPosting = sPostingId[5].Replace(".html", "");
                                                    ////                            //}
                                                    ////                            //else if (sPostingId.Length == 5)
                                                    ////                            //{

                                                    ////                            //    sPosting = sPostingId[4].Replace(".html", "");
                                                    ////                            //}

                                                    ////                            string CollectedFromState = CityN.ToString();

                                                    ////                            string sentence = vehicleDesc;
                                                    ////                            //
                                                    ////                            // Get all digit sequence as strings from data(Description).
                                                    ////                            //
                                                    ////                            string[] digits = Regex.Split(sentence, @"\D+");

                                                    ////                            string PhoneNumber = string.Empty;

                                                    ////                            for (int p = 0; p < digits.Length; p++)
                                                    ////                            {
                                                    ////                                if ((digits[p].Length == 3 && digits[p + 1].Length == 3 && digits[p + 2].Length == 4) || (digits[p].Length == 10))
                                                    ////                                {
                                                    ////                                    if (digits[p].Length == 3 && digits[p + 1].Length == 3 && digits[p + 2].Length == 4)
                                                    ////                                    {
                                                    ////                                        PhoneNumber = digits[p] + digits[p + 1] + digits[p + 2];


                                                    ////                                    }
                                                    ////                                    else if (digits[p].Length == 10)
                                                    ////                                    {

                                                    ////                                        if (sPosting == PhoneNumber)
                                                    ////                                        {
                                                    ////                                            PhoneNumber = "";
                                                    ////                                        }
                                                    ////                                        else
                                                    ////                                        {
                                                    ////                                            PhoneNumber = digits[p];

                                                    ////                                        }

                                                    ////                                    }
                                                    ////                                }
                                                    ////                            }
                                                    ////                            vehicleDesc = vehicleDesc.Replace("http://", "");
                                                    ////                            vehicleDesc = vehicleDesc.Replace("<br>", "");
                                                    ////                            vehicleDesc = vehicleDesc.Replace("<", "");
                                                    ////                            vehicleDesc = vehicleDesc.Replace(">", "");
                                                    ////                            vehicleDesc = vehicleDesc.Replace("<a href=", "");
                                                    ////                            vehicleDesc = vehicleDesc.Replace("<li>", "");
                                                    ////                            vehicleDesc = vehicleDesc.Replace("/", "");

                                                    ////                            string CusEmailId = string.Empty;

                                                    ////                            System.Collections.ArrayList vehicleMainDesclist = new System.Collections.ArrayList();
                                                    ////                            Regex regexobjvehicleMain = new Regex("<section class=\"dateReplyBar\">(.*?)</section>");
                                                    ////                            str = content;
                                                    ////                            str = content.Replace('\n', ' ');
                                                    ////                            System.Text.RegularExpressions.MatchCollection regexvehicleListMain = null;
                                                    ////                            regexvehicleListMain = regexobjvehicleMain.Matches(str);
                                                    ////                            vehicleMainDesclist.Clear();
                                                    ////                            vehicleMainDesclist.InsertRange(vehicleMainDesclist.Count, regexvehicleListMain);

                                                    ////                            if (vehicleMainDesclist.Count > 0)
                                                    ////                            {
                                                    ////                                CusEmailId = vehicleMainDesclist[0].ToString();

                                                    ////                                string[] EmailId = CusEmailId.Split('<');
                                                    ////                                CusEmailId = EmailId[9];
                                                    ////                                if (CusEmailId.Contains("@"))
                                                    ////                                {
                                                    ////                                    int tindex3 = CusEmailId.IndexOf("mailto:");
                                                    ////                                    int etindex3 = CusEmailId.IndexOf("?");
                                                    ////                                    CusEmailId = CusEmailId.ToString().Substring(tindex3, etindex3 - tindex3);
                                                    ////                                    CusEmailId = CusEmailId.Replace("mailto:", "");
                                                    ////                                    // CusEmailId = CusEmailId.Replace("", ".org");


                                                    ////                                    //EmailId = CusEmailId.Split('>');
                                                    ////                                    //CusEmailId = EmailId[1];
                                                    ////                                }
                                                    ////                            }
                                                    //#endregion
                                                    //if (vehicleMainDesclist.Count == 0)
                                                    //{

                                                    //    System.Collections.ArrayList vehicleMainDesclist1 = new System.Collections.ArrayList();
                                                    //    Regex regexobjvehicleMain1 = new Regex("<div id=\"returnemail\">(.*?)</div>");
                                                    //    str = content;
                                                    //    str = content.Replace('\n', ' ');
                                                    //    System.Text.RegularExpressions.MatchCollection regexvehicleListMain1 = null;
                                                    //    regexvehicleListMain1 = regexobjvehicleMain1.Matches(str);
                                                    //    vehicleMainDesclist1.Clear();
                                                    //    vehicleMainDesclist1.InsertRange(vehicleMainDesclist1.Count, regexvehicleListMain1);

                                                    //    if (vehicleMainDesclist1.Count > 0)
                                                    //    {
                                                    //        CusEmailId = vehicleMainDesclist1[0].ToString();

                                                    //        string[] EmailId = CusEmailId.Split('<');
                                                    //        CusEmailId = EmailId[9];
                                                    //        EmailId = CusEmailId.Split('>');
                                                    //        CusEmailId = EmailId[1];
                                                    //    }

                                                    //}
                                                    #endregion

                                                }
                                                DataSet ds = new DataSet();
                                                objDal.SaveLead_Craigslist(sprice, Modellist1, vehicleDesc, sMainUrl, sPosting, CollectedFromState, PhoneNumber, StateID, StateN, yearCar);
                                                varcount = varcount + 1;
                                                label2.Text = Convert.ToInt32(varcount).ToString();
                                                #endregion
                                            }
                                        }
                                        #endregion
                                    }
                                    else return;
                                }
                            }
                            else return;
                            #endregion

                        }
                        else return;
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }
        #endregion craigslistLeads
        #region craigslistDealers
        private void GetLeadsForCraigslistDealers(string StateN, string CityN, int StateID)
        {
            varcount = 0;
            int urlNums = 26;
            int a = 0, b = 0; string Modellist1 = "";
            string sprice = ""; string sPosting = "  "; string CollectedFromState = "";
            string CusEmailId = string.Empty;
            string date = "";

            string mainURL = ConfigurationManager.AppSettings["MainUrlCraigslist"].ToString();
            {
                mainURL = "http://" + StateN + ".craigslist.org/ctd";
            }
            if (stopcld)
            {
                for (int j = 0; j <= urlNums; j++)
                {
                    if (stopcld)
                    {
                        a = (j) * 100;
                        if (CCityNames.Text != "")
                        {
                            if (a == 0)
                            {
                                mainURL = "http://" + CityN + ".craigslist.org/search/ctd?query=&srchType=A&minAsk=2500";
                                //  http://abilene.craigslist.org/search/cto?query=&srchType=T&minAsk=4000&maxAsk=
                            }
                            else
                            {
                                mainURL = "http://" + CityN + ".craigslist.org/search/ctd?query=&srchType=A&minAsk=2500&s=" + a + "";
                                //  http://abilene.craigslist.org/search/cto?query=&srchType=T&minAsk=4000&maxAsk=&s=100
                            }
                        }
                        else
                        {
                            mainURL = "http://" + StateN + ".craigslist.org/search/ctd?query=&srchType=T&minAsk=2500";
                        }
                        FillCurrentPageData(mainURL);
                        String str = string.Empty;

                        Regex regexindividual = new Regex("<span class=\"pl\">(.*?)</span>(.*?)</span>(.*?)</span>(.*?)</span>");
                        System.Collections.ArrayList individualCararraylist = new System.Collections.ArrayList();
                        str = content;
                        str = content.Replace('\n', ' ');
                        System.Text.RegularExpressions.MatchCollection regexindividualCollec = null;
                        regexindividualCollec = regexindividual.Matches(str);
                        individualCararraylist.Clear();
                        individualCararraylist.InsertRange(individualCararraylist.Count, regexindividualCollec);

                        for (int x = 0; x < individualCararraylist.Count; x++)
                        {
                            if (stopcld)
                            {
                                Regex dateregex = new Regex("<span class=\"date\">(.*?)</span>");
                                System.Collections.ArrayList datelist = new System.Collections.ArrayList();
                                str = individualCararraylist[x].ToString();
                                str = str.Replace('\n', ' ');
                                System.Text.RegularExpressions.MatchCollection dateregexmatch = null;
                                dateregexmatch = dateregex.Matches(str);
                                datelist.Clear();
                                datelist.InsertRange(datelist.Count, dateregexmatch);
                                for (int abc = 0; abc < datelist.Count; abc++)
                                {
                                    date = datelist[abc].ToString().Replace("<span class=\"date\">", "");
                                    date = date.Replace("</span>", "");
                                    DateTime new1 = DateTime.Parse(date);
                                    new1 = new1.Date + ts;
                                    if (!(new1 >= edate && new1 <= sdate))
                                    {
                                        return;
                                    }
                                    else
                                    {
                                        #region for
                                        String SubURL3 = individualCararraylist[x].ToString();
                                        int tindex = SubURL3.IndexOf("<a href=");
                                        int etindex = SubURL3.Length;
                                        string SubURL1 = SubURL3.ToString().Substring(tindex, etindex - tindex);
                                        int tindex1 = SubURL1.IndexOf("\"");
                                        int etindex1 = SubURL1.IndexOf(">");
                                        string SubURL2 = SubURL1.ToString().Substring(tindex1, etindex1 - tindex1);
                                        string sMainUrl = SubURL2.Replace("\"", "");
                                        sMainUrl = "http://" + CityN + ".craigslist.org" + sMainUrl;
                                        FillCurrentPageData(sMainUrl);
                                        string Details = string.Empty;
                                        Regex CarData = new Regex("<section id=\"postingbody\">(.*?)</section>");
                                        // Regex CarData = new Regex("<section class=\"userbody\">(.*?)</section>(.*?)</section>(.*?)</section>");
                                        System.Collections.ArrayList individualpnslyvmailarraylistURL = new System.Collections.ArrayList();
                                        Details = content;
                                        Details = content.Replace('\n', ' ');
                                        System.Text.RegularExpressions.MatchCollection regexindividualpnslyvmailCollecURL = null;
                                        regexindividualpnslyvmailCollecURL = CarData.Matches(Details);
                                        individualpnslyvmailarraylistURL.Clear();
                                        individualpnslyvmailarraylistURL.InsertRange(individualpnslyvmailarraylistURL.Count, regexindividualpnslyvmailCollecURL);
                                        string vehicleDesc = string.Empty;
                                        if (individualpnslyvmailarraylistURL.Count != 0)
                                        {
                                            vehicleDesc = individualpnslyvmailarraylistURL[0].ToString().Replace("<section id=\"postingbody\">", "");
                                            vehicleDesc = vehicleDesc.Replace("</section>", "");
                                            vehicleDesc = vehicleDesc.Replace("\t", "");
                                            vehicleDesc = vehicleDesc.Replace("<br>", "");
                                            vehicleDesc = vehicleDesc.Replace("=&gt;", "");//.Trim();
                                        }
                                        string sentence = vehicleDesc;//.Replace(" ","").Trim();
                                        string[] digits = Regex.Split(sentence, @"\D+");
                                        string PhoneNumber = string.Empty;

                                        for (int p = 0; p < digits.Length; p++)
                                        {
                                            if (digits[p].Length == 10)
                                            {
                                                if (sPosting == PhoneNumber)
                                                {
                                                    PhoneNumber = "";
                                                }
                                                else
                                                {
                                                    PhoneNumber = digits[p];
                                                }
                                            }
                                            else if (digits[p].Length == 3 && digits[p + 1].Length == 3 && digits[p + 2].Length == 4)
                                            {
                                                PhoneNumber = digits[p] + digits[p + 1] + digits[p + 2];
                                            }

                                            else if (digits[p].Length == 3 && digits[p + 1].Length == 7)
                                            {
                                                PhoneNumber = digits[p] + digits[p + 1];
                                            }
                                        }
                                        if (PhoneNumber == "")
                                        {
                                            sentence = sentence.ToLower(); sentence = sentence.Replace(" ", "").Trim();
                                            sentence = sentence.Replace("one", "1"); sentence = sentence.Replace("two", "2"); sentence = sentence.Replace("three", "3");
                                            sentence = sentence.Replace("four", "4"); sentence = sentence.Replace("five", "5"); sentence = sentence.Replace("six", "6");
                                            sentence = sentence.Replace("seven", "7"); sentence = sentence.Replace("eight", "8"); sentence = sentence.Replace("nine", "9");
                                            sentence = sentence.Replace("zero", "0"); sentence = sentence.Replace("o", "0");

                                            sentence = Regex.Replace(sentence, @"[^a-zA-Z0-9]", "");
                                            digits = Regex.Split(sentence, @"\D+");
                                            string PhoneNumber1 = string.Empty;

                                            for (int p = 0; p < digits.Length; p++)
                                            {
                                                if (digits[p].Length == 10)
                                                {
                                                    if (sPosting == PhoneNumber)
                                                    {
                                                        PhoneNumber = "";
                                                    }
                                                    else
                                                    {
                                                        PhoneNumber = digits[p];
                                                    }
                                                }
                                                if (p + 1 < digits.Length)
                                                {
                                                    if ((p + 2 < digits.Length))
                                                    {
                                                        if (digits[p].Length == 3 && digits[p + 1].Length == 3 && digits[p + 2].Length == 4)
                                                        {
                                                            PhoneNumber = digits[p] + digits[p + 1] + digits[p + 2];
                                                        }
                                                    }
                                                    else if (digits[p].Length == 3 && digits[p + 1].Length == 7)
                                                    {
                                                        PhoneNumber = digits[p] + digits[p + 1];
                                                    }
                                                }
                                                else if (digits[p].Length == 11)
                                                {
                                                    PhoneNumber = digits[p];
                                                    if (PhoneNumber[0] == 0 || PhoneNumber[0] == 1)
                                                    {
                                                        PhoneNumber = PhoneNumber.Substring(1);
                                                    }
                                                    else if (PhoneNumber[10] == 0)
                                                    {
                                                        PhoneNumber = PhoneNumber.Substring(0, 10);
                                                    }
                                                }

                                            }
                                        }
                                        vehicleDesc = vehicleDesc.Replace("http://", "");
                                        vehicleDesc = vehicleDesc.Replace("<br>", "");
                                        vehicleDesc = vehicleDesc.Replace("<", "");
                                        vehicleDesc = vehicleDesc.Replace(">", "");
                                        vehicleDesc = vehicleDesc.Replace("<a href=", "");
                                        vehicleDesc = vehicleDesc.Replace("<li>", "");
                                        vehicleDesc = vehicleDesc.Replace("/", "");
                                        //if (PhoneNumber != "")
                                        //{

                                        //FillCurrentPageData("http://miami.craigslist.org/pbc/cto/4160044687.html");
                                        Regex posting = new Regex("<p class=\"postinginfo\">(.*?)</p>");
                                        System.Collections.ArrayList individualpostingmailarraylistURL = new System.Collections.ArrayList();
                                        Details = content;
                                        Details = content.Replace('\n', ' ');
                                        System.Text.RegularExpressions.MatchCollection regexindividualpostingmailCollecURL = null;
                                        regexindividualpostingmailCollecURL = posting.Matches(Details);
                                        individualpostingmailarraylistURL.Clear();
                                        individualpostingmailarraylistURL.InsertRange(individualpostingmailarraylistURL.Count, regexindividualpostingmailCollecURL);
                                        if (individualpostingmailarraylistURL.Count > 0)
                                        {
                                            sPosting = individualpostingmailarraylistURL[1].ToString();
                                            sPosting = sPosting.Replace("<p class=\"postinginfo\">", "");
                                            sPosting = sPosting.Replace("</p>", "");
                                            sPosting = sPosting.Replace("Posting ID:", "");
                                            sPosting = sPosting.Replace("post id:", "");
                                        }
                                        CollectedFromState = CityN.ToString();
                                        string Ttl = string.Empty;
                                        Regex title = new Regex("<h2 class=\"postingtitle\">(.*?)</h2>");
                                        System.Collections.ArrayList individualtitlemailarraylistURL = new System.Collections.ArrayList();
                                        Ttl = content;
                                        Ttl = content.Replace('\n', ' ');
                                        System.Text.RegularExpressions.MatchCollection regexindividualtitlemailCollecURL = null;
                                        regexindividualtitlemailCollecURL = title.Matches(Ttl);
                                        individualtitlemailarraylistURL.Clear();
                                        individualtitlemailarraylistURL.InsertRange(individualtitlemailarraylistURL.Count, regexindividualtitlemailCollecURL);
                                        if (individualtitlemailarraylistURL.Count > 0)
                                        {
                                            for (int mdl = 0; mdl < individualtitlemailarraylistURL.Count; mdl++)
                                            {
                                                String Modelcar = individualtitlemailarraylistURL[mdl].ToString();
                                                string[] sepem = { "$", "&#x0024;" };
                                                string[] msplit = Modelcar.Split(sepem, StringSplitOptions.None);

                                                for (int n = 0; n < msplit.Length; n++)
                                                {
                                                    Modellist1 = msplit[0].ToString();
                                                    if (Modellist1.Contains("</span> "))
                                                    {
                                                        int tindex21 = Modellist1.IndexOf("</span>");
                                                        int etindex21 = Modellist1.Length;
                                                        string ttl = Modellist1.ToString().Substring(tindex21, etindex21 - tindex21);
                                                        Modellist1 = ttl.Replace("</span>", "").Trim();
                                                        Modellist1 = Modellist1.Replace("=&gt;", "").Trim();

                                                        if (msplit.Length > 1)
                                                        {
                                                            sprice = msplit[1].ToString();
                                                            sprice = sprice.Replace("</h2>", "");
                                                            char[] sepemm = { ' ' };
                                                            string[] msplit12 = sprice.Split(sepemm);
                                                            sprice = msplit12[0].ToString();
                                                        }
                                                    }
                                                }
                                            }
                                        }

                                        System.Collections.ArrayList vehicleMainDesclist = new System.Collections.ArrayList();
                                        Regex regexobjvehicleMain = new Regex("<section class=\"dateReplyBar\">(.*?)</section>");
                                        str = content;
                                        str = content.Replace('\n', ' ');
                                        System.Text.RegularExpressions.MatchCollection regexvehicleListMain = null;
                                        regexvehicleListMain = regexobjvehicleMain.Matches(str);
                                        vehicleMainDesclist.Clear();
                                        vehicleMainDesclist.InsertRange(vehicleMainDesclist.Count, regexvehicleListMain);
                                        if (vehicleMainDesclist.Count > 0)
                                        {
                                            CusEmailId = vehicleMainDesclist[0].ToString();
                                            string[] EmailId = CusEmailId.Split('<');
                                            CusEmailId = EmailId[9];
                                            if (CusEmailId.Contains("@"))
                                            {
                                                int tindex3 = CusEmailId.IndexOf("mailto:");
                                                int etindex3 = CusEmailId.IndexOf("?");
                                                CusEmailId = CusEmailId.ToString().Substring(tindex3, etindex3 - tindex3);
                                                CusEmailId = CusEmailId.Replace("mailto:", "");
                                                CusEmailId = CusEmailId.Replace("aside class=\"flags\">", "");

                                            }
                                        }
                                        if (vehicleMainDesclist.Count == 0)
                                        {
                                            System.Collections.ArrayList vehicleMainDesclist1 = new System.Collections.ArrayList();
                                            Regex regexobjvehicleMain1 = new Regex("<div id=\"returnemail\">(.*?)</div>");
                                            str = content;
                                            str = content.Replace('\n', ' ');
                                            System.Text.RegularExpressions.MatchCollection regexvehicleListMain1 = null;
                                            regexvehicleListMain1 = regexobjvehicleMain1.Matches(str);
                                            vehicleMainDesclist1.Clear();
                                            vehicleMainDesclist1.InsertRange(vehicleMainDesclist1.Count, regexvehicleListMain1);
                                            if (vehicleMainDesclist1.Count > 0)
                                            {
                                                CusEmailId = vehicleMainDesclist1[0].ToString();
                                                string[] EmailId = CusEmailId.Split('<');
                                                CusEmailId = EmailId[9];
                                                EmailId = CusEmailId.Split('>');
                                                CusEmailId = EmailId[1];
                                                CusEmailId = CusEmailId.Replace("aside class=\"flags\">", "");
                                            }
                                        }
                                        #region old
                                        //String SubURL3 = individualCararraylist[x].ToString();
                                        //int tindex = SubURL3.IndexOf("<a href=");
                                        //int etindex = SubURL3.Length;
                                        //string SubURL1 = SubURL3.ToString().Substring(tindex, etindex - tindex);
                                        //int tindex1 = SubURL1.IndexOf("\"");
                                        //int etindex1 = SubURL1.IndexOf(">");
                                        //string SubURL2 = SubURL1.ToString().Substring(tindex1, etindex1 - tindex1);
                                        //string sMainUrl = SubURL2.Replace("\"", "");
                                        //sMainUrl = "http://" + CityN + ".craigslist.org" + sMainUrl;                              
                                        //FillCurrentPageData(sMainUrl);
                                        //string Ttl = string.Empty;
                                        //Regex title = new Regex("<h2 class=\"postingtitle\">(.*?)</h2>");
                                        // // Regex CarData = new Regex("<section class=\"userbody\">(.*?)</section>(.*?)</section>(.*?)</section>");
                                        //System.Collections.ArrayList individualtitlemailarraylistURL = new System.Collections.ArrayList();
                                        //Ttl = content;
                                        //                        Ttl = content.Replace('\n', ' ');
                                        //                        System.Text.RegularExpressions.MatchCollection regexindividualtitlemailCollecURL = null;
                                        //                        regexindividualtitlemailCollecURL = title.Matches(Ttl);
                                        //                        individualtitlemailarraylistURL.Clear();
                                        //                        individualtitlemailarraylistURL.InsertRange(individualtitlemailarraylistURL.Count, regexindividualtitlemailCollecURL);


                                        //                        if (individualtitlemailarraylistURL.Count > 0)
                                        //                        {
                                        //                            for (int mdl = 0; mdl < individualtitlemailarraylistURL.Count; mdl++)
                                        //                            {
                                        //                                String Modelcar = individualtitlemailarraylistURL[mdl].ToString();
                                        //                                char[] sepem = { '$' };
                                        //                                string[] msplit = Modelcar.Split(sepem);

                                        //                                for (int n = 0; n < msplit.Length; n++)
                                        //                                {
                                        //                                    Modellist1 = msplit[0].ToString();
                                        //                                    if (Modellist1.Contains("</span> "))
                                        //                                    {

                                        //                                        int tindex21 = Modellist1.IndexOf("</span>");
                                        //                                        int etindex21 = Modellist1.Length;
                                        //                                        string ttl = Modellist1.ToString().Substring(tindex21, etindex21 - tindex21);
                                        //                                        Modellist1 = ttl.Replace("</span>", "").Trim();

                                        //                                        sprice = msplit[1].ToString();

                                        //                                        sprice = sprice.Replace("</h2>", "");
                                        //                                        char[] sepemm = { ' ' };
                                        //                                        string[] msplit12 = sprice.Split(sepemm);
                                        //                                        sprice = msplit12[0].ToString();


                                        //                                    }

                                        //                                }
                                        //                            }


                                        //                            string Details = string.Empty;
                                        //                            Regex CarData = new Regex("<section id=\"postingbody\">(.*?)</section>");
                                        //                            // Regex CarData = new Regex("<section class=\"userbody\">(.*?)</section>(.*?)</section>(.*?)</section>");
                                        //                            System.Collections.ArrayList individualpnslyvmailarraylistURL = new System.Collections.ArrayList();
                                        //                            Details = content;
                                        //                            Details = content.Replace('\n', ' ');
                                        //                            System.Text.RegularExpressions.MatchCollection regexindividualpnslyvmailCollecURL = null;
                                        //                            regexindividualpnslyvmailCollecURL = CarData.Matches(Details);
                                        //                            individualpnslyvmailarraylistURL.Clear();
                                        //                            individualpnslyvmailarraylistURL.InsertRange(individualpnslyvmailarraylistURL.Count, regexindividualpnslyvmailCollecURL);





                                        //                            string vehicleDesc = string.Empty;
                                        //                            if (individualpnslyvmailarraylistURL.Count != 0)
                                        //                            {

                                        //                                vehicleDesc = individualpnslyvmailarraylistURL[0].ToString().Replace("<section id=\"postingbody\">", "");
                                        //                                vehicleDesc = vehicleDesc.Replace("</section>", "");
                                        //                                vehicleDesc = vehicleDesc.Replace("\t", "");
                                        //                                vehicleDesc = vehicleDesc.Replace("<br>", "");
                                        //                            }

                                        //                            Regex posting = new Regex("<div class=\"postinginfos\">(.*?)</div>");
                                        //                            // Regex CarData = new Regex("<section class=\"userbody\">(.*?)</section>(.*?)</section>(.*?)</section>");
                                        //                            System.Collections.ArrayList individualpostingmailarraylistURL = new System.Collections.ArrayList();
                                        //                            Details = content;
                                        //                            Details = content.Replace('\n', ' ');
                                        //                            System.Text.RegularExpressions.MatchCollection regexindividualpostingmailCollecURL = null;
                                        //                            regexindividualpostingmailCollecURL = posting.Matches(Details);
                                        //                            individualpostingmailarraylistURL.Clear();
                                        //                            individualpostingmailarraylistURL.InsertRange(individualpostingmailarraylistURL.Count, regexindividualpostingmailCollecURL);


                                        //                            if (individualpostingmailarraylistURL.Count > 0)
                                        //                            {
                                        //                                String post = individualpostingmailarraylistURL[0].ToString();

                                        //                                int tindex2 = post.IndexOf("Posting ID:");
                                        //                                int etindex2 = post.IndexOf("</p>");
                                        //                                sPosting = post.ToString().Substring(tindex2, etindex2 - tindex2);
                                        //                                sPosting = sPosting.Replace("Posting ID:", "");

                                        //                            }

                                        //                           //string[] sPostingId = sMainUrl.Split('/');
                                        //                            //string sPosting = string.Empty;

                                        //                            //if (sPostingId.Length == 6)
                                        //                            //{
                                        //                            //    sPosting = sPostingId[5].Replace(".html", "");
                                        //                            //}
                                        //                            //else if (sPostingId.Length == 5)
                                        //                            //{

                                        //                            //    sPosting = sPostingId[4].Replace(".html", "");
                                        //                            //}

                                        //                            string CollectedFromState = CityN.ToString();

                                        //                            string sentence = vehicleDesc;
                                        //                            //
                                        //                            // Get all digit sequence as strings from data(Description).
                                        //                            //
                                        //                            string[] digits = Regex.Split(sentence, @"\D+");

                                        //                            string PhoneNumber = string.Empty;

                                        //                            for (int p = 0; p < digits.Length; p++)
                                        //                            {
                                        //                                if ((digits[p].Length == 3 && digits[p + 1].Length == 3 && digits[p + 2].Length == 4) || (digits[p].Length == 10))
                                        //                                {
                                        //                                    if (digits[p].Length == 3 && digits[p + 1].Length == 3 && digits[p + 2].Length == 4)
                                        //                                    {
                                        //                                        PhoneNumber = digits[p] + digits[p + 1] + digits[p + 2];


                                        //                                    }
                                        //                                    else if (digits[p].Length == 10)
                                        //                                    {

                                        //                                        if (sPosting == PhoneNumber)
                                        //                                        {
                                        //                                            PhoneNumber = "";
                                        //                                        }
                                        //                                        else
                                        //                                        {
                                        //                                            PhoneNumber = digits[p];

                                        //                                        }

                                        //                                    }
                                        //                                }
                                        //                            }
                                        //                            vehicleDesc = vehicleDesc.Replace("http://", "");
                                        //                            vehicleDesc = vehicleDesc.Replace("<br>", "");
                                        //                            vehicleDesc = vehicleDesc.Replace("<", "");
                                        //                            vehicleDesc = vehicleDesc.Replace(">", "");
                                        //                            vehicleDesc = vehicleDesc.Replace("<a href=", "");
                                        //                            vehicleDesc = vehicleDesc.Replace("<li>", "");
                                        //                            vehicleDesc = vehicleDesc.Replace("/", "");

                                        //                            string CusEmailId = string.Empty;

                                        //                            System.Collections.ArrayList vehicleMainDesclist = new System.Collections.ArrayList();
                                        //                            Regex regexobjvehicleMain = new Regex("<section class=\"dateReplyBar\">(.*?)</section>");
                                        //                            str = content;
                                        //                            str = content.Replace('\n', ' ');
                                        //                            System.Text.RegularExpressions.MatchCollection regexvehicleListMain = null;
                                        //                            regexvehicleListMain = regexobjvehicleMain.Matches(str);
                                        //                            vehicleMainDesclist.Clear();
                                        //                            vehicleMainDesclist.InsertRange(vehicleMainDesclist.Count, regexvehicleListMain);

                                        //                            if (vehicleMainDesclist.Count > 0)
                                        //                            {
                                        //                                CusEmailId = vehicleMainDesclist[0].ToString();

                                        //                                string[] EmailId = CusEmailId.Split('<');
                                        //                                CusEmailId = EmailId[9];
                                        //                                if (CusEmailId.Contains("@"))
                                        //                                {
                                        //                                    int tindex3 = CusEmailId.IndexOf("mailto:");
                                        //                                    int etindex3 = CusEmailId.IndexOf("?");
                                        //                                    CusEmailId = CusEmailId.ToString().Substring(tindex3, etindex3 - tindex3);
                                        //                                    CusEmailId = CusEmailId.Replace("mailto:", "");
                                        //                                    // CusEmailId = CusEmailId.Replace("", ".org");


                                        //                                    //EmailId = CusEmailId.Split('>');
                                        //                                    //CusEmailId = EmailId[1];
                                        //                                }
                                        //                            }
                                        #endregion
                                        if (vehicleMainDesclist.Count == 0)
                                        {

                                            System.Collections.ArrayList vehicleMainDesclist1 = new System.Collections.ArrayList();
                                            Regex regexobjvehicleMain1 = new Regex("<div id=\"returnemail\">(.*?)</div>");
                                            str = content;
                                            str = content.Replace('\n', ' ');
                                            System.Text.RegularExpressions.MatchCollection regexvehicleListMain1 = null;
                                            regexvehicleListMain1 = regexobjvehicleMain1.Matches(str);
                                            vehicleMainDesclist1.Clear();
                                            vehicleMainDesclist1.InsertRange(vehicleMainDesclist1.Count, regexvehicleListMain1);

                                            if (vehicleMainDesclist1.Count > 0)
                                            {
                                                CusEmailId = vehicleMainDesclist1[0].ToString();

                                                string[] EmailId = CusEmailId.Split('<');
                                                CusEmailId = EmailId[9];
                                                EmailId = CusEmailId.Split('>');
                                                CusEmailId = EmailId[1];
                                            }

                                        }

                                        // }
                                        DataSet ds = new DataSet();
                                        ds = objDal.SaveLead_CraigslistDealers(sprice, Modellist1, vehicleDesc, sMainUrl, sPosting, CollectedFromState, PhoneNumber, StateID, StateN, CusEmailId);
                                        varcount = varcount + 1;
                                        label2.Text = Convert.ToInt32(varcount).ToString();
                                        #endregion
                                    }
                                }
                            }
                            else return;
                        }
                    }
                    else return;
                }
            }

        }  
        #endregion craigslistDealers
        #region craigslistLeadsRVS
        private void GetLeadsForcraigslistRVS()
        {
            int urlNums = 10;
            int a = 0, b = 0;

            string mainURL = ConfigurationManager.AppSettings["MainUrlCraigslist"].ToString();

            //if (CCityNames.SelectedItem != null)
            //{
            //    mainURL = "http://" + CCityNames.SelectedItem + ".craigslist.org/cgi-bin/autos.cgi?&category=cta/";
            //}
            //else
            {
                mainURL = "http://" + cmbState.Text + ".craigslist.org/cto";
            }




            for (int j = 1; j <= urlNums; j++)
            {
                a = (j - 1) * 100;


                if (CCityNames.Text != "")
                {
                    if (a == 0)
                    {
                        mainURL = "http://" + CCityNames.Text + ".craigslist.org/rvs/";
                        //  mainURL = "http://" + CCityNames.Text + ".craigslist.org/search/cto?query=&srchType=T&minAsk=4000&maxAsk=";
                        //  http://abilene.craigslist.org/search/cto?query=&srchType=T&minAsk=4000&maxAsk=
                    }
                    else
                    {
                        mainURL = "http://" + CCityNames.Text + ".craigslist.org/rvs/index" + a + ".html";
                        //  mainURL = "http://" + CCityNames.Text + ".craigslist.org/search/cto?query=&srchType=T&minAsk=10000&maxAsk=&s=" + a + "";
                        //  http://abilene.craigslist.org/search/cto?query=&srchType=T&minAsk=4000&maxAsk=&s=100
                    }
                }
                else
                {
                    mainURL = "http://" + CCityNames.Text + ".craigslist.org/rvs/";
                    //  mainURL = "http://" + cmbState.Text + ".craigslist.org/search/cto?query=&srchType=T&minAsk=4000&maxAsk=";
                }
                FillCurrentPageData(mainURL);

                String str = string.Empty;


                Regex regexindividual = new Regex("<p class=\"row\">(.*?)</p>");



                System.Collections.ArrayList individualCararraylist = new System.Collections.ArrayList();
                str = content;
                str = content.Replace('\n', ' ');
                System.Text.RegularExpressions.MatchCollection regexindividualCollec = null;
                regexindividualCollec = regexindividual.Matches(str);
                individualCararraylist.Clear();
                individualCararraylist.InsertRange(individualCararraylist.Count, regexindividualCollec);

                for (int x = 0; x < individualCararraylist.Count; x++)
                {


                    string snextURl = individualCararraylist[x].ToString();

                    char[] sep = { '<' };

                    string[] sSplit = snextURl.Split(sep);

                    string subURL = string.Empty;
                    subURL = sSplit[4].Replace("a href=\"", "");
                    // .Split("href=".ToString());
                    int index = subURL.IndexOf(">");

                    int Endindex = sSplit[2].IndexOf(">");

                    string sMainUrl = subURL.ToString().Substring(0, index);


                    sMainUrl = sMainUrl.Replace("\"", "");

                    System.Collections.ArrayList Modellist = new System.Collections.ArrayList();

                    Regex regexobjState = new Regex("<font size=\"-1\">(.*?)</font>");
                    str = snextURl;
                    str = snextURl.Replace('\n', ' ');
                    System.Text.RegularExpressions.MatchCollection regexindividualModel = null;
                    regexindividualModel = regexobjState.Matches(str);
                    Modellist.Clear();
                    Modellist.InsertRange(Modellist.Count, regexindividualModel);

                    string sModel = sSplit[4];

                    index = sModel.IndexOf(">");

                    sModel = sModel.Substring(index, sModel.Length - index);

                    sModel = sModel.Replace(">", "");
                    sModel = sModel.Replace("-", "");


                    string sPrice = sSplit[5].Replace("/a> \t\t\t ", "");


                    FillCurrentPageData(sMainUrl);


                    Regex regexindividual1 = new Regex("<div id=\"userbody\">(.*?)</div>");



                    System.Collections.ArrayList individualCararraylist1 = new System.Collections.ArrayList();
                    str = content;
                    str = content.Replace('\n', ' ');
                    System.Text.RegularExpressions.MatchCollection regexindividualCollec1 = null;
                    regexindividualCollec1 = regexindividual1.Matches(str);
                    individualCararraylist1.Clear();
                    individualCararraylist1.InsertRange(individualCararraylist1.Count, regexindividualCollec1);

                    string vehicleDesc = string.Empty;
                    if (individualCararraylist1.Count != 0)
                    {

                        vehicleDesc = individualCararraylist1[0].ToString().Replace("<div id=\"userbody\">", "");

                        //vehicleDesc = vehicleDesc.Replace("<br><br><ul class=\"blurbs\"> <li> <!-- CLTAG GeographicArea=san angelo -->Location: san angelo <li>it's NOT ok to contact this poster with services or other commercial interests</ul> <!-- END CLTAGS -->\t\t<table summary=\"craigslist hosted images\"> \t\t\t<tr> \t\t\t\t<td align=\"center\"><img src=\"http://images.craigslist.org/5Z55W65P23nc3p73l9ba5c963ebbeb7f815c8.jpg\" alt=\"image 0\"></td> \t\t\t\t<td align=\"center\"><img src=\"http://images.craigslist.org/5O35Z55Q13ma3o13l3ba5781c2c967e7b1d99.jpg\" alt=\"image 1\"></td> \t\t\t</tr> \t\t\t<tr> \t\t\t\t<td align=\"center\"><img src=\"http://images.craigslist.org/5O35Y25R23n53m33laba51c82d73ac3d9146e.jpg\" alt=\"image 2\"></td> \t\t\t\t<td align=\"center\"><img src=\"http://images.craigslist.org/5O45P35X03m83pd3l2ba5d3be8335fad61282.jpg\" alt=\"image 3\"></td> \t\t\t</tr> \t\t</table>  </div>", "");

                        index = vehicleDesc.IndexOf("<table");
                        if (index != -1)
                        {
                            vehicleDesc = vehicleDesc.Substring(0, index);
                        }

                    }

                    string[] sPostingId = sMainUrl.Split('/');
                    string sPosting = string.Empty;

                    if (sPostingId.Length == 6)
                    {
                        sPosting = sPostingId[5].Replace(".html", "");
                    }
                    else if (sPostingId.Length == 5)
                    {

                        sPosting = sPostingId[4].Replace(".html", "");
                    }

                    string CollectedFromState = CCityNames.Text.ToString();

                    string sentence = vehicleDesc;
                    //
                    // Get all digit sequence as strings from data(Description).
                    //
                    string[] digits = Regex.Split(sentence, @"\D+");

                    string PhoneNumber = string.Empty;

                    for (int p = 0; p < digits.Length; p++)
                    {
                        if ((digits[p].Length == 3 && digits[p + 1].Length == 3 && digits[p + 2].Length == 4) || (digits[p].Length == 10))
                        {
                            if (digits[p].Length == 3 && digits[p + 1].Length == 3 && digits[p + 2].Length == 4)
                            {
                                PhoneNumber = digits[p] + digits[p + 1] + digits[p + 2];


                            }
                            else if (digits[p].Length == 10)
                            {

                                if (sPosting == PhoneNumber)
                                {
                                    PhoneNumber = "";
                                }
                                else
                                {
                                    PhoneNumber = digits[p];
                                }
                            }
                        }
                    }
                    vehicleDesc = vehicleDesc.Replace("http://", "");
                    vehicleDesc = vehicleDesc.Replace("<br>", "");
                    vehicleDesc = vehicleDesc.Replace("<", "");
                    vehicleDesc = vehicleDesc.Replace(">", "");
                    vehicleDesc = vehicleDesc.Replace("<a href=", "");
                    vehicleDesc = vehicleDesc.Replace("<li>", "");
                    vehicleDesc = vehicleDesc.Replace("/", "");

                    string CusEmailId = string.Empty;

                    System.Collections.ArrayList vehicleMainDesclist = new System.Collections.ArrayList();
                    Regex regexobjvehicleMain = new Regex("<span class=\"returnemail\">(.*?)</span>");
                    str = content;
                    str = content.Replace('\n', ' ');
                    System.Text.RegularExpressions.MatchCollection regexvehicleListMain = null;
                    regexvehicleListMain = regexobjvehicleMain.Matches(str);
                    vehicleMainDesclist.Clear();
                    vehicleMainDesclist.InsertRange(vehicleMainDesclist.Count, regexvehicleListMain);

                    if (vehicleMainDesclist.Count > 0)
                    {
                        CusEmailId = vehicleMainDesclist[0].ToString();

                        string[] EmailId = CusEmailId.Split('<');
                        CusEmailId = EmailId[2];
                        EmailId = CusEmailId.Split('>');
                        CusEmailId = EmailId[1];
                    }
                    objDal.SaveLead_Craigslist_RVS(sPrice, sModel, vehicleDesc, sMainUrl, sPosting, CollectedFromState, PhoneNumber, Convert.ToInt32(cmbState.SelectedValue.ToString()), cmbState.Text, CusEmailId);

                    varcount = varcount + 1;
                    label2.Text = Convert.ToInt32(varcount).ToString();


                }
            }
            MessageBox.Show("Leads Collected Successfully change another zipcode");

        }
        private void GetLeadsForcraigslistBikeSAutoSelection(string StateRV, string CityRV)
        {
            #region old
            //try
            //{


            //    int urlNums = 10;
            //    int a = 0, b = 0;

            //    string mainURL = ConfigurationManager.AppSettings["MainUrlCraigslist"].ToString();

            //    //if (CCityNames.SelectedItem != null)
            //    //{
            //    //    mainURL = "http://" + CCityNames.SelectedItem + ".craigslist.org/cgi-bin/autos.cgi?&category=cta/";
            //    //}
            //    //else
            //    {
            //        mainURL = "http://" + StateRV + ".craigslist.org/mca";
            //    }




            //    for (int j = 1; j <= urlNums; j++)
            //    {
            //        a = (j - 1) * 100;


            //        if (CCityNames.Text != "")
            //        {
            //            if (a == 0)
            //            {
            //                // mainURL = "http://" + CityRV + ".craigslist.org/rvs/";
            //                mainURL = "http://" + CityRV + ".craigslist.org/search/mca?query=&srchType=A&minAsk=2500";
            //                //  mainURL = "http://" + CCityNames.Text + ".craigslist.org/search/cto?query=&srchType=T&minAsk=4000&maxAsk=";
            //                //  http://abilene.craigslist.org/search/cto?query=&srchType=T&minAsk=4000&maxAsk=
            //            }
            //            else
            //            {
            //                //mainURL = "http://" + CityRV + ".craigslist.org/rvs/index" + a + ".html";
            //                //a = a * 100;
            //                mainURL = "http://" + CityRV + ".craigslist.org/search/mca?minAsk=2500&srchType=A&s=" + a + "";

            //                //  mainURL = "http://" + CCityNames.Text + ".craigslist.org/search/cto?query=&srchType=T&minAsk=10000&maxAsk=&s=" + a + "";
            //                //  http://abilene.craigslist.org/search/cto?query=&srchType=T&minAsk=4000&maxAsk=&s=100
            //            }
            //        }
            //        else
            //        {
            //            // mainURL = "http://" + StateRV + ".craigslist.org/rvs/";
            //            mainURL = "http://" + StateRV + ".craigslist.org/search/mca?query=&srchType=A&minAsk=2500";
            //            //  mainURL = "http://" + cmbState.Text + ".craigslist.org/search/cto?query=&srchType=T&minAsk=4000&maxAsk=";
            //        }
            //        FillCurrentPageData(mainURL);

            //        String str = string.Empty;


            //        Regex regexindividual = new Regex("<span class=\"pl\">(.*?)</span>(.*?)</span>(.*?)</span>(.*?)</span>");//<p class=\"row\" data-latitude=\"\" data-longitude=\"\">(.*?)</p>");



            //        System.Collections.ArrayList individualCararraylist = new System.Collections.ArrayList();
            //        str = content;
            //        str = content.Replace('\n', ' ');
            //        System.Text.RegularExpressions.MatchCollection regexindividualCollec = null;
            //        regexindividualCollec = regexindividual.Matches(str);
            //        individualCararraylist.Clear();
            //        individualCararraylist.InsertRange(individualCararraylist.Count, regexindividualCollec);

            //        for (int x = 0; x < individualCararraylist.Count; x++)
            //        {


            //            string snextURl = individualCararraylist[x].ToString();

            //            char[] sep = { '<' };

            //            string[] sSplit = snextURl.Split(sep);

            //            string subURL = string.Empty;

            //            for (int s = 0; s < sSplit.Length; s++)
            //            {

            //                if (sSplit[s].Contains("a href=\""))
            //                {
            //                    subURL = sSplit[s].Replace("a href=\"", "");

            //                }
            //            }




            //            //subURL = sSplit[4].Replace("a href=\"", "");
            //            // .Split("href=".ToString());
            //            int index = subURL.IndexOf(">");

            //            int Endindex = subURL.IndexOf(">");

            //            string sMainUrl = subURL.ToString().Substring(0, index);


            //            sMainUrl = sMainUrl.Replace("\"", "");

            //            System.Collections.ArrayList Modellist = new System.Collections.ArrayList();

            //            Regex regexobjState = new Regex("<font size=\"-1\">(.*?)</font>");
            //            str = snextURl;
            //            str = snextURl.Replace('\n', ' ');
            //            System.Text.RegularExpressions.MatchCollection regexindividualModel = null;
            //            regexindividualModel = regexobjState.Matches(str);
            //            Modellist.Clear();
            //            Modellist.InsertRange(Modellist.Count, regexindividualModel);

            //            string sModel = string.Empty;



            //            sModel = subURL.ToString().Substring(Endindex, subURL.Length - index); ;




            //            //sModel = sSplit[4];

            //            index = sModel.IndexOf(">");

            //            sModel = sModel.Substring(index, sModel.Length - index);

            //            sModel = sModel.Replace(">", "");
            //            sModel = sModel.Replace("-", "");


            //            //string sPrice = sSplit[5].Replace("/a> \t\t\t ", "");

            //            string sPrice = string.Empty;

            //            for (int s = 0; s < sSplit.Length; s++)
            //            {

            //                if (sSplit[s].Contains("span class=\"itempp\">"))
            //                {
            //                    sPrice = sSplit[s].Replace("span class=\"itempp\">", "");

            //                }
            //            }



            //            FillCurrentPageData(sMainUrl);


            //            Regex regexindividual1 = new Regex("<section id=\"postingbody\">(.*?)</section>");



            //            System.Collections.ArrayList individualCararraylist1 = new System.Collections.ArrayList();
            //            str = content;
            //            str = content.Replace('\n', ' ');
            //            System.Text.RegularExpressions.MatchCollection regexindividualCollec1 = null;
            //            regexindividualCollec1 = regexindividual1.Matches(str);
            //            individualCararraylist1.Clear();
            //            individualCararraylist1.InsertRange(individualCararraylist1.Count, regexindividualCollec1);

            //            string vehicleDesc = string.Empty;
            //            if (individualCararraylist1.Count != 0)
            //            {

            //                vehicleDesc = individualCararraylist1[0].ToString().Replace("<section id=\"postingbody\">", "");

            //                //vehicleDesc = vehicleDesc.Replace("<br><br><ul class=\"blurbs\"> <li> <!-- CLTAG GeographicArea=san angelo -->Location: san angelo <li>it's NOT ok to contact this poster with services or other commercial interests</ul> <!-- END CLTAGS -->\t\t<table summary=\"craigslist hosted images\"> \t\t\t<tr> \t\t\t\t<td align=\"center\"><img src=\"http://images.craigslist.org/5Z55W65P23nc3p73l9ba5c963ebbeb7f815c8.jpg\" alt=\"image 0\"></td> \t\t\t\t<td align=\"center\"><img src=\"http://images.craigslist.org/5O35Z55Q13ma3o13l3ba5781c2c967e7b1d99.jpg\" alt=\"image 1\"></td> \t\t\t</tr> \t\t\t<tr> \t\t\t\t<td align=\"center\"><img src=\"http://images.craigslist.org/5O35Y25R23n53m33laba51c82d73ac3d9146e.jpg\" alt=\"image 2\"></td> \t\t\t\t<td align=\"center\"><img src=\"http://images.craigslist.org/5O45P35X03m83pd3l2ba5d3be8335fad61282.jpg\" alt=\"image 3\"></td> \t\t\t</tr> \t\t</table>  </div>", "");

            //                index = vehicleDesc.IndexOf("</figure>");
            //                if (index != -1)
            //                {
            //                    vehicleDesc = vehicleDesc.Substring(index, vehicleDesc.Length - index);
            //                }

            //            }

            //            string[] sPostingId = sMainUrl.Split('/');
            //            string sPosting = string.Empty;

            //            if (sPostingId.Length == 6)
            //            {
            //                sPosting = sPostingId[5].Replace(".html", "");
            //            }
            //            else if (sPostingId.Length == 5)
            //            {

            //                sPosting = sPostingId[4].Replace(".html", "");
            //            }

            //            string CollectedFromState = CityRV.ToString();

            //            string sentence = vehicleDesc;
            //            //
            //            // Get all digit sequence as strings from data(Description).
            //            //
            //            string[] digits = Regex.Split(sentence, @"\D+");

            //            string PhoneNumber = string.Empty;

            //            for (int p = 0; p < digits.Length; p++)
            //            {
            //                if ((digits[p].Length == 3 && digits[p + 1].Length == 3 && digits[p + 2].Length == 4) || (digits[p].Length == 10))
            //                {
            //                    if (digits[p].Length == 3 && digits[p + 1].Length == 3 && digits[p + 2].Length == 4)
            //                    {
            //                        PhoneNumber = digits[p] + digits[p + 1] + digits[p + 2];
            //                    }
            //                    else if (digits[p].Length == 10)
            //                    {
            //                       if (sPosting == PhoneNumber)
            //                        {
            //                            PhoneNumber = "";
            //                        }
            //                        else
            //                        {
            //                            PhoneNumber = digits[p];
            //                        }
            //                    }
            //                }
            //            }
            //            vehicleDesc = vehicleDesc.Replace("http://", "");
            //            vehicleDesc = vehicleDesc.Replace("<br>", "");
            //            vehicleDesc = vehicleDesc.Replace("<", "");
            //            vehicleDesc = vehicleDesc.Replace(">", "");
            //            vehicleDesc = vehicleDesc.Replace("<a href=", "");
            //            vehicleDesc = vehicleDesc.Replace("<li>", "");
            //            vehicleDesc = vehicleDesc.Replace("/", "");


            //            string CusEmailId = string.Empty;

            //            System.Collections.ArrayList vehicleMainDesclist = new System.Collections.ArrayList();
            //            Regex regexobjvehicleMain = new Regex("<span class=\"returnemail\">(.*?)</span>");
            //            str = content;
            //            str = content.Replace('\n', ' ');
            //            System.Text.RegularExpressions.MatchCollection regexvehicleListMain = null;
            //            regexvehicleListMain = regexobjvehicleMain.Matches(str);
            //            vehicleMainDesclist.Clear();
            //            vehicleMainDesclist.InsertRange(vehicleMainDesclist.Count, regexvehicleListMain);

            //            if (vehicleMainDesclist.Count > 0)
            //            {
            //                CusEmailId = vehicleMainDesclist[0].ToString();

            //                string[] EmailId = CusEmailId.Split('<');
            //                CusEmailId = EmailId[2];
            //                EmailId = CusEmailId.Split('>');
            //                CusEmailId = EmailId[1];
            //            }

            //            if (PhoneNumber.Length == 10)
            //            {
            //                objDal.SaveLead_Craigslist_RVS(sPrice, sModel, vehicleDesc, sMainUrl, sPosting, CollectedFromState, PhoneNumber, Convert.ToInt32(cmbState.SelectedValue.ToString()), cmbState.Text, CusEmailId);
            //                varcount = varcount + 1;
            //                label2.Text = Convert.ToInt32(varcount).ToString();

            //            }
            //        }
            //   }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}
            #endregion
            #region new


            varcount = 0;
            int urlNums = 25;
            int a = 0, b = 0; string Modellist1 = "";
            string sprice = ""; string sPosting = "  "; string CollectedFromState = "";
            string CusEmailId = string.Empty;
            string date = "";

            string mainURL = ConfigurationManager.AppSettings["MainUrlCraigslist"].ToString();
            {
                mainURL = "http://" + StateRV + ".craigslist.org/mca";
            }
            if (stopclrv)
            {
                for (int j = 1; j <= urlNums; j++)
                {
                    if (stopclrv)
                    {
                        a = (j - 1) * 100;
                        if (CCityNames.Text != "")
                        {
                            if (a == 0)
                            {
                                // mainURL = "http://" + CityRV + ".craigslist.org/rvs/";
                                mainURL = "http://" + CityRV + ".craigslist.org/search/mca?query=&srchType=A&minAsk=2500";
                                //  mainURL = "http://" + CCityNames.Text + ".craigslist.org/search/cto?query=&srchType=T&minAsk=4000&maxAsk=";
                                //  http://abilene.craigslist.org/search/cto?query=&srchType=T&minAsk=4000&maxAsk=
                            }
                            else
                            {
                                //mainURL = "http://" + CityRV + ".craigslist.org/rvs/index" + a + ".html";
                                //a = a * 100;
                                mainURL = "http://" + CityRV + ".craigslist.org/search/mca?minAsk=2500&srchType=A&s=" + a + "";

                                //  mainURL = "http://" + CCityNames.Text + ".craigslist.org/search/cto?query=&srchType=T&minAsk=10000&maxAsk=&s=" + a + "";
                                //  http://abilene.craigslist.org/search/cto?query=&srchType=T&minAsk=4000&maxAsk=&s=100
                            }
                        }
                        else
                        {
                            // mainURL = "http://" + StateRV + ".craigslist.org/rvs/";
                            mainURL = "http://" + StateRV + ".craigslist.org/search/mca?query=&srchType=A&minAsk=2500";
                            //  mainURL = "http://" + cmbState.Text + ".craigslist.org/search/cto?query=&srchType=T&minAsk=4000&maxAsk=";
                        }
                        FillCurrentPageData(mainURL);
                        String str = string.Empty;

                        Regex regexindividual = new Regex("<span class=\"pl\">(.*?)</span>(.*?)</span>(.*?)</span>(.*?)</span>");
                        System.Collections.ArrayList individualCararraylist = new System.Collections.ArrayList();
                        str = content;
                        str = content.Replace('\n', ' ');
                        System.Text.RegularExpressions.MatchCollection regexindividualCollec = null;
                        regexindividualCollec = regexindividual.Matches(str);
                        individualCararraylist.Clear();
                        individualCararraylist.InsertRange(individualCararraylist.Count, regexindividualCollec);

                        for (int x = 0; x < individualCararraylist.Count; x++)
                        {
                            if (stopclrv)
                            {
                                Regex dateregex = new Regex("<span class=\"date\">(.*?)</span>");
                                System.Collections.ArrayList datelist = new System.Collections.ArrayList();
                                str = individualCararraylist[x].ToString();
                                str = str.Replace('\n', ' ');
                                System.Text.RegularExpressions.MatchCollection dateregexmatch = null;
                                dateregexmatch = dateregex.Matches(str);
                                datelist.Clear();
                                datelist.InsertRange(datelist.Count, dateregexmatch);
                                for (int abc = 0; abc < datelist.Count; abc++)
                                {
                                    date = datelist[abc].ToString().Replace("<span class=\"date\">", "");
                                    date = date.Replace("</span>", "");
                                    DateTime new1 = DateTime.Parse(date);
                                    new1 = new1.Date + ts;
                                    if (!(new1 >= edate && new1 <= sdate))
                                    {
                                        return;
                                    }
                                    else
                                    {
                                        #region for
                                        String SubURL3 = individualCararraylist[x].ToString();
                                        int tindex = SubURL3.IndexOf("<a href=");
                                        int etindex = SubURL3.Length;
                                        string SubURL1 = SubURL3.ToString().Substring(tindex, etindex - tindex);
                                        int tindex1 = SubURL1.IndexOf("\"");
                                        int etindex1 = SubURL1.IndexOf(">");
                                        string SubURL2 = SubURL1.ToString().Substring(tindex1, etindex1 - tindex1);
                                        string sMainUrl = SubURL2.Replace("\"", "");
                                        sMainUrl = "http://" + CityRV + ".craigslist.org" + sMainUrl;
                                        FillCurrentPageData(sMainUrl);
                                        string Details = string.Empty;
                                        Regex CarData = new Regex("<section id=\"postingbody\">(.*?)</section>");
                                        // Regex CarData = new Regex("<section class=\"userbody\">(.*?)</section>(.*?)</section>(.*?)</section>");
                                        System.Collections.ArrayList individualpnslyvmailarraylistURL = new System.Collections.ArrayList();
                                        Details = content;
                                        Details = content.Replace('\n', ' ');
                                        System.Text.RegularExpressions.MatchCollection regexindividualpnslyvmailCollecURL = null;
                                        regexindividualpnslyvmailCollecURL = CarData.Matches(Details);
                                        individualpnslyvmailarraylistURL.Clear();
                                        individualpnslyvmailarraylistURL.InsertRange(individualpnslyvmailarraylistURL.Count, regexindividualpnslyvmailCollecURL);
                                        string vehicleDesc = string.Empty;
                                        if (individualpnslyvmailarraylistURL.Count != 0)
                                        {
                                            vehicleDesc = individualpnslyvmailarraylistURL[0].ToString().Replace("<section id=\"postingbody\">", "");
                                            vehicleDesc = vehicleDesc.Replace("</section>", "");
                                            vehicleDesc = vehicleDesc.Replace("\t", "");
                                            vehicleDesc = vehicleDesc.Replace("<br>", "");
                                            vehicleDesc = vehicleDesc.Replace("=&gt;", "");//.Trim();
                                        }
                                        string sentence = vehicleDesc;//.Replace(" ","").Trim();
                                        string[] digits = Regex.Split(sentence, @"\D+");
                                        string PhoneNumber = string.Empty;

                                        for (int p = 0; p < digits.Length; p++)
                                        {
                                            if (digits[p].Length == 10)
                                            {
                                                if (sPosting == PhoneNumber)
                                                {
                                                    PhoneNumber = "";
                                                }
                                                else
                                                {
                                                    PhoneNumber = digits[p];
                                                }
                                            }
                                            else if (digits[p].Length == 3 && digits[p + 1].Length == 3 && digits[p + 2].Length == 4)
                                            {
                                                PhoneNumber = digits[p] + digits[p + 1] + digits[p + 2];
                                            }

                                            else if (digits[p].Length == 3 && digits[p + 1].Length == 7)
                                            {
                                                PhoneNumber = digits[p] + digits[p + 1];
                                            }
                                        }
                                        if (PhoneNumber == "")
                                        {
                                            sentence = sentence.ToLower(); sentence = sentence.Replace(" ", "").Trim();
                                            sentence = sentence.Replace("one", "1"); sentence = sentence.Replace("two", "2"); sentence = sentence.Replace("three", "3");
                                            sentence = sentence.Replace("four", "4"); sentence = sentence.Replace("five", "5"); sentence = sentence.Replace("six", "6");
                                            sentence = sentence.Replace("seven", "7"); sentence = sentence.Replace("eight", "8"); sentence = sentence.Replace("nine", "9");
                                            sentence = sentence.Replace("zero", "0"); sentence = sentence.Replace("o", "0");

                                            sentence = Regex.Replace(sentence, @"[^a-zA-Z0-9]", "");
                                            digits = Regex.Split(sentence, @"\D+");
                                            string PhoneNumber1 = string.Empty;

                                            for (int p = 0; p < digits.Length; p++)
                                            {
                                                if (digits[p].Length == 10)
                                                {
                                                    if (sPosting == PhoneNumber)
                                                    {
                                                        PhoneNumber = "";
                                                    }
                                                    else
                                                    {
                                                        PhoneNumber = digits[p];
                                                    }
                                                }
                                                if (p + 1 < digits.Length)
                                                {
                                                    if ((p + 2 < digits.Length))
                                                    {
                                                        if (digits[p].Length == 3 && digits[p + 1].Length == 3 && digits[p + 2].Length == 4)
                                                        {
                                                            PhoneNumber = digits[p] + digits[p + 1] + digits[p + 2];
                                                        }
                                                    }
                                                    else if (digits[p].Length == 3 && digits[p + 1].Length == 7)
                                                    {
                                                        PhoneNumber = digits[p] + digits[p + 1];
                                                    }
                                                }
                                                else if (digits[p].Length == 11)
                                                {
                                                    PhoneNumber = digits[p];
                                                    if (PhoneNumber[0] == 0)
                                                    {
                                                        PhoneNumber = PhoneNumber.Substring(1);
                                                    }
                                                    else if (PhoneNumber[10] == 0)
                                                    {
                                                        PhoneNumber = PhoneNumber.Substring(0, 10);
                                                    }
                                                }

                                            }
                                        }
                                        vehicleDesc = vehicleDesc.Replace("http://", "");
                                        vehicleDesc = vehicleDesc.Replace("<br>", "");
                                        vehicleDesc = vehicleDesc.Replace("<", "");
                                        vehicleDesc = vehicleDesc.Replace(">", "");
                                        vehicleDesc = vehicleDesc.Replace("<a href=", "");
                                        vehicleDesc = vehicleDesc.Replace("<li>", "");
                                        vehicleDesc = vehicleDesc.Replace("/", "");
                                        vehicleDesc = vehicleDesc.Replace("'", "");
                                        if (PhoneNumber != "")
                                        {

                                            //FillCurrentPageData("http://miami.craigslist.org/pbc/cto/4160044687.html");
                                            Regex posting = new Regex("<p class=\"postinginfo\">(.*?)</p>");
                                            System.Collections.ArrayList individualpostingmailarraylistURL = new System.Collections.ArrayList();
                                            Details = content;
                                            Details = content.Replace('\n', ' ');
                                            System.Text.RegularExpressions.MatchCollection regexindividualpostingmailCollecURL = null;
                                            regexindividualpostingmailCollecURL = posting.Matches(Details);
                                            individualpostingmailarraylistURL.Clear();
                                            individualpostingmailarraylistURL.InsertRange(individualpostingmailarraylistURL.Count, regexindividualpostingmailCollecURL);
                                            if (individualpostingmailarraylistURL.Count > 0)
                                            {
                                                sPosting = individualpostingmailarraylistURL[1].ToString();
                                                sPosting = sPosting.Replace("<p class=\"postinginfo\">", "");
                                                sPosting = sPosting.Replace("</p>", "");
                                                sPosting = sPosting.Replace("Posting ID:", "");
                                                sPosting = sPosting.Replace("post id:", "");

                                            }
                                            CollectedFromState = CityRV.ToString();
                                            string Ttl = string.Empty;
                                            Regex title = new Regex("<h2 class=\"postingtitle\">(.*?)</h2>");
                                            System.Collections.ArrayList individualtitlemailarraylistURL = new System.Collections.ArrayList();
                                            Ttl = content;
                                            Ttl = content.Replace('\n', ' ');
                                            System.Text.RegularExpressions.MatchCollection regexindividualtitlemailCollecURL = null;
                                            regexindividualtitlemailCollecURL = title.Matches(Ttl);
                                            individualtitlemailarraylistURL.Clear();
                                            individualtitlemailarraylistURL.InsertRange(individualtitlemailarraylistURL.Count, regexindividualtitlemailCollecURL);
                                            if (individualtitlemailarraylistURL.Count > 0)
                                            {
                                                for (int mdl = 0; mdl < individualtitlemailarraylistURL.Count; mdl++)
                                                {
                                                    String Modelcar = individualtitlemailarraylistURL[mdl].ToString();
                                                    string[] sepem = { "$", "&#x0024;" };
                                                    string[] msplit = Modelcar.Split(sepem,StringSplitOptions.None);
                                                    for (int n = 0; n < msplit.Length; n++)
                                                    {
                                                        Modellist1 = msplit[0].ToString();
                                                        if (Modellist1.Contains("</span> "))
                                                        {
                                                            int tindex21 = Modellist1.IndexOf("</span>");
                                                            int etindex21 = Modellist1.Length;
                                                            string ttl = Modellist1.ToString().Substring(tindex21, etindex21 - tindex21);
                                                            Modellist1 = ttl.Replace("</span>", "").Trim();
                                                            Modellist1 = Modellist1.Replace("=&gt;", "").Trim();
                                                            Modellist1 = Modellist1.Replace("'", "");
                                                            if (msplit.Length > 1)
                                                            {
                                                                sprice = msplit[1].ToString();
                                                                sprice = sprice.Replace("</h2>", "");
                                                                char[] sepemm = { ' ' };
                                                                string[] msplit12 = sprice.Split(sepemm);
                                                                sprice = msplit12[0].ToString();
                                                            }
                                                        }
                                                    }
                                                }
                                            }

                                            System.Collections.ArrayList vehicleMainDesclist = new System.Collections.ArrayList();
                                            Regex regexobjvehicleMain = new Regex("<section class=\"dateReplyBar\">(.*?)</section>");
                                            str = content;
                                            str = content.Replace('\n', ' ');
                                            System.Text.RegularExpressions.MatchCollection regexvehicleListMain = null;
                                            regexvehicleListMain = regexobjvehicleMain.Matches(str);
                                            vehicleMainDesclist.Clear();
                                            vehicleMainDesclist.InsertRange(vehicleMainDesclist.Count, regexvehicleListMain);
                                            if (vehicleMainDesclist.Count > 0)
                                            {
                                                CusEmailId = vehicleMainDesclist[0].ToString();
                                                string[] EmailId = CusEmailId.Split('<');
                                                CusEmailId = EmailId[9];
                                                if (CusEmailId.Contains("@"))
                                                {
                                                    int tindex3 = CusEmailId.IndexOf("mailto:");
                                                    int etindex3 = CusEmailId.IndexOf("?");
                                                    CusEmailId = CusEmailId.ToString().Substring(tindex3, etindex3 - tindex3);
                                                    CusEmailId = CusEmailId.Replace("mailto:", "");
                                                    CusEmailId = CusEmailId.Replace("aside class=\"flags\">", "");

                                                }
                                            }
                                            if (vehicleMainDesclist.Count == 0)
                                            {
                                                System.Collections.ArrayList vehicleMainDesclist1 = new System.Collections.ArrayList();
                                                Regex regexobjvehicleMain1 = new Regex("<div id=\"returnemail\">(.*?)</div>");
                                                str = content;
                                                str = content.Replace('\n', ' ');
                                                System.Text.RegularExpressions.MatchCollection regexvehicleListMain1 = null;
                                                regexvehicleListMain1 = regexobjvehicleMain1.Matches(str);
                                                vehicleMainDesclist1.Clear();
                                                vehicleMainDesclist1.InsertRange(vehicleMainDesclist1.Count, regexvehicleListMain1);
                                                if (vehicleMainDesclist1.Count > 0)
                                                {
                                                    CusEmailId = vehicleMainDesclist1[0].ToString();
                                                    string[] EmailId = CusEmailId.Split('<');
                                                    CusEmailId = EmailId[9];
                                                    EmailId = CusEmailId.Split('>');
                                                    CusEmailId = EmailId[1];
                                                    CusEmailId = CusEmailId.Replace("aside class=\"flags\">", "");
                                                }
                                            }

                                            if (vehicleMainDesclist.Count == 0)
                                            {

                                                System.Collections.ArrayList vehicleMainDesclist1 = new System.Collections.ArrayList();
                                                Regex regexobjvehicleMain1 = new Regex("<div id=\"returnemail\">(.*?)</div>");
                                                str = content;
                                                str = content.Replace('\n', ' ');
                                                System.Text.RegularExpressions.MatchCollection regexvehicleListMain1 = null;
                                                regexvehicleListMain1 = regexobjvehicleMain1.Matches(str);
                                                vehicleMainDesclist1.Clear();
                                                vehicleMainDesclist1.InsertRange(vehicleMainDesclist1.Count, regexvehicleListMain1);

                                                if (vehicleMainDesclist1.Count > 0)
                                                {
                                                    CusEmailId = vehicleMainDesclist1[0].ToString();

                                                    string[] EmailId = CusEmailId.Split('<');
                                                    CusEmailId = EmailId[9];
                                                    EmailId = CusEmailId.Split('>');
                                                    CusEmailId = EmailId[1];
                                                }

                                            }


                                            DataSet ds = new DataSet();
                                            
                                            //objDal.SaveLead_Craigslist_RVS(sprice, Modellist1, vehicleDesc, sMainUrl, sPosting, CollectedFromState, PhoneNumber, stateid, StateRV, CusEmailId);
                                            objDal.SaveLead_Craigslist_RVS(sprice, Modellist1, vehicleDesc, sMainUrl, sPosting, CollectedFromState, PhoneNumber, Convert.ToInt32(cmbState.SelectedValue.ToString()), cmbState.Text, CusEmailId);
                                        }
                                        varcount = varcount + 1;

                                        label2.Text = Convert.ToInt32(varcount).ToString();

                                        //if (varcount > 3)
                                        //{
                                        //    return;
                                        //}
                                        #endregion
                                    }
                                }
                            }
                            else return;
                        }
                    }
                    else return;
                }
            }
            #endregion
        }
        private void GetLeadsForcraigslistRVSAutoSelection(string StateRV, string CityRV, int stateid)
        {
            #region old

            //{
            //    try
            //    {
            //        int urlNums = 10;
            //        int a = 0, b = 0;

            //        string mainURL = ConfigurationManager.AppSettings["MainUrlCraigslist"].ToString();

            //        //if (CCityNames.SelectedItem != null)
            //        //{
            //        //    mainURL = "http://" + CCityNames.SelectedItem + ".craigslist.org/cgi-bin/autos.cgi?&category=cta/";
            //        //}
            //        //else
            //        {
            //            mainURL = "http://" + StateRV + ".craigslist.org/cto";
            //        }




            //        for (int j = 1; j <= urlNums; j++)
            //        {
            //            a = (j - 1) * 100;


            //            if (CCityNames.Text != "")
            //            {
            //                if (a == 0)
            //                {
            //                    // mainURL = "http://" + CityRV + ".craigslist.org/rvs/";
            //                    mainURL = "http://" + CityRV + ".craigslist.org/search/rvs?query=&srchType=A&minAsk=2500";
            //                    //  mainURL = "http://" + CCityNames.Text + ".craigslist.org/search/cto?query=&srchType=T&minAsk=4000&maxAsk=";
            //                    //  http://abilene.craigslist.org/search/cto?query=&srchType=T&minAsk=4000&maxAsk=
            //                }
            //                else
            //                {
            //                    //mainURL = "http://" + CityRV + ".craigslist.org/rvs/index" + a + ".html";
            //                    //a = a * 100;
            //                    mainURL = "http://" + CityRV + ".craigslist.org/search/rvs?minAsk=2500&srchType=A&s=" + a + "";

            //                    //  mainURL = "http://" + CCityNames.Text + ".craigslist.org/search/cto?query=&srchType=T&minAsk=10000&maxAsk=&s=" + a + "";
            //                    //  http://abilene.craigslist.org/search/cto?query=&srchType=T&minAsk=4000&maxAsk=&s=100
            //                }
            //            }
            //            else
            //            {
            //                // mainURL = "http://" + StateRV + ".craigslist.org/rvs/";
            //                mainURL = "http://" + StateRV + ".craigslist.org/search/rva?query=&srchType=A&minAsk=2500";
            //                //  mainURL = "http://" + cmbState.Text + ".craigslist.org/search/cto?query=&srchType=T&minAsk=4000&maxAsk=";
            //            }
            //            FillCurrentPageData(mainURL);

            //            String str = string.Empty;


            //            // Regex regexindividual = new Regex("<span class=\"title1\">(.*?)</span>(.*?)</span>(.*?)</span>");
            //            //  Regex regexindividual = new Regex("");
            //            Regex regexindividual = new Regex("<span class=\"pl\">(.*?)</span>(.*?)</span>(.*?)</span>");

            //            System.Collections.ArrayList individualCararraylist = new System.Collections.ArrayList();
            //            str = content;
            //            str = content.Replace('\n', ' ');
            //            System.Text.RegularExpressions.MatchCollection regexindividualCollec = null;
            //            regexindividualCollec = regexindividual.Matches(str);
            //            individualCararraylist.Clear();
            //            individualCararraylist.InsertRange(individualCararraylist.Count, regexindividualCollec);

            //            for (int x = 0; x < individualCararraylist.Count; x++)
            //            {
            //                string snextURl = individualCararraylist[x].ToString();

            //                char[] sep = { '<' };

            //                string[] sSplit = snextURl.Split(sep);

            //                string subURL = string.Empty;

            //                for (int s = 0; s < sSplit.Length; s++)
            //                {

            //                    if (sSplit[s].Contains("a href=\""))
            //                    {
            //                        subURL = sSplit[s].Replace("a href=\"", "");

            //                    }
            //                }
            //                //subURL = sSplit[4].Replace("a href=\"", "");
            //                // .Split("href=".ToString());
            //                int index = subURL.IndexOf(">");

            //                int Endindex = subURL.IndexOf(">");

            //                string sMainUrl = subURL.ToString().Substring(0, index);


            //                sMainUrl = sMainUrl.Replace("\"", "");
            //                sMainUrl = "http://" + CityRV + ".craigslist.org" + sMainUrl;


            //                System.Collections.ArrayList Modellist = new System.Collections.ArrayList();

            //                Regex regexobjState = new Regex("<font size=\"-1\">(.*?)</font>");
            //                str = snextURl;
            //                str = snextURl.Replace('\n', ' ');
            //                System.Text.RegularExpressions.MatchCollection regexindividualModel = null;
            //                regexindividualModel = regexobjState.Matches(str);
            //                Modellist.Clear();
            //                Modellist.InsertRange(Modellist.Count, regexindividualModel);

            //                string sModel = string.Empty;



            //                sModel = subURL.ToString().Substring(Endindex, subURL.Length - index); ;




            //                //sModel = sSplit[4];

            //                index = sModel.IndexOf(">");

            //                sModel = sModel.Substring(index, sModel.Length - index);

            //                sModel = sModel.Replace(">", "");
            //                sModel = sModel.Replace("-", "");


            //                //string sPrice = sSplit[5].Replace("/a> \t\t\t ", "");

            //                string sPrice = string.Empty;
            //                FillCurrentPageData(sMainUrl);
            //                string Ttl = string.Empty;
            //                Regex title = new Regex("<h2 class=\"postingtitle\">(.*?)</h2>");
            //                // Regex CarData = new Regex("<section class=\"userbody\">(.*?)</section>(.*?)</section>(.*?)</section>");
            //                System.Collections.ArrayList individualtitlemailarraylistURL = new System.Collections.ArrayList();
            //                Ttl = content;
            //                Ttl = content.Replace('\n', ' ');
            //                System.Text.RegularExpressions.MatchCollection regexindividualtitlemailCollecURL = null;
            //                regexindividualtitlemailCollecURL = title.Matches(Ttl);
            //                individualtitlemailarraylistURL.Clear();
            //                individualtitlemailarraylistURL.InsertRange(individualtitlemailarraylistURL.Count, regexindividualtitlemailCollecURL);


            //                if (individualtitlemailarraylistURL.Count > 0)
            //                {
            //                    for (int mdl = 0; mdl < individualtitlemailarraylistURL.Count; mdl++)
            //                    {
            //                        String Modelcar = individualtitlemailarraylistURL[mdl].ToString();
            //                        char[] sepem = { '$' };
            //                        string[] msplit = Modelcar.Split(sepem);

            //                        for (int n = 0; n < msplit.Length; n++)
            //                        {
            //                            // Modellist1 = msplit[0].ToString();
            //                            // Modellist1 = Modellist1.Replace("<h2 class=\"postingtitle\">", "");

            //                            sPrice = msplit[1].ToString();

            //                            sPrice = sPrice.Replace("</h2>", "");
            //                            char[] sepemm = { ' ' };
            //                            string[] msplit12 = sPrice.Split(sepemm);
            //                            sPrice = msplit12[0].ToString();


            //                        }

            //                    }
            //                }
            //                Regex regexindividual1 = new Regex("<section id=\"postingbody\">(.*?)</section>");
            //                System.Collections.ArrayList individualCararraylist1 = new System.Collections.ArrayList();
            //                str = content;
            //                str = content.Replace('\n', ' ');
            //                System.Text.RegularExpressions.MatchCollection regexindividualCollec1 = null;
            //                regexindividualCollec1 = regexindividual1.Matches(str);
            //                individualCararraylist1.Clear();
            //                individualCararraylist1.InsertRange(individualCararraylist1.Count, regexindividualCollec1);
            //                string vehicleDesc = string.Empty;
            //                if (individualCararraylist1.Count != 0)
            //                {
            //                    vehicleDesc = individualCararraylist1[0].ToString().Replace("<section id=\"postingbody\">", "");
            //                    vehicleDesc = vehicleDesc.Replace("</section>", "");
            //                    vehicleDesc = vehicleDesc.Replace("\t", "");
            //                    vehicleDesc = vehicleDesc.Replace("<br>", "");
            //                }

            //                string[] sPostingId = sMainUrl.Split('/');
            //                string sPosting = string.Empty;

            //                if (sPostingId.Length == 6)
            //                {
            //                    sPosting = sPostingId[5].Replace(".html", "");
            //                }
            //                else if (sPostingId.Length == 5)
            //                {

            //                    sPosting = sPostingId[4].Replace(".html", "");
            //                }

            //                string CollectedFromState = CityRV.ToString();

            //                string sentence = vehicleDesc;
            //                //
            //                // Get all digit sequence as strings from data(Description).
            //                //
            //                string[] digits = Regex.Split(sentence, @"\D+");

            //                string PhoneNumber = string.Empty;

            //                for (int p = 0; p < digits.Length; p++)
            //                {
            //                    if ((digits[p].Length == 3 && digits[p + 1].Length == 3 && digits[p + 2].Length == 4) || (digits[p].Length == 10))
            //                    {
            //                        if (digits[p].Length == 3 && digits[p + 1].Length == 3 && digits[p + 2].Length == 4)
            //                        {
            //                            PhoneNumber = digits[p] + digits[p + 1] + digits[p + 2];


            //                        }
            //                        else if (digits[p].Length == 10)
            //                        {

            //                            if (sPosting == PhoneNumber)
            //                            {
            //                                PhoneNumber = "";
            //                            }
            //                            else
            //                            {
            //                                PhoneNumber = digits[p];
            //                            }
            //                        }
            //                    }
            //                }
            //                vehicleDesc = vehicleDesc.Replace("http://", "");
            //                vehicleDesc = vehicleDesc.Replace("<br>", "");
            //                vehicleDesc = vehicleDesc.Replace("<", "");
            //                vehicleDesc = vehicleDesc.Replace(">", "");
            //                vehicleDesc = vehicleDesc.Replace("<a href=", "");
            //                vehicleDesc = vehicleDesc.Replace("<li>", "");
            //                vehicleDesc = vehicleDesc.Replace("/", "");


            //                string CusEmailId = string.Empty;//<section class=\"dateReplyBar\">

            //                System.Collections.ArrayList vehicleMainDesclist = new System.Collections.ArrayList();
            //                Regex regexobjvehicleMain = new Regex("<section class=\"dateReplyBar\">(.*?)</section>");
            //                str = content;
            //                str = content.Replace('\n', ' ');
            //                System.Text.RegularExpressions.MatchCollection regexvehicleListMain = null;
            //                regexvehicleListMain = regexobjvehicleMain.Matches(str);
            //                vehicleMainDesclist.Clear();
            //                vehicleMainDesclist.InsertRange(vehicleMainDesclist.Count, regexvehicleListMain);

            //                if (vehicleMainDesclist.Count > 0)
            //                {
            //                    CusEmailId = vehicleMainDesclist[0].ToString();

            //                    string[] EmailId = CusEmailId.Split('<');
            //                    CusEmailId = EmailId[9];
            //                    EmailId = CusEmailId.Split('>');
            //                    //if (CusEmailId.Contains("@"))
            //                    //{
            //                    //    int tindex3 = CusEmailId.IndexOf("mailto:");
            //                    //    int etindex3 = CusEmailId.IndexOf("?");
            //                    //    CusEmailId = CusEmailId.ToString().Substring(tindex3, etindex3 - tindex3);
            //                    //    CusEmailId = CusEmailId.Replace("mailto:", "");
            //                    CusEmailId = EmailId[1];
            //                    //}
            //                }
            //                if (PhoneNumber.Length == 10)
            //                {
            //                    objDal.SaveLead_Craigslist_RVS(sPrice, sModel, vehicleDesc, sMainUrl, sPosting, CollectedFromState, PhoneNumber, Convert.ToInt32(cmbState.SelectedValue.ToString()), cmbState.Text, CusEmailId);
            //                    varcount = varcount + 1;
            //                    label2.Text = Convert.ToInt32(varcount).ToString();

            //                }


            //            }
            //        }


            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.ToString());
            //    }
            //}
            #endregion
            #region new

            
                varcount = 0;
                int urlNums = 25;
                int a = 0, b = 0; string Modellist1 = "";
                string sprice = ""; string sPosting = "  "; string CollectedFromState = "";
                string CusEmailId = string.Empty;
                string date = "";

                string mainURL = ConfigurationManager.AppSettings["MainUrlCraigslist"].ToString();
                {
                    mainURL = "http://" + StateRV + ".craigslist.org/cto";
                }
                if (stopclrv)
                {
                    for (int j = 1; j <= urlNums; j++)
                    {
                        if (stopclrv)
                        {
                            a = (j - 1) * 100;
                            if (CCityNames.Text != "")
                            {
                                if (a == 0)
                                {
                                    mainURL = "http://" + CityRV + ".craigslist.org/search/rvs?query=&srchType=A&minAsk=2500";
                                }
                                else
                                {
                                    mainURL = "http://" + CityRV + ".craigslist.org/search/rvs?minAsk=2500&srchType=A&s=" + a + "";
                                }
                            }
                            else
                            {
                                // mainURL = "http://" + StateRV + ".craigslist.org/rvs/";
                                mainURL = "http://" + StateRV + ".craigslist.org/search/rva?query=&srchType=A&minAsk=2500";
                                //  mainURL = "http://" + cmbState.Text + ".craigslist.org/search/cto?query=&srchType=T&minAsk=4000&maxAsk=";
                            }
                            FillCurrentPageData(mainURL);
                            String str = string.Empty;

                            Regex regexindividual = new Regex("<span class=\"pl\">(.*?)</span>(.*?)</span>(.*?)</span>(.*?)</span>");
                            System.Collections.ArrayList individualCararraylist = new System.Collections.ArrayList();
                            str = content;
                            str = content.Replace('\n', ' ');
                            System.Text.RegularExpressions.MatchCollection regexindividualCollec = null;
                            regexindividualCollec = regexindividual.Matches(str);
                            individualCararraylist.Clear();
                            individualCararraylist.InsertRange(individualCararraylist.Count, regexindividualCollec);

                            for (int x = 0; x < individualCararraylist.Count; x++)
                            {
                                if (stopclrv)
                                {
                                    Regex dateregex = new Regex("<span class=\"date\">(.*?)</span>");
                                    System.Collections.ArrayList datelist = new System.Collections.ArrayList();
                                    str = individualCararraylist[x].ToString();
                                    str = str.Replace('\n', ' ');
                                    System.Text.RegularExpressions.MatchCollection dateregexmatch = null;
                                    dateregexmatch = dateregex.Matches(str);
                                    datelist.Clear();
                                    datelist.InsertRange(datelist.Count, dateregexmatch);
                                    for (int abc = 0; abc < datelist.Count; abc++)
                                    {
                                        date = datelist[abc].ToString().Replace("<span class=\"date\">", "");
                                        date = date.Replace("</span>", "");
                                        DateTime new1 = DateTime.Parse(date);
                                        new1 = new1.Date + ts;
                                        if (!(new1 >= edate && new1 <= sdate))
                                        {
                                            return;
                                        }
                                        else
                                        {
                                            #region for
                                            String SubURL3 = individualCararraylist[x].ToString();
                                            int tindex = SubURL3.IndexOf("<a href=");
                                            int etindex = SubURL3.Length;
                                            string SubURL1 = SubURL3.ToString().Substring(tindex, etindex - tindex);
                                            int tindex1 = SubURL1.IndexOf("\"");
                                            int etindex1 = SubURL1.IndexOf(">");
                                            string SubURL2 = SubURL1.ToString().Substring(tindex1, etindex1 - tindex1);
                                            string sMainUrl = SubURL2.Replace("\"", "");
                                            sMainUrl = "http://" + CityRV + ".craigslist.org" + sMainUrl;
                                            FillCurrentPageData(sMainUrl);
                                            string Details = string.Empty;
                                            Regex CarData = new Regex("<section id=\"postingbody\">(.*?)</section>");
                                            // Regex CarData = new Regex("<section class=\"userbody\">(.*?)</section>(.*?)</section>(.*?)</section>");
                                            System.Collections.ArrayList individualpnslyvmailarraylistURL = new System.Collections.ArrayList();
                                            Details = content;
                                            Details = content.Replace('\n', ' ');
                                            System.Text.RegularExpressions.MatchCollection regexindividualpnslyvmailCollecURL = null;
                                            regexindividualpnslyvmailCollecURL = CarData.Matches(Details);
                                            individualpnslyvmailarraylistURL.Clear();
                                            individualpnslyvmailarraylistURL.InsertRange(individualpnslyvmailarraylistURL.Count, regexindividualpnslyvmailCollecURL);
                                            string vehicleDesc = string.Empty;
                                            if (individualpnslyvmailarraylistURL.Count != 0)
                                            {
                                                vehicleDesc = individualpnslyvmailarraylistURL[0].ToString().Replace("<section id=\"postingbody\">", "");
                                                vehicleDesc = vehicleDesc.Replace("</section>", "");
                                                vehicleDesc = vehicleDesc.Replace("\t", "");
                                                vehicleDesc = vehicleDesc.Replace("<br>", "");
                                                vehicleDesc = vehicleDesc.Replace("=&gt;", "");//.Trim();
                                            }
                                            string sentence = vehicleDesc;//.Replace(" ","").Trim();
                                            string[] digits = Regex.Split(sentence, @"\D+");
                                            string PhoneNumber = string.Empty;

                                            for (int p = 0; p < digits.Length; p++)
                                            {
                                                if (digits[p].Length == 10)
                                                {
                                                    if (sPosting == PhoneNumber)
                                                    {
                                                        PhoneNumber = "";
                                                    }
                                                    else
                                                    {
                                                        PhoneNumber = digits[p];
                                                    }
                                                }
                                                else if (digits[p].Length == 3 && digits[p + 1].Length == 3 && digits[p + 2].Length == 4)
                                                {
                                                    PhoneNumber = digits[p] + digits[p + 1] + digits[p + 2];
                                                }

                                                else if (digits[p].Length == 3 && digits[p + 1].Length == 7)
                                                {
                                                    PhoneNumber = digits[p] + digits[p + 1];
                                                }
                                            }
                                            if (PhoneNumber == "")
                                            {
                                                sentence = sentence.ToLower(); sentence = sentence.Replace(" ", "").Trim();
                                                sentence = sentence.Replace("one", "1"); sentence = sentence.Replace("two", "2"); sentence = sentence.Replace("three", "3");
                                                sentence = sentence.Replace("four", "4"); sentence = sentence.Replace("five", "5"); sentence = sentence.Replace("six", "6");
                                                sentence = sentence.Replace("seven", "7"); sentence = sentence.Replace("eight", "8"); sentence = sentence.Replace("nine", "9");
                                                sentence = sentence.Replace("zero", "0"); sentence = sentence.Replace("o", "0");

                                                sentence = Regex.Replace(sentence, @"[^a-zA-Z0-9]", "");
                                                digits = Regex.Split(sentence, @"\D+");
                                                string PhoneNumber1 = string.Empty;

                                                for (int p = 0; p < digits.Length; p++)
                                                {
                                                    if (digits[p].Length == 10)
                                                    {
                                                        if (sPosting == PhoneNumber)
                                                        {
                                                            PhoneNumber = "";
                                                        }
                                                        else
                                                        {
                                                            PhoneNumber = digits[p];
                                                        }
                                                    }
                                                    if (p + 1 < digits.Length)
                                                    {
                                                        if ((p + 2 < digits.Length))
                                                        {
                                                            if (digits[p].Length == 3 && digits[p + 1].Length == 3 && digits[p + 2].Length == 4)
                                                            {
                                                                PhoneNumber = digits[p] + digits[p + 1] + digits[p + 2];
                                                            }
                                                        }
                                                        else if (digits[p].Length == 3 && digits[p + 1].Length == 7)
                                                        {
                                                            PhoneNumber = digits[p] + digits[p + 1];
                                                        }
                                                    }
                                                    else if (digits[p].Length == 11)
                                                    {
                                                        PhoneNumber = digits[p];
                                                        if (PhoneNumber[0] == 0)
                                                        {
                                                            PhoneNumber = PhoneNumber.Substring(1);
                                                        }
                                                        else if (PhoneNumber[10] == 0)
                                                        {
                                                            PhoneNumber = PhoneNumber.Substring(0, 10);
                                                        }
                                                    }

                                                }
                                            }
                                            vehicleDesc = vehicleDesc.Replace("http://", "");
                                            vehicleDesc = vehicleDesc.Replace("<br>", "");
                                            vehicleDesc = vehicleDesc.Replace("<", "");
                                            vehicleDesc = vehicleDesc.Replace(">", "");
                                            vehicleDesc = vehicleDesc.Replace("<a href=", "");
                                            vehicleDesc = vehicleDesc.Replace("<li>", "");
                                            vehicleDesc = vehicleDesc.Replace("/", "");
                                            vehicleDesc = vehicleDesc.Replace("'", "");
                                            if (PhoneNumber != "")
                                            {

                                                //FillCurrentPageData("http://miami.craigslist.org/pbc/cto/4160044687.html");
                                                Regex posting = new Regex("<p class=\"postinginfo\">(.*?)</p>");
                                                System.Collections.ArrayList individualpostingmailarraylistURL = new System.Collections.ArrayList();
                                                Details = content;
                                                Details = content.Replace('\n', ' ');
                                                System.Text.RegularExpressions.MatchCollection regexindividualpostingmailCollecURL = null;
                                                regexindividualpostingmailCollecURL = posting.Matches(Details);
                                                individualpostingmailarraylistURL.Clear();
                                                individualpostingmailarraylistURL.InsertRange(individualpostingmailarraylistURL.Count, regexindividualpostingmailCollecURL);
                                                if (individualpostingmailarraylistURL.Count > 0)
                                                {
                                                    sPosting = individualpostingmailarraylistURL[1].ToString();
                                                    sPosting = sPosting.Replace("<p class=\"postinginfo\">", "");
                                                    sPosting = sPosting.Replace("</p>", "");
                                                    sPosting = sPosting.Replace("Posting ID:", "");
                                                    sPosting = sprice.Replace("post id:", "");

                                                }
                                                CollectedFromState = CityRV.ToString();
                                                string Ttl = string.Empty;
                                                Regex title = new Regex("<h2 class=\"postingtitle\">(.*?)</h2>");
                                                System.Collections.ArrayList individualtitlemailarraylistURL = new System.Collections.ArrayList();
                                                Ttl = content;
                                                Ttl = content.Replace('\n', ' ');
                                                System.Text.RegularExpressions.MatchCollection regexindividualtitlemailCollecURL = null;
                                                regexindividualtitlemailCollecURL = title.Matches(Ttl);
                                                individualtitlemailarraylistURL.Clear();
                                                individualtitlemailarraylistURL.InsertRange(individualtitlemailarraylistURL.Count, regexindividualtitlemailCollecURL);
                                                if (individualtitlemailarraylistURL.Count > 0)
                                                {
                                                    for (int mdl = 0; mdl < individualtitlemailarraylistURL.Count; mdl++)
                                                    {
                                                        String Modelcar = individualtitlemailarraylistURL[mdl].ToString();
                                                        string[] sepem = { "$", "&#x0024;" };
                                                        string[] msplit = Modelcar.Split(sepem,StringSplitOptions.None);

                                                        for (int n = 0; n < msplit.Length; n++)
                                                        {
                                                            Modellist1 = msplit[0].ToString();
                                                            if (Modellist1.Contains("</span> "))
                                                            {
                                                                int tindex21 = Modellist1.IndexOf("</span>");
                                                                int etindex21 = Modellist1.Length;
                                                                string ttl = Modellist1.ToString().Substring(tindex21, etindex21 - tindex21);
                                                                Modellist1 = ttl.Replace("</span>", "").Trim();
                                                                Modellist1 = Modellist1.Replace("=&gt;", "").Trim();
                                                                Modellist1 = Modellist1.Replace("'", "");
                                                                if (msplit.Length > 1)
                                                                {
                                                                    sprice = msplit[1].ToString();
                                                                    sprice = sprice.Replace("</h2>", "");
                                                                    char[] sepemm = { ' ' };
                                                                    string[] msplit12 = sprice.Split(sepemm);
                                                                    sprice = msplit12[0].ToString();
                                                                }
                                                            }
                                                        }
                                                    }
                                                }

                                                System.Collections.ArrayList vehicleMainDesclist = new System.Collections.ArrayList();
                                                Regex regexobjvehicleMain = new Regex("<section class=\"dateReplyBar\">(.*?)</section>");
                                                str = content;
                                                str = content.Replace('\n', ' ');
                                                System.Text.RegularExpressions.MatchCollection regexvehicleListMain = null;
                                                regexvehicleListMain = regexobjvehicleMain.Matches(str);
                                                vehicleMainDesclist.Clear();
                                                vehicleMainDesclist.InsertRange(vehicleMainDesclist.Count, regexvehicleListMain);
                                                if (vehicleMainDesclist.Count > 0)
                                                {
                                                    CusEmailId = vehicleMainDesclist[0].ToString();
                                                    string[] EmailId = CusEmailId.Split('<');
                                                    CusEmailId = EmailId[9];
                                                    if (CusEmailId.Contains("@"))
                                                    {
                                                        int tindex3 = CusEmailId.IndexOf("mailto:");
                                                        int etindex3 = CusEmailId.IndexOf("?");
                                                        CusEmailId = CusEmailId.ToString().Substring(tindex3, etindex3 - tindex3);
                                                        CusEmailId = CusEmailId.Replace("mailto:", "");
                                                        CusEmailId = CusEmailId.Replace("aside class=\"flags\">", "");

                                                    }
                                                }
                                                if (vehicleMainDesclist.Count == 0)
                                                {
                                                    System.Collections.ArrayList vehicleMainDesclist1 = new System.Collections.ArrayList();
                                                    Regex regexobjvehicleMain1 = new Regex("<div id=\"returnemail\">(.*?)</div>");
                                                    str = content;
                                                    str = content.Replace('\n', ' ');
                                                    System.Text.RegularExpressions.MatchCollection regexvehicleListMain1 = null;
                                                    regexvehicleListMain1 = regexobjvehicleMain1.Matches(str);
                                                    vehicleMainDesclist1.Clear();
                                                    vehicleMainDesclist1.InsertRange(vehicleMainDesclist1.Count, regexvehicleListMain1);
                                                    if (vehicleMainDesclist1.Count > 0)
                                                    {
                                                        CusEmailId = vehicleMainDesclist1[0].ToString();
                                                        string[] EmailId = CusEmailId.Split('<');
                                                        CusEmailId = EmailId[9];
                                                        EmailId = CusEmailId.Split('>');
                                                        CusEmailId = EmailId[1];
                                                        CusEmailId = CusEmailId.Replace("aside class=\"flags\">", "");
                                                    }
                                                }

                                                if (vehicleMainDesclist.Count == 0)
                                                {

                                                    System.Collections.ArrayList vehicleMainDesclist1 = new System.Collections.ArrayList();
                                                    Regex regexobjvehicleMain1 = new Regex("<div id=\"returnemail\">(.*?)</div>");
                                                    str = content;
                                                    str = content.Replace('\n', ' ');
                                                    System.Text.RegularExpressions.MatchCollection regexvehicleListMain1 = null;
                                                    regexvehicleListMain1 = regexobjvehicleMain1.Matches(str);
                                                    vehicleMainDesclist1.Clear();
                                                    vehicleMainDesclist1.InsertRange(vehicleMainDesclist1.Count, regexvehicleListMain1);

                                                    if (vehicleMainDesclist1.Count > 0)
                                                    {
                                                        CusEmailId = vehicleMainDesclist1[0].ToString();

                                                        string[] EmailId = CusEmailId.Split('<');
                                                        CusEmailId = EmailId[9];
                                                        EmailId = CusEmailId.Split('>');
                                                        CusEmailId = EmailId[1];
                                                    }

                                                }


                                                DataSet ds = new DataSet();
                                                //objDal.SaveLead_Craigslist(sprice, Modellist1, vehicleDesc, sMainUrl, sPosting, CollectedFromState, PhoneNumber, StateID, StateN, CusEmailId);
                                                objDal.SaveLead_Craigslist_RVS(sprice, Modellist1, vehicleDesc, sMainUrl, sPosting, CollectedFromState, PhoneNumber, stateid, StateRV, CusEmailId);
                                            }
                                            varcount = varcount + 1;

                                            label2.Text = Convert.ToInt32(varcount).ToString();

                                            //if (varcount > 3)
                                            //{
                                            //    return;
                                            //}
                                            #endregion
                                        }
                                    }
                                }
                                else return;
                            }
                        }
                        else return;
                    }
                }
            #endregion
        }
        #endregion craigslistLeadsRVS
        #region AutoTradesLeads
        private void GetLeadsForAutoTrades()
        {

            #region old
            string mainURL = ConfigurationManager.AppSettings["MainUrlAutoTrades"].ToString();

            //string[] makeSet = new string[42];
            //makeSet[0] = "CHEV"; makeSet[1] = "LAN"; makeSet[2] = "REN";
            //makeSet[3] = "YUGO"; makeSet[4] = "DAIHAT"; makeSet[5] = "PEUG";
            //makeSet[6] = "AMC"; makeSet[7] = "AVANTI"; makeSet[9] = "MAYBACH";
            //makeSet[10] = "MERKUR"; makeSet[11] = "STERL"; makeSet[12] = "TRI";
            //makeSet[13] = "GEO"; makeSet[14] = "DAEW"; makeSet[15] = "FIAT";
            //makeSet[16] = "EAGLE"; makeSet[17] = "DELOREAN"; makeSet[18] = "DATSUN";
            //makeSet[19] = "ALFA"; makeSet[20] = "LAM"; makeSet[21] = "RR";
            //makeSet[22] = "LOTUS"; makeSet[23] = "ASTON"; makeSet[24] = "BENTL";
            //makeSet[25] = "ISU"; makeSet[27] = "PLYM"; makeSet[28] = "MAS";
            //makeSet[29] = "SMART"; makeSet[30] = "SUZUKI"; makeSet[31] = "FER";
            //makeSet[32] = "OLDS"; makeSet[33] = "SAAB"; makeSet[34] = "KIA";
            //makeSet[35] = "SCION"; makeSet[36] = "SATURN"; makeSet[37] = "AMGEN";
            //makeSet[38] = "BUICK"; makeSet[39] = "MERC"; makeSet[40] = "HYUND"; makeSet[41] = "MINI";


            //string[] sort = new string[7];
            //sort[1] = "priceDESC"; sort[2] = "priceASC"; sort[3] = "yearDESC";
            //sort[4] = "yearASC"; sort[5] = "mileageDESC"; sort[6] = "mileageASC";

            //string[] StartyearENDYear = new string[55];
            //StartyearENDYear[0] = "start_year=1981&end_year=2012"; StartyearENDYear[1] = "start_year=1981&end_year=2004";
            //StartyearENDYear[2] = "start_year=2005&end_year=2012"; StartyearENDYear[3] = "start_year=1981&end_year=2002";
            //StartyearENDYear[4] = "start_year=2003&end_year=2005"; StartyearENDYear[5] = "start_year=2006&end_year=2012";
            //StartyearENDYear[6] = "start_year=1981&end_year=2001"; StartyearENDYear[7] = "start_year=2002&end_year=2004";
            //StartyearENDYear[8] = "start_year=2005&end_year=2007"; StartyearENDYear[9] = "start_year=2008&end_year=2012";
            //StartyearENDYear[10] = "start_year=1981&end_year=2000"; StartyearENDYear[11] = "start_year=2001&end_year=2003";
            //StartyearENDYear[12] = "start_year=2004&end_year=2005"; StartyearENDYear[13] = "start_year=2006&end_year=2006";
            //StartyearENDYear[14] = "start_year=2007&end_year=2012"; StartyearENDYear[15] = "start_year=1981&end_year=1999";
            //StartyearENDYear[16] = "start_year=2000&end_year=2002"; StartyearENDYear[17] = "start_year=2003&end_year=2004";
            //StartyearENDYear[18] = "start_year=2005&end_year=2006"; StartyearENDYear[19] = "start_year=2007&end_year=2008";
            //StartyearENDYear[20] = "start_year=2009&end_year=2012"; StartyearENDYear[21] = "start_year=1981&end_year=1999";
            //StartyearENDYear[22] = "start_year=2000&end_year=2001"; StartyearENDYear[23] = "start_year=2002&end_year=2003";
            //StartyearENDYear[24] = "start_year=2004&end_year=2005"; StartyearENDYear[25] = "start_year=2006&end_year=2006";
            //StartyearENDYear[26] = "start_year=2007&end_year=2008"; StartyearENDYear[27] = "start_year=2009&end_year=2012";
            //StartyearENDYear[28] = "start_year=1981&end_year=1998"; StartyearENDYear[29] = "start_year=1999&end_year=2001";
            //StartyearENDYear[30] = "start_year=2002&end_year=2003"; StartyearENDYear[31] = "start_year=2004&end_year=2004";
            //StartyearENDYear[32] = "start_year=2005&end_year=2005"; StartyearENDYear[33] = "start_year=2006&end_year=2006";
            //StartyearENDYear[34] = "start_year=2007&end_year=2008"; StartyearENDYear[35] = "start_year=2009&end_year=2012";
            //StartyearENDYear[36] = "start_year=1981&end_year=1998"; StartyearENDYear[37] = "start_year=1999&end_year=2000";
            //StartyearENDYear[38] = "start_year=2001&end_year=2002"; StartyearENDYear[39] = "start_year=2003&end_year=2003";
            //StartyearENDYear[40] = "start_year=2004&end_year=2004"; StartyearENDYear[41] = "start_year=2005&end_year=2005";
            //StartyearENDYear[42] = "start_year=2006&end_year=2006"; StartyearENDYear[43] = "start_year=2007&end_year=2007";
            //StartyearENDYear[44] = "start_year=2008&end_year=2012"; StartyearENDYear[45] = "start_year=1981&end_year=1997";
            //StartyearENDYear[46] = "start_year=1998&end_year=2000"; StartyearENDYear[47] = "start_year=2001&end_year=2002";
            //StartyearENDYear[48] = "start_year=2003&end_year=2003"; StartyearENDYear[49] = "start_year=2004&end_year=2004";
            //StartyearENDYear[50] = "start_year=2005&end_year=2005"; StartyearENDYear[51] = "start_year=2006&end_year=2006";
            //StartyearENDYear[52] = "start_year=2007&end_year=2007"; StartyearENDYear[53] = "start_year=2008&end_year=2008";
            //StartyearENDYear[54] = "start_year=2009&end_year=2012";

            //int a = 0, b = 0;

            ////string mySort = "start_year=2005&end_year=2005";



            ////Static Fixing Values 
            //string lastBeginningYears = "1981";



            #endregion
            string sPin = ConfigurationManager.AppSettings["Zip"].ToString();
            string sState = ConfigurationManager.AppSettings["State"].ToString();
            string sURL1 = "http://www.autotrader.com/fyc/searchresults.jsp?";
            sURL1 = sURL1 + "lastBeginningStartYear=1981&showZipError=y&search_lang=en&start_year=1981&";
            sURL1 = sURL1 + "end_year=2012&dma=LOS_ANGELES_SO&page_location=findacar%3A%3Aispsearchform&search_type=both&body_code=0&";
            sURL1 = sURL1 + "distance=0&default_sort=yearASC&address=90210&rdm=1306449843560&";
            sURL1 = sURL1 + "marketZipError=false&sort_type=priceDESC&make=LAN&num_records=100&";
            sURL1 = sURL1 + "seller_type=p&pager.offset=100&first_record=101";

            int urlNums = 10;
            string sURL = string.Empty;
            //for (int s = 0; s < makeSet.Length; s++)
            //{
            //    for (int r = 0; r < StartyearENDYear.Length; r++)
            //    {
                    for (int j = 1; j <= urlNums; j++)
                    {
                        int a = (j - 1) * 100;
                        int b = a + 1;
                        //sURL = "http://www.autotrader.com/fyc/searchresults.jsp?";
                        //sURL = sURL + "lastBeginningStartYear=" + lastBeginningYears + "&";
                        //sURL = sURL + "showZipError=y&search_lang=en&" + StartyearENDYear[r] + "&dma=" + sState + "&";
                        //sURL = sURL + "page_location=findacar%3A%3Aispsearchform&search_type=both&body_code=0";
                        //sURL = sURL + "&distance=0&default_sort=" + sort[1] + "&address=" + sPin + "&rdm=1306449843560&";
                        //sURL = sURL + "marketZipError=false&sort_type=1&make=" + makeSet[s] + "&num_records=100&";
                        //sURL = sURL + "seller_type=p&pager.offset=" + a + "&first_record=" + b;
                        string surlDummy = string.Empty;
                        surlDummy = "       http://www.autotrader.com/fyc/searchresults.jsp?search_lang=en&start_year=1981&search_type=used";
                        surlDummy = surlDummy + "&distance=75&min_price=4000&rdm=1319191830824&marketZipError=false&sownerid=1389588&lastBeginningStartYear=";
                        surlDummy = surlDummy + "1981&end_year=2015&showZipError=n&dma=" + sState + "&page_location=findacar%3A%3Aispsearchform&body_code=0";
                        surlDummy = surlDummy + "&isFlashPlugin=true&address=" + sPin + "&sort_type=priceDESC&seller_type=p&num_records=25&pager.offset=" + b + "&";
                        surlDummy = surlDummy + "first_record=" + b + "";

                        FillCurrentPageData(surlDummy);

                        String str = string.Empty;
                        Regex regexindividual = new Regex("<div class=\"listing-details\">(.*?)</div>");
                        System.Collections.ArrayList individualCararraylist = new System.Collections.ArrayList();
                        str = content;
                        str = content.Replace('\n', ' ');
                        System.Text.RegularExpressions.MatchCollection regexindividualCollec = null;
                        regexindividualCollec = regexindividual.Matches(str);
                        individualCararraylist.Clear();
                        individualCararraylist.InsertRange(individualCararraylist.Count, regexindividualCollec);
                        for (int x = 0; x < individualCararraylist.Count; x++)
                        {
                            string snextURl = individualCararraylist[x].ToString();
                            snextURl = snextURl.Replace("<div class=\"listing-details\">", "");
                            snextURl = snextURl.Substring(0, snextURl.IndexOf("class"));
                            snextURl = snextURl.Replace("<a href=", "");
                            string sMainUrl = snextURl;
                            sMainUrl = mainURL + sMainUrl;
                            sMainUrl = sMainUrl.Replace("\"", "");

                            FillCurrentPageData(sMainUrl);
                            //FillCurrentPageData(snextURl);
                            string CustomerName = string.Empty;
                            string ModelName = string.Empty;
                            string ModelYear = string.Empty;
                            string PhoneNumber = string.Empty;
                            string PhoneNumber1 = string.Empty;
                            string Address1 = string.Empty;
                            string Address2 = string.Empty;
                            string Price = string.Empty;
                            //Phone Number
                            System.Collections.ArrayList PhoneNolist = new System.Collections.ArrayList();

                            Regex regexobjPhone = new Regex("<h3 id=\"private-seller-phone\" style=\"display:none;\">(.*?)</h3>");
                            str = content;
                            str = content.Replace('\n', ' ');
                            System.Text.RegularExpressions.MatchCollection regexindividualPhoneCollec = null;
                            regexindividualPhoneCollec = regexobjPhone.Matches(str);
                            PhoneNolist.Clear();
                            PhoneNolist.InsertRange(PhoneNolist.Count, regexindividualPhoneCollec);
                            System.Collections.ArrayList PhoneNolist1 = new System.Collections.ArrayList();
                            if (PhoneNolist.Count == 0)
                            {
                                Regex regexobjPhone1 = new Regex("<h3 style=\"display: block;\" id=\"private-seller-phone\">(.*?)</h3>");
                                str = content;
                                str = content.Replace('\n', ' ');
                                System.Text.RegularExpressions.MatchCollection regexindividualPhoneCollec1 = null;
                                regexindividualPhoneCollec1 = regexobjPhone1.Matches(str);
                                PhoneNolist1.Clear();
                                PhoneNolist1.InsertRange(PhoneNolist1.Count, regexindividualPhoneCollec1);
                            }
                            //if (PhoneNolist.Count == 1 || PhoneNolist1.Count == 1)
                            //{
                            //if (PhoneNolist1.Count == 1)
                            //{
                            //    PhoneNumber1 = PhoneNolist1[0].ToString().Replace("<h3 id=\"private-seller-phone\" style=\"display:none;\">", "");
                            //    PhoneNumber1 = PhoneNumber1.Replace("</h3>", "");
                            //    PhoneNumber1 = PhoneNumber1.ToString().Replace("-", "");
                            //    PhoneNumber = PhoneNumber1;
                            //}
                            //else
                            //{
                            //    PhoneNumber = PhoneNolist[0].ToString().Replace("<h3 id=\"private-seller-phone\" style=\"display:none;\">", "");
                            //    PhoneNumber = PhoneNumber.Replace("</h3>", "");
                            //    PhoneNumber = PhoneNumber.ToString().Replace("-", "");
                            //}
                            //Description
                            System.Collections.ArrayList Vehiclelist = new System.Collections.ArrayList();
                            Regex regexobjVehicle = new Regex("<div id=\"vehicle-description\">(.*?)</div>");
                            str = content;
                            str = content.Replace('\n', ' ');
                            System.Text.RegularExpressions.MatchCollection regexVehiclelist = null;
                            regexVehiclelist = regexobjVehicle.Matches(str);
                            Vehiclelist.Clear();
                            Vehiclelist.InsertRange(Vehiclelist.Count, regexVehiclelist);

                            string vehicleDesc = string.Empty;
                            if (Vehiclelist.Count != 0)
                            {
                                vehicleDesc = Vehiclelist[0].ToString().Replace("<div id=\"vehicle-description\">                                                   <h4>Seller's Description and Comments</h4>                     <p>", "");
                                vehicleDesc = vehicleDesc.Replace("</p>  ...", "");
                                vehicleDesc = vehicleDesc.Replace("</p>                                                                                                                         <div class=\"top-links\" onclick=\"JavaScript:location.href='#top';\">     <img  src=\"http://www.autotraderstatic.com/img/fyc_AB_0115/icn_back_to_top_arrow_7x11.gif?v=3.26.196505\" width=\"7\" height=\"11\" border=\"0\" alt=\"Top\" />     <span>Top</span> </div>", "");
                            }
                        }
                        //        //Address
                        //        //////System.Collections.ArrayList Sellerlist = new System.Collections.ArrayList();
                        //        //////Regex regexobjSellerInfo = new Regex("<p class=\"private-Seller-Info\">(.*?)</p>");
                        //        //////str = content;
                        //        //////str = content.Replace('\n', ' ');
                        //        //////System.Text.RegularExpressions.MatchCollection regexSellerlist = null;
                        //        //////regexSellerlist = regexobjSellerInfo.Matches(str);
                        //        //////Sellerlist.Clear();
                        //        //////Sellerlist.InsertRange(Sellerlist.Count, regexSellerlist);

                        //        //////string SellerInfo = string.Empty;
                        //        //////SellerInfo = Sellerlist[0].ToString().Replace("<p class=\"private-Seller-Info\">", "");
                        //        //////SellerInfo = SellerInfo.Replace("</p>", "").Trim();
                        //        //////SellerInfo = SellerInfo.Replace("                     ", "");
                        //        //////Address1 = SellerInfo.ToString();

                        //        ////////Car Cost
                        //        //////System.Collections.ArrayList vehicleDeslist = new System.Collections.ArrayList();
                        //        //////Regex regexobjvehicleDes = new Regex("<td class=\"vdp-primary\">(.*?)</td>");
                        //        //////str = content;
                        //        //////str = content.Replace('\n', ' ');
                        //        //////System.Text.RegularExpressions.MatchCollection regexvehicleList = null;
                        //        //////regexvehicleList = regexobjvehicleDes.Matches(str);
                        //        //////vehicleDeslist.Clear();
                        //        //////vehicleDeslist.InsertRange(vehicleDeslist.Count, regexvehicleList);

                        //        //////string VechicleCost = vehicleDeslist[0].ToString().Replace("<td class=\"vdp-primary\">", "");
                        //        //////VechicleCost = VechicleCost.Trim().Replace("</td>", "").Trim();

                        //        //////System.Collections.ArrayList CarIDlist = new System.Collections.ArrayList();
                        //        //////Regex regexobjCarID = new Regex("<p id=\"atc-carid\">(.*?)</p>");
                        //        //////str = content;
                        //        //////str = content.Replace('\n', ' ');
                        //        //////System.Text.RegularExpressions.MatchCollection regexCarIDList = null;
                        //        //////regexCarIDList = regexobjCarID.Matches(str);
                        //        //////CarIDlist.Clear();
                        //        //////CarIDlist.InsertRange(CarIDlist.Count, regexCarIDList);
                        //        //////string scarId = CarIDlist[0].ToString().Replace("<td class=\"vdp-primary\">", "");
                        //        //////scarId = scarId.Replace("<p id=\"atc-carid\">                 <strong>AT Car ID:</strong> ", "");
                        //        //////scarId = scarId.Replace("             </p>", "");

                        //        //Car Description In Details
                        //        System.Collections.ArrayList vehiclelist = new System.Collections.ArrayList();
                        //        Regex regexobjvehicle = new Regex("<table class=\"vehicle-stats\">(.*?)</table>");

                        //        str = content;
                        //        str = content.Replace('\n', ' ');
                        //        System.Text.RegularExpressions.MatchCollection regexvehicleList1 = null;
                        //        regexvehicleList1 = regexobjvehicle.Matches(str);
                        //        vehiclelist.Clear();
                        //        vehiclelist.InsertRange(vehiclelist.Count, regexvehicleList1);
                        //        string Mileage = string.Empty;
                        //        string BodyStyle = string.Empty;
                        //        string ExteriorStyle = string.Empty;
                        //        string InteriorStyle = string.Empty;
                        //        string Engine = string.Empty;
                        //        string Transmission = string.Empty;
                        //        string DriveType = string.Empty;
                        //        string FuelType = string.Empty;
                        //        string Doors = string.Empty;
                        //        string StockNo = string.Empty;
                        //        string VIN = string.Empty;
                        //        string URL = sMainUrl;

                        //        string Vehicle = string.Empty;
                        //        for (int i = 0; i < vehiclelist.Count; i++)
                        //        {
                        //            string tot = vehiclelist[0].ToString().Replace("</td>", "");
                        //            tot = tot.Substring(tot.IndexOf("</div>"));
                        //            tot = tot.Replace("</tr>", "");
                        //            tot = tot.Replace("<td class=\"atcui-label\">", "");
                        //           string[] str2 = Regex.Split(vehiclelist[0].ToString(), "<td>"); ;
                        //            for (int k = 0; k < str2.Length; k++)
                        //            {
                        //                if (k > 0)
                        //                {
                        //                    if (str2[k].IndexOf("Price") > 0)
                        //                    {
                        //                        Price = str2[k + 1];
                        //                        Price = Price.Replace("</td>             </tr>                                                <tr>", "");
                        //                        Price = Price.Replace(" class=\"vdp-primary\">", "").Trim();
                        //                    }
                        //                    else if (str2[k].IndexOf("Mileage") > 0)
                        //                    {
                        //                        Mileage = str2[k + 1].Replace("                                                                                       </td>             </tr>                               <tr>          ", "").Trim();
                        //                        Mileage = Mileage.Replace(">                                                                           ", "");
                        //                    }
                        //                    else if (str2[k].IndexOf("Body Style") > 0)
                        //                    {
                        //                        BodyStyle = str2[k + 1].Replace("</td>                 </tr>                                            <tr>                     ", "");
                        //                        BodyStyle = BodyStyle.Replace(">", "").Trim();
                        //                    }
                        //                    else if (str2[k].IndexOf("Exterior Color") > 0)
                        //                    {
                        //                        ExteriorStyle = str2[k + 1].Replace("</td>                 </tr>                                            <tr>                     ", "");
                        //                        ExteriorStyle = ExteriorStyle.Replace(">", "").Trim();
                        //                    }
                        //                    else if (str2[k].IndexOf("Interior Color") > 0)
                        //                    {
                        //                        InteriorStyle = str2[k + 1].Replace("</td>                 </tr>                                            <tr>                     ", "");
                        //                        InteriorStyle = InteriorStyle.Replace(">", "").Trim();
                        //                    }
                        //                    else if (str2[k].IndexOf("Engine") > 0)
                        //                    {
                        //                        Engine = str2[k + 1].Replace("</td>                 </tr>                                            <tr>                     ", "");
                        //                        Engine = Engine.Replace(">", "").Trim();
                        //                    }
                        //                    else if (str2[k].IndexOf("Transmission") > 0)
                        //                    {
                        //                        Transmission = str2[k + 1].Replace("</td>                 </tr>                                            <tr>                     ", "");
                        //                        Transmission = Transmission.Replace(">", "").Trim();
                        //                    }
                        //                    else if (str2[k].IndexOf("Drive Type") > 0)
                        //                    {
                        //                        DriveType = str2[k + 1].Replace("</td>                 </tr>                                            <tr>                     ", "");
                        //                        DriveType = DriveType.Replace(">", "").Trim();
                        //                    }
                        //                    else if (str2[k].IndexOf("Fuel Type") > 0)
                        //                    {
                        //                        FuelType = str2[k + 1].Replace("</td>                 </tr>                                                          <tr>                     ", ""); ;
                        //                        FuelType = FuelType.Replace(">", "").Trim();
                        //                    }
                        //                    else if (str2[k].IndexOf("Doors") > 0)
                        //                    {
                        //                        Doors = str2[k + 1].Replace("</td>                 </tr>                                                  </table>", "");
                        //                        Doors = Doors.Replace(">", "").Trim();
                        //                    }
                        //                }
                        //            }
                        //        }
                        //        //Vehicle Main Description On Top Page
                        //        System.Collections.ArrayList vehicleMainDesclist = new System.Collections.ArrayList();
                        //        Regex regexobjvehicleMain = new Regex("<div id=\"vehicle-info\">(.*?)</div>");
                        //        str = content;
                        //        str = content.Replace('\n', ' ');
                        //        System.Text.RegularExpressions.MatchCollection regexvehicleListMain = null;
                        //        regexvehicleListMain = regexobjvehicleMain.Matches(str);
                        //        vehicleMainDesclist.Clear();
                        //        vehicleMainDesclist.InsertRange(vehicleMainDesclist.Count, regexvehicleListMain);

                        //        int index2 = vehicleMainDesclist[0].ToString().IndexOf("title=");
                        //        int Endindex2 = vehicleMainDesclist[0].ToString().IndexOf("</h1>         </div>");
                        //        string vehicleMainDesc = vehicleMainDesclist[0].ToString().Substring(index2, Endindex2 - index2);
                        //        index2 = vehicleMainDesc.ToString().IndexOf("Used");
                        //        //Endindex2 = vehicleMainDesclist[0].ToString().IndexOf("</h1>         </div>");
                        //        vehicleMainDesc = vehicleMainDesc.Substring(index2, vehicleMainDesc.Length - index2);
                        //        string LeadID = string.Empty;
                        //        objDal.SaveLead(CustomerName, vehicleMainDesc, ModelYear, PhoneNumber,
                        //        Address1, Address2, Price, Mileage, BodyStyle, ExteriorStyle, InteriorStyle,
                        //        Engine, Transmission, DriveType, FuelType, Doors, StockNo,
                        //        VIN, URL, vehicleDesc, scarId);
                        //        varcount = varcount + 1;
                        //       label2.Text = Convert.ToInt32(varcount).ToString();
                        //    //}
                        //}
                    }
           //     }
           //}
        }
        #endregion AutoTradesLeads
        #region CarPost
        public void GetCarPostLeads(string statename,string zip)
        {
            string re = ""; string str = "";
            if (zip.Length == 4)
                zip = 0 + zip;
            string state = statename.Substring(0, statename.IndexOf(","));
            string city = statename.Replace(state, "");
            city = city.Replace(",", "");
            FillCurrentPageData("http://www.carposts.com/Results.php?Zip=" + zip + "&Distance=25&PerPage=500&Gallery=Yes");
            Regex regexindividual1 = new Regex("<a (.*?)>(.*?)</a>");
            System.Collections.ArrayList individualCararraylist1 = new System.Collections.ArrayList();
            str = content;
            str = content.Replace('\n', ' ');
            System.Text.RegularExpressions.MatchCollection regexindividualCollec1 = null;
            regexindividualCollec1 = regexindividual1.Matches(str);
            individualCararraylist1.Clear();
            individualCararraylist1.InsertRange(individualCararraylist1.Count, regexindividualCollec1);
            
            for (int dj = 2; dj <= individualCararraylist1.Count - 1; dj++)
            {
                
                string title1 = ""; string title2 = ""; string title3 = ""; string title4 = ""; string title5 = "";
                string title6 = ""; string title7 = ""; string title8 = ""; string title9 = ""; string title10 = "";
                string title11 = ""; string title12 = ""; //string zip = "";
                try
                {
                    #region getData
                    string url = individualCararraylist1[dj].ToString();
                    url = url.Substring(0, url.IndexOf(">"));
                    url = url.Replace("<a href=", "");
                    url = url.Replace(">", "");
                    url = url.Replace("'", "");
                    url = "http://www.carposts.com/" + url;
                    FillCurrentPageData(url);//"http://www.carposts.com/AutoDetail.php?AutoID=35488727"
                    Regex regexindividual = new Regex("<tr>(.*?)</tr>");
                    System.Collections.ArrayList individualCararraylist = new System.Collections.ArrayList();
                    str = content;
                    str = content.Replace('\n', ' ');
                    System.Text.RegularExpressions.MatchCollection regexindividualCollec = null;
                    regexindividualCollec = regexindividual.Matches(str);
                    individualCararraylist.Clear();
                    individualCararraylist.InsertRange(individualCararraylist.Count, regexindividualCollec);
                    re = "";
                    for (int x = 0; x < individualCararraylist.Count; x++)
                    {
                        re = re + individualCararraylist[x].ToString() + '^';
                        re = re.Replace("<div><br /></div>", "");
                        re = re.Replace("<div>", "");
                        re = re.Replace("</div>", "");
                        re = re.Replace("<tr>", "");
                        re = re.Replace("</tr>", "");
                        re = re.Replace("colspan=2", "");
                        re = re.Replace("bgcolor=silver", "");
                        re = re.Replace("align=center", "");
                        re = re.Replace("</td>", "");
                    }
                    if (re.IndexOf("<font color=\"Red\">") != -1)
                    {
                        re = re.Substring(re.IndexOf("<font color=\"Red\">"));
                    }
                    else if (re.IndexOf("<font color=Red>") != -1)
                    {
                        re = re.Substring(re.IndexOf("<font color=Red>"));
                    }
                    
                    string phone = Regex.Replace(re, "[A-Za-z]", "");

                    string[] digits = Regex.Split(phone, @"\D+");
                    string PhoneNumber = string.Empty;

                    for (int p = 0; p < digits.Length; p++)
                    {
                        if (digits[p].Length == 10)
                        {
                            PhoneNumber = digits[p];
                        }
                        else if (digits[p].Length == 3 && digits[p + 1].Length == 3 && digits[p + 2].Length == 4)
                        {
                            PhoneNumber = digits[p] + digits[p + 1] + digits[p + 2];
                        }

                        else if (digits[p].Length == 3 && digits[p + 1].Length == 7)
                        {
                            PhoneNumber = digits[p] + digits[p + 1];
                        }
                    }
                    if (re.IndexOf("<td ><a href=\"javascript:send") != -1)
                    {
                        re = re.Substring(0, re.IndexOf("<td ><a href=\"javascript:send"));
                    }
                    //re = Regex.Replace(re,"/<[^a-zA-Z0-9]*|[^a-zA-Z0-9]*>/g","");//(re,@"(?<!\w)#\w+", "");
                    re = re.Replace("<td >", "<td>"); re = re.Replace("<td  >", "<td>");
                    string[] sep = { "<td>" };
                    string[] re1 = re.Split(sep, StringSplitOptions.None);
                    for (int jcvp = 0; jcvp < re1.Length; jcvp++)
                    {
                        if (re1[jcvp].Contains("For Sale:"))
                        {
                            if (title1 == "")
                            {
                                title1 = re1[jcvp];
                                title1 = title1.Substring(title1.LastIndexOf('>'));
                                title1 = title1.Replace('^', ' ');
                                title1 = title1.Replace(">", "");
                                //title1 = title1.Replace("", "");
                                //title1 = title1.Replace("", "");
                            }
                        }

                        else if (re1[jcvp].Contains("Price:"))
                        {
                            if (title2 == "")
                            {
                                title2 = re1[jcvp];
                                title2 = title2.Replace("<b>", "");
                                title2 = title2.Substring(title2.IndexOf(":"), title2.IndexOf("<"));
                                title2 = title2.Replace(":", "");
                                title2 = title2.Replace("</b>", "");
                                title2 = title2.Replace("<", "");
                            }
                        }
                        else if (re1[jcvp].Contains("Mileage:"))
                        {
                            if (title3 == "")
                            {
                                title3 = re1[jcvp];
                                title3 = title3.Substring(title3.IndexOf(":"));
                                title3 = title3.Replace(":", "");
                            }
                        }
                        else if (re1[jcvp].Contains("Exterior:") || re1[jcvp].Contains("Exterior Color:"))
                        {
                            if (title4 == "")
                            {
                                title4 = re1[jcvp];
                                title4 = title4.Substring(title4.IndexOf(":"));
                                title4 = title4.Replace(":", "");
                                title4 = title4.Replace("^", "");
                            }
                        }
                        else if (re1[jcvp].Contains("Doors:"))
                        {
                            if (title5 == "")
                            {
                                title5 = re1[jcvp];
                                title5 = title5.Substring(title5.IndexOf(":"));
                                title5 = title5.Replace(":", "");
                                title5 = title5.Replace("^", "");
                            }
                        }
                        else if (re1[jcvp].Contains("Engine:"))
                        {
                            if (title6 == "")
                            {
                                title6 = re1[jcvp];
                                title6 = title6.Substring(title6.IndexOf(":"));
                                title6 = title6.Replace(":", "");
                            }
                        }
                        else if (re1[jcvp].Contains("Trans."))
                        {
                            if (title7 == "")
                            {
                                title7 = re1[jcvp];
                                title7 = title7.Substring(title7.IndexOf("."));
                                title7 = title7.Replace(".", "");
                                title7 = title7.Replace("^", "");
                            }
                        }
                        else if (re1[jcvp].Contains("Fuel:"))
                        {
                            if (title8 == "")
                            {
                                title8 = re1[jcvp];
                                title8 = title8.Substring(title8.IndexOf(":"));
                                title8 = title8.Replace(":", "");
                            }
                        }
                        else if (re1[jcvp].Contains("Drive:"))
                        {
                            if (title9 == "")
                            {
                                title9 = re1[jcvp];
                                title9 = title9.Substring(title9.IndexOf(":"));
                                title9 = title9.Replace(":", "");
                                title9 = title9.Replace("^", "");
                            }
                        }
                        //else if (re1[jcvp].Contains("Stock"))
                        //{
                        //    title10 = re1[jcvp];

                        //}
                        else if (re1[jcvp].Contains("Description:"))
                        {
                            if (title11 == "")
                            {
                                title11 = re1[jcvp];
                                title11 = title11.Substring(title11.IndexOf("<br>"));
                                title11 = title11.Replace("<br>", "");
                                title11 = title11.Replace("^", "");
                            }
                        }
                        else if (re1[jcvp].Contains("Contact Seller:"))
                        {
                            if (title12 == "")
                            {
                                title12 = re1[jcvp];
                                title12 = title12.Substring(title12.IndexOf(":"));
                                title12 = title12.Replace("<br>", "");
                                title12 = title12.Replace("^", "");
                            }
                        }

                    }
                    #endregion
                    #region saveData
                    //objDal.SaveLead_CarPost(title1, title2, title3, title4, title5, title6, title7, title8, title9, title11, title12, PhoneNumber, zip, url, state,city);
                    objDal.SaveLeadsData("", "", title1, PhoneNumber, title2, url, "", state, city, "", zip, title3, "", "", "", title4, title5, title6, title7, title8, title9, "");
                    label2.Text = (int.Parse(label2.Text) + 1).ToString();
                    #endregion
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
        }
        #endregion
        #region ClassifiedsValley
        public void GetClassifiedsValleyLeads()
        {
            string str = "";
            for (int p = 1; p < 29; p++)
            {
                #region tot
                FillCurrentPageData("http://www.classifiedsvalley.com/category/196/Cars/" + p + ".html");
                Regex regexindividual1 = new Regex("<a (.*?)>(.*?)</a>");
                System.Collections.ArrayList individualCararraylist1 = new System.Collections.ArrayList();
                str = content;
                str = content.Replace('\n', ' ');
                System.Text.RegularExpressions.MatchCollection regexindividualCollec1 = null;
                regexindividualCollec1 = regexindividual1.Matches(str);
                individualCararraylist1.Clear();
                individualCararraylist1.InsertRange(individualCararraylist1.Count, regexindividualCollec1);
                if (individualCararraylist1.Count > 0)
                {
                    for (int dj = 11; dj < individualCararraylist1.Count; dj++)
                    {
                        #region fetch
                        string title = ""; string city = ""; string state = "";
                        string sname = ""; string price = "";
                        string desc = ""; string PhoneNumber = ""; string phDesc = "";
                        string url = individualCararraylist1[dj].ToString();
                        if (url.Contains("category") && url.Contains("listing"))
                        {
                            if (dj % 2 == 0)
                            {
                                url = url.Substring(0, url.IndexOf(">"));
                                url = url.Replace("<a href=", "");
                                //url = url.Replace(">", "");
                                url = url.Replace("\"", "");

                                url = "http://www.classifiedsvalley.com/" + url;
                                FillCurrentPageData(url);//"http://www.carposts.com/AutoDetail.php?AutoID=35488727"
                                //Regex regexindividual = new Regex("<h1 class=\"listing_title\">(.*?)</h1>");
                                //Regex regexindividual = new Regex("<h1 class=\"seller_username\"><a (.*?) class=\"display_ad_value\">(.*?)</a></h1>");
                                //Regex regexindividual = new Regex("<li class=\"value price\">(.*?)</li>");
                                //Regex regexindividual = new Regex("<div class=\"box_pad\">(.*?)</div>");
                                //Regex regexindividual = new Regex("<ul class=\"info\">(.*?)</ul>");

                                Regex r1 = new Regex("<h1 class=\"listing_title\">(.*?)</h1>");
                                System.Collections.ArrayList al1 = new System.Collections.ArrayList();
                                str = content;
                                str = content.Replace('\n', ' ');
                                System.Text.RegularExpressions.MatchCollection mc1 = null;
                                mc1 = r1.Matches(str);
                                al1.Clear();
                                al1.InsertRange(al1.Count, mc1);
                                for (int x = 0; x < al1.Count; x++)
                                {
                                    title = al1[x].ToString();
                                    title = title.Replace("</h1>", "");
                                    title = title.Substring(title.LastIndexOf(">"));
                                    title = title.Replace(">", "");
                                }

                                Regex r2 = new Regex("<h1 class=\"seller_username\"><a (.*?) class=\"display_ad_value\">(.*?)</a></h1>");
                                System.Collections.ArrayList al2 = new System.Collections.ArrayList();
                                str = content;
                                str = content.Replace('\n', ' ');
                                System.Text.RegularExpressions.MatchCollection mc2 = null;
                                mc2 = r2.Matches(str);
                                al2.Clear();
                                al2.InsertRange(al2.Count, mc2);
                                for (int x = 0; x < al2.Count; x++)
                                {
                                    sname = al2[x].ToString();
                                    sname = sname.Replace("</a>", "");
                                    sname = sname.Replace("</h1>", "");
                                    sname = sname.Substring(sname.LastIndexOf(">"));
                                    sname = sname.Replace(">", "");
                                }

                                Regex r3 = new Regex("<li class=\"value price\">(.*?)</li>");

                                System.Collections.ArrayList al3 = new System.Collections.ArrayList();
                                str = content;
                                str = content.Replace('\n', ' ');
                                System.Text.RegularExpressions.MatchCollection mc3 = null;
                                mc3 = r3.Matches(str);
                                al3.Clear();
                                al3.InsertRange(al3.Count, mc3);
                                for (int x = 0; x < al3.Count; x++)
                                {
                                    price = al3[x].ToString();
                                    price = price.Replace("</li>", "");
                                    price = price.Substring(price.LastIndexOf(">"));
                                    price = price.Replace(">", ""); price = price.Replace("USD", "");
                                    price = price.Replace("$", "");
                                }

                                Regex r4 = new Regex("<div class=\"box_pad\">(.*?)</div>");

                                System.Collections.ArrayList al4 = new System.Collections.ArrayList();
                                str = content;
                                str = content.Replace('\n', ' ');
                                System.Text.RegularExpressions.MatchCollection mc4 = null;
                                mc4 = r4.Matches(str);
                                al4.Clear();
                                al4.InsertRange(al4.Count, mc4);
                                for (int x = 0; x < al4.Count; x++)
                                {
                                    desc = al4[x].ToString();
                                    desc = desc.Replace("<div class=\"box_pad\">", "");
                                    desc = desc.Replace("</div>", "");
                                    string desc1 = Regex.Replace(desc, @"[^a-zA-Z0-9]", "");
                                    string[] digits = Regex.Split(desc1, @"\D+");
                                    string PhoneNumber1 = string.Empty;

                                    for (int ph = 0; ph < digits.Length; ph++)
                                    {
                                        if (digits[ph].Length == 10)
                                        {
                                            phDesc = digits[ph];
                                        }
                                        if (ph + 1 < digits.Length)
                                        {
                                            if ((ph + 2 < digits.Length))
                                            {
                                                if (digits[ph].Length == 3 && digits[ph + 1].Length == 3 && digits[ph + 2].Length == 4)
                                                {
                                                    phDesc = digits[ph] + digits[ph + 1] + digits[ph + 2];
                                                }
                                            }
                                            else if (digits[ph].Length == 3 && digits[ph + 1].Length == 7)
                                            {
                                                phDesc = digits[ph] + digits[ph + 1];
                                            }
                                        }
                                        else if (digits[ph].Length == 11)
                                        {
                                            phDesc = digits[ph];
                                            if (phDesc[0] == 0 || phDesc[0] == 1)
                                            {
                                                phDesc = phDesc.Substring(1);
                                            }
                                            else if (phDesc[10] == 0)
                                            {
                                                phDesc = phDesc.Substring(0, 10);
                                            }
                                        }
                                    }
                                }

                                Regex r5 = new Regex("<ul class=\"info\">(.*?)</ul>");

                                System.Collections.ArrayList al5 = new System.Collections.ArrayList();
                                str = content;
                                str = content.Replace('\n', ' ');
                                System.Text.RegularExpressions.MatchCollection mc5 = null;
                                mc5 = r5.Matches(str);
                                al5.Clear();
                                al5.InsertRange(al5.Count, mc5);
                                for (int x = 0; x < al5.Count; x++)
                                {
                                    string all = al5[x].ToString();
                                    all = all.Replace("<li class=\"value\">", "");
                                    if (all.Contains("City:"))
                                    {
                                        all = all.Substring(all.IndexOf("City:"));
                                        city = all.Substring(all.IndexOf(">"));
                                        city = city.Substring(0, city.IndexOf("<"));
                                        city = city.Replace(">", "");
                                        city = city.Replace("\r", "");
                                        city = city.Replace("\t", "");
                                    }
                                    if (all.Contains("State:"))
                                    {
                                        all = all.Substring(all.IndexOf("State:"));
                                        state = all.Substring(all.IndexOf(">"));
                                        state = state.Substring(0, state.IndexOf("<"));
                                        state = state.Replace(">", "");
                                        state = state.Replace("\r", "");
                                        state = state.Replace("\t", "");
                                    }
                                    if (phDesc == "")
                                    {
                                        if (all.Contains("Phone:"))
                                        {
                                            all = Regex.Replace(all, @"[^a-zA-Z0-9]", "");
                                            string[] digits = Regex.Split(all, @"\D+");
                                            string PhoneNumber1 = string.Empty;

                                            for (int ph = 0; ph < digits.Length; ph++)
                                            {
                                                if (digits[ph].Length == 10)
                                                {
                                                    PhoneNumber = digits[ph];
                                                }
                                                if (ph + 1 < digits.Length)
                                                {
                                                    if ((ph + 2 < digits.Length))
                                                    {
                                                        if (digits[ph].Length == 3 && digits[ph + 1].Length == 3 && digits[ph + 2].Length == 4)
                                                        {
                                                            PhoneNumber = digits[ph] + digits[ph + 1] + digits[ph + 2];
                                                        }
                                                    }
                                                    else if (digits[ph].Length == 3 && digits[ph + 1].Length == 7)
                                                    {
                                                        PhoneNumber = digits[ph] + digits[ph + 1];
                                                    }
                                                }
                                                else if (digits[ph].Length == 11)
                                                {
                                                    PhoneNumber = digits[ph];
                                                    if (PhoneNumber[0] == 0 || PhoneNumber[0] == 1)
                                                    {
                                                        PhoneNumber = PhoneNumber.Substring(1);
                                                    }
                                                    else if (PhoneNumber[10] == 0)
                                                    {
                                                        PhoneNumber = PhoneNumber.Substring(0, 10);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                #region Save
                                //objDal.SaveLead_ClassifiedsValley(title, city, state, sname, price, desc, (phDesc == "" ? PhoneNumber : phDesc), url);
                                objDal.SaveLeadsData("", "", title, (phDesc == "" ? PhoneNumber : phDesc), price, url, sname, state, city, "", "", "", "", desc, "", "", "", "", "", "", "", "");
                                label2.Text = (int.Parse(label2.Text) + 1).ToString();
                                #endregion
                            }
                        }
                        #endregion

                    }
                }
                else
                    return;
                #endregion
            }
            MessageBox.Show("Leads Collected Successfully For ClassifiedsValley Site");
        }
        #endregion
        #region ClassifiedsCiti
        public void GetClassifiedsCitiLeads()
        {
            string str = ""; string date = "";
            for (int p = 1; p < 716; p++)
            {
                string mainurl = "http://www.classifiedsciti.com/cars-amp-bikes/cars/USA/" + p;
                #region tot
                FillCurrentPageData(mainurl);
                Regex regexindividual3 = new Regex("<h2>(.*?)</h2>");
                str = content;
                str = content.Replace('\n', ' ');
                System.Collections.ArrayList individualCararraylist3 = new System.Collections.ArrayList();
                System.Text.RegularExpressions.MatchCollection regexindividualCollec3 = null;
                regexindividualCollec3 = regexindividual3.Matches(str);
                individualCararraylist3.Clear();
                individualCararraylist3.InsertRange(individualCararraylist3.Count, regexindividualCollec3);


                Regex regexindividual = new Regex("<span class=\"post-date\">(.*?)</span>");
                System.Collections.ArrayList individualCararraylist = new System.Collections.ArrayList();
                str = content;
                str = content.Replace('\n', ' ');
                System.Text.RegularExpressions.MatchCollection regexindividualCollec = null;
                regexindividualCollec = regexindividual.Matches(str);
                individualCararraylist.Clear();
                individualCararraylist.InsertRange(individualCararraylist.Count, regexindividualCollec);

                for (int y = 0; y < individualCararraylist.Count; y++)
                {

                    date = individualCararraylist[y].ToString().Replace("<span class=\"post-date\">", "");
                    date = date.Replace("</span>", "");

                    string[] date1 = date.Split('-');
                    date = date1[1] + "-" + date1[0] + "-" + date1[2];
                    DateTime new1 = DateTime.Parse(date);
                    new1 = new1.Date + ts;
                    if (!(new1 >= edate && new1 <= sdate))
                    {
                        return;
                    }
                    else
                    {
                        string desc = ""; string title = ""; string details = "";
                        string pubDate = ""; string name = ""; string price = "";
                        string location = ""; string place = ""; string phno = string.Empty;
                        string city = ""; string state = "";

                        #region fetch
                        string url = individualCararraylist3[y].ToString();

                        url = url.Substring(url.IndexOf("href="));
                        url = url.Replace("href=", "");
                        url = url.Substring(0, url.IndexOf("rel"));
                        //url = url.Replace(">", "");
                        url = url.Replace("\"", "");

                        FillCurrentPageData(url);

                        Regex r1 = new Regex("<div>(.*?)<div class=\"addthis_toolbox addthis_default_style\">(.*?)</div>");
                        System.Collections.ArrayList al1 = new System.Collections.ArrayList();
                        str = content;
                        str = content.Replace('\n', ' ');
                        System.Text.RegularExpressions.MatchCollection mc1 = null;
                        mc1 = r1.Matches(str);
                        al1.Clear();
                        al1.InsertRange(al1.Count, mc1);
                        for (int x = 0; x < al1.Count; x++)
                        {
                            desc = al1[x].ToString();
                            desc = desc.Replace("<div>", "");
                            desc = desc.Replace("</div>", "");
                            desc = desc.Substring(0, desc.IndexOf("<!-- AddThis Button BEGIN -->"));

                            string phone = Regex.Replace(desc, "[A-Za-z]", "");

                            string[] digits = Regex.Split(phone, @"\D+");

                            for (int ph = 0; ph < digits.Length; ph++)
                            {
                                if (digits[ph].Length == 10)
                                {
                                    phno = digits[ph];
                                }
                                else if (digits[ph].Length == 3 && digits[ph + 1].Length == 3 && digits[ph + 2].Length == 4)
                                {
                                    phno = digits[ph] + digits[ph + 1] + digits[ph + 2];
                                }

                                else if (digits[ph].Length == 3 && digits[ph + 1].Length == 7)
                                {
                                    phno = digits[ph] + digits[ph + 1];
                                }
                            }
                        }

                        Regex r2 = new Regex("<p>(.*?)</p>");
                        System.Collections.ArrayList al2 = new System.Collections.ArrayList();
                        str = content;
                        str = content.Replace('\n', ' ');
                        System.Text.RegularExpressions.MatchCollection mc2 = null;
                        mc2 = r2.Matches(str);
                        al2.Clear();
                        al2.InsertRange(al2.Count, mc2);

                        details = al2[0].ToString();
                        string[] det = details.Split('|');
                        for (int i = 0; i < det.Length; i++)
                        {
                            if (det[i].Contains("Publish Date:"))
                            {
                                pubDate = det[i];
                                pubDate = pubDate.Substring(pubDate.IndexOf(":"));
                                pubDate = pubDate.Replace(":", "");
                                pubDate = pubDate.Replace("</b>", "");
                            }
                            else if (det[i].Contains("Contact name:"))
                            {
                                name = det[i];
                                name = name.Substring(name.IndexOf(":"));
                                name = name.Replace(":", "");
                                name = name.Replace("</b>", "");
                            }
                            else if (det[i].Contains("Location:"))
                            {
                                location = det[i];
                                location = location.Substring(location.IndexOf(":"));
                                location = location.Replace(":", "");
                                location = location.Replace("</b>", "");
                            }
                            else if (det[i].Contains("Place:"))
                            {
                                place = det[i];
                                place = place.Substring(place.IndexOf(":"));
                                place = place.Replace(":", "");
                                place = place.Replace("</b>", "");
                                place = place.Replace("\t", "");
                                if (place.IndexOf(",") != -1)
                                    city = place.Substring(0, place.IndexOf(","));
                                else
                                    city = place;
                                state = place.Replace(city, "");
                                state = state.Replace(",", "");
                                state = Regex.Replace(state, "[0-9]", "");
                            }
                        }

                        Regex r3 = new Regex("<h1>(.*?)</h1>");
                        System.Collections.ArrayList al3 = new System.Collections.ArrayList();
                        str = content;
                        str = content.Replace('\n', ' ');
                        System.Text.RegularExpressions.MatchCollection mc3 = null;
                        mc3 = r3.Matches(str);
                        al3.Clear();
                        al3.InsertRange(al3.Count, mc3);
                        for (int x = 0; x < al3.Count; x++)
                        {
                            title = al3[x].ToString();
                            title = title.Replace("<h1>", "");
                            title = title.Replace("</h1>", "");
                            if (title.IndexOf("-") != -1)
                            {
                                price = title.Substring(title.IndexOf("-"));
                                price = price.Replace("-", "");
                            }
                        }

                        #endregion
                        #region Save
                        //objDal.SaveLead_ClassifiedsCiti(title, desc, location, state,city, name, phno, price, url);
                        objDal.SaveLeadsData("", "", title, phno, price, url, name, state, city, location, "", "", "", desc, "", "", "", "", "", "", "", "");
                        label2.Text = (int.Parse(label2.Text) + 1).ToString();
                        #endregion

                    }

                }


                #region old
                //for (int dj = 0; dj < individualCararraylist3.Count - 1; dj++)
                //{
                //    string desc = ""; string title = ""; string details = "";
                //    string pubDate = ""; string name = ""; string price = "";
                //    string location = ""; string place = ""; string phno = string.Empty;
                //    string city = ""; string state = "";

                //    #region fetch
                //    string url = individualCararraylist3[dj].ToString();

                //    url = url.Substring(url.IndexOf("href="));
                //    url = url.Replace("href=", "");
                //    url = url.Substring(0, url.IndexOf("rel"));
                //    //url = url.Replace(">", "");
                //    url = url.Replace("\"", "");

                //    FillCurrentPageData(url);

                //    Regex r1 = new Regex("<div>(.*?)<div class=\"addthis_toolbox addthis_default_style\">(.*?)</div>");
                //    System.Collections.ArrayList al1 = new System.Collections.ArrayList();
                //    str = content;
                //    str = content.Replace('\n', ' ');
                //    System.Text.RegularExpressions.MatchCollection mc1 = null;
                //    mc1 = r1.Matches(str);
                //    al1.Clear();
                //    al1.InsertRange(al1.Count, mc1);
                //    for (int x = 0; x < al1.Count; x++)
                //    {
                //        desc = al1[x].ToString();
                //        desc = desc.Replace("<div>", "");
                //        desc = desc.Replace("</div>", "");
                //        desc = desc.Substring(0, desc.IndexOf("<!-- AddThis Button BEGIN -->"));

                //        string phone = Regex.Replace(desc, "[A-Za-z]", "");

                //        string[] digits = Regex.Split(phone, @"\D+");

                //        for (int ph = 0; ph < digits.Length; ph++)
                //        {
                //            if (digits[ph].Length == 10)
                //            {
                //                phno = digits[ph];
                //            }
                //            else if (digits[ph].Length == 3 && digits[ph + 1].Length == 3 && digits[ph + 2].Length == 4)
                //            {
                //                phno = digits[ph] + digits[ph + 1] + digits[ph + 2];
                //            }

                //            else if (digits[ph].Length == 3 && digits[ph + 1].Length == 7)
                //            {
                //                phno = digits[ph] + digits[ph + 1];
                //            }
                //        }
                //    }

                //    Regex r2 = new Regex("<p>(.*?)</p>");
                //    System.Collections.ArrayList al2 = new System.Collections.ArrayList();
                //    str = content;
                //    str = content.Replace('\n', ' ');
                //    System.Text.RegularExpressions.MatchCollection mc2 = null;
                //    mc2 = r2.Matches(str);
                //    al2.Clear();
                //    al2.InsertRange(al2.Count, mc2);

                //    details = al2[0].ToString();
                //    string[] det = details.Split('|');
                //    for (int i = 0; i < det.Length; i++)
                //    {
                //        if (det[i].Contains("Publish Date:"))
                //        {
                //            pubDate = det[i];
                //            pubDate = pubDate.Substring(pubDate.IndexOf(":"));
                //            pubDate = pubDate.Replace(":", "");
                //            pubDate = pubDate.Replace("</b>", "");
                //        }
                //        else if (det[i].Contains("Contact name:"))
                //        {
                //            name = det[i];
                //            name = name.Substring(name.IndexOf(":"));
                //            name = name.Replace(":", "");
                //            name = name.Replace("</b>", "");
                //        }
                //        else if (det[i].Contains("Location:"))
                //        {
                //            location = det[i];
                //            location = location.Substring(location.IndexOf(":"));
                //            location = location.Replace(":", "");
                //            location = location.Replace("</b>", "");
                //        }
                //        else if (det[i].Contains("Place:"))
                //        {
                //            place = det[i];
                //            place = place.Substring(place.IndexOf(":"));
                //            place = place.Replace(":", "");
                //            place = place.Replace("</b>", "");
                //            place = place.Replace("\t", "");
                //            if (place.IndexOf(",") != -1)
                //                city = place.Substring(0, place.IndexOf(","));
                //            else
                //                city = place;
                //            state = place.Replace(city, "");
                //            state = state.Replace(",", "");
                //            state = Regex.Replace(state, "[0-9]", "");
                //        }
                //    }

                //    Regex r3 = new Regex("<h1>(.*?)</h1>");
                //    System.Collections.ArrayList al3 = new System.Collections.ArrayList();
                //    str = content;
                //    str = content.Replace('\n', ' ');
                //    System.Text.RegularExpressions.MatchCollection mc3 = null;
                //    mc3 = r3.Matches(str);
                //    al3.Clear();
                //    al3.InsertRange(al3.Count, mc3);
                //    for (int x = 0; x < al3.Count; x++)
                //    {
                //        title = al3[x].ToString();
                //        title = title.Replace("<h1>", "");
                //        title = title.Replace("</h1>", "");
                //        if (title.IndexOf("-") != -1)
                //        {
                //            price = title.Substring(title.IndexOf("-"));
                //            price = price.Replace("-", "");
                //        }
                //    }

                //    #endregion
                //    #region Save
                //    //objDal.SaveLead_ClassifiedsCiti(title, desc, location, state,city, name, phno, price, url);
                //    objDal.SaveLeadsData("", "", title, phno, price, url, name, state, city, location, "", "", "", desc, "", "", "", "", "", "", "", "");
                //    label2.Text = (int.Parse(label2.Text) + 1).ToString();
                //    #endregion
                //}
                #endregion

                #endregion
            }
            //MessageBox.Show("Leads Collected Successfully For ClassifiedsCiti Site");
        }
        #endregion
        private void Load_Zip_ByState_Cars()
        {
            int stateId1 = 1;
            DataSet dsZip = new DataSet();
            if (cmbStatesCars.SelectedIndex == 0)
            {

                int stateId = Convert.ToInt32(stateId1);

                dsZip = objDal.GetZip_ByState_FromCarsSite(stateId);



                if (dsZip.Tables[0].Rows.Count > 0)
                {
                    txtZipCars.Text = dsZip.Tables[0].Rows[0]["zipcode"].ToString();
                    txtZipCars.Enabled = false;
                }
                else
                {

                    txtZipCars.Text = "";

                }



            }
        }
        private void Load_States_Cars()
        {
            DataSet dsStated = new DataSet();

            dsStated = objDal.GetStates_CarsSite();

            cmbStatesCars.DataSource = dsStated;
            cmbStatesCars.DisplayMember = "Table.state_name";
            cmbStatesCars.ValueMember = "Table.state_name";

            // cmbState.DataBindings.Add("", "Select", ""); 

        }  
        private void LoadCities()
        {
            int stateId = 1;
            DataSet dscitiesDefault = new DataSet();

            dscitiesDefault = objDal.GetCities(stateId);


            if (dscitiesDefault.Tables[0].Rows.Count > 0)
            {
                CCityNames.DisplayMember = "Table.CITYNAME";
                CCityNames.ValueMember = "Table.CITYCODE";
                CCityNames.DataSource = dscitiesDefault;
            }
            else
            {

                CCityNames.DataBindings.Clear();
                CCityNames.DataSource = null;

            }



        }
        private void LoadStates_Cars()
        {
            DataSet dsStated = new DataSet();

            //dsStated = objDal.GetStates();
            dsStated = objDal.GET_STATES_Craiglistcars();

            cmbState.DataSource = dsStated;
            cmbState.DisplayMember = "Table.STATE";
            cmbState.ValueMember = "Table.STATE_ID";
            cmbState.Visible = true;
            cmbState.BringToFront();

            // cmbState.DataBindings.Add("", "Select", ""); 




        }
        private void LoadStates()
        {
            DataSet dsStated = new DataSet();

            dsStated = objDal.GetStates();
            // dsStated = objDal.GET_STATES_Craiglistcars();

            cmbState.DataSource = dsStated;
            cmbState.DisplayMember = "Table.STATE_NAME";
            cmbState.ValueMember = "Table.STATE_ID";
            cmbState.Visible = true;
            cmbState.BringToFront();

            // cmbState.DataBindings.Add("", "Select", ""); 




        }
        private string FillCurrentPageData(string uri)
        {
            string content = string.Empty;
            try
            {


                if (varexit != 1)
                {
                    int excnt = 0;
                    try
                    {
                        HttpWebRequest httpreq = default(HttpWebRequest);
                        //= WebRequest.Create(uri)
                        HttpWebResponse httpresp = default(HttpWebResponse);
                        StreamReader sr = default(StreamReader);

                        httpreq = (HttpWebRequest)WebRequest.Create(uri);

                        httpresp = (HttpWebResponse)httpreq.GetResponse();

                        //'Read Data from the Page in to Stream Reader

                        sr = new StreamReader(httpresp.GetResponseStream());
                        //content = sr.ReadToEnd();
                        BackgroundWorker BackgroundWorker1 = new BackgroundWorker();
                        //AddHandler BackgroundWorker1.RunWorkerCompleted, AddressOf BackgroundWorker1_RunWorkerCompleted
                        BackgroundWorker1.WorkerSupportsCancellation = true;
                        BackgroundWorker1.RunWorkerAsync(readStream(sr));
                        BackgroundWorker1.Dispose();
                        sr.Close();


                    }
                    catch (Exception ex)
                    {
                        if (ex.Message.Contains("timed out"))
                        {
                            if (excnt < 300)
                            {
                                FillCurrentPageData(uri);
                                excnt += 1;
                            }
                        }
                    }
                }
                else
                {
                    this.Dispose();
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return content;
        }
        public bool readStream(StreamReader sr)
        {
            Application.DoEvents();
            content = sr.ReadToEnd();

            return true;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            //try
            //{
                if (cboWebsite.Text == "Select")
                {
                    MessageBox.Show("Please select Site.");
                }
                else if (cboWebsite.SelectedItem.ToString() == "AutoTrades")
                {
                    GetLeadsForAutoTrades();
                }
                else if (cboWebsite.SelectedItem.ToString() == "Craigslist")
                {
                    #region clo
                    DataSet dsCities = new DataSet();
                    int stateId = Convert.ToInt32(cmbState.SelectedValue);
                    DataSet dsStated = new DataSet();
                    dsStated = objDal.GET_STATES_Craiglistcars();
                    label4.Visible = true;
                    txt_cityname.Visible = true;
                    if (stopclo)
                    {
                        for (int i = 0; i < dsStated.Tables[0].Rows.Count; i++)
                        {
                            if (stopclo)
                            {
                                DataSet dsStatesAfter = new DataSet();
                                dsStatesAfter = objDal.GET_STATES_Craiglistcars();
                                DataView dv = dsStatesAfter.Tables[0].DefaultView;
                                dv.RowFilter = "State_Id=" + Convert.ToInt32(dsStated.Tables[0].Rows[i]["State_Id"].ToString());
                                DataTable dt = dv.ToTable();
                                if (dt.Rows.Count == 0)
                                { continue; }
                                dsCities = objDal.GetCities(Convert.ToInt32(dsStated.Tables[0].Rows[i]["State_Id"]));
                                objDal.SaveTransaction_Cars(Convert.ToInt32(dsStated.Tables[0].Rows[i]["State_Id"]), "1", "0");
                                cmbState.Text = dsStated.Tables[0].Rows[i]["state"].ToString();
                                SessionStateid = Convert.ToInt32(dsStated.Tables[0].Rows[i]["State_Id"]);
                                if (SessionStateid == 44)
                                {
                                }
                                string StateCode = dsStated.Tables[0].Rows[i]["State_Code"].ToString();
                                if (dsCities != null)
                                {
                                    if (dsCities.Tables.Count > 0)
                                    {
                                        if (dsCities.Tables[0].Rows.Count > 0)
                                        {
                                            int p = 0;

                                            for (p = 0; p < dsCities.Tables[0].Rows.Count; p++)
                                            {
                                                if (stopclo)
                                                {
                                                    txt_cityname.Text = dsCities.Tables[0].Rows[p]["cityname"].ToString();
                                                    label5.Text = (p + 1).ToString();
                                                    objDal.SaveTransaction_Cars(dsStated.Tables[0].Rows[i]["State"].ToString(), dsCities.Tables[0].Rows[p]["cityname"].ToString(), "1", "0");
                                                    GetLeadsForcraigslist(dsStated.Tables[0].Rows[i]["State"].ToString(), dsCities.Tables[0].Rows[p]["cityname"].ToString(), Convert.ToInt32(dsStated.Tables[0].Rows[i]["State_Id"]));
                                                    objDal.SaveTransaction_Cars(dsStated.Tables[0].Rows[i]["State"].ToString(), dsCities.Tables[0].Rows[p]["cityname"].ToString(), "1", "1");
                                                }
                                                else
                                                    return;
                                            }
                                            objDal.SaveTransaction_Cars(Convert.ToInt32(dsStated.Tables[0].Rows[i]["State_Id"]), "1", "1");
                                        }
                                    }
                                }
                            }//MessageBox.Show("Leads Collected Successfully for " + dsStated.Tables[0].Rows[i]["State_Name"].ToString() + " change another state");
                        }
                    }
                    MessageBox.Show("  Leads Collected Successfully  ");
                    #endregion
                }
                else if (cboWebsite.SelectedItem.ToString() == "CraigslistDealers")
                {
                    #region cld
                    DataSet dsCities = new DataSet();
                    int stateId = Convert.ToInt32(cmbState.SelectedValue);
                    DataSet dsStated = new DataSet();
                    dsStated = objDal.GET_STATES_Craiglistcars();
                    label4.Visible = true;
                    txt_cityname.Visible = true;
                    if (stopcld)
                    {
                        for (int i = 0; i < dsStated.Tables[0].Rows.Count; i++)
                        {
                            if (stopcld)
                            {
                                DataSet dsStatesAfter = new DataSet();
                                dsStatesAfter = objDal.GET_STATES_Craiglistcars();
                                DataView dv = dsStatesAfter.Tables[0].DefaultView;
                                dv.RowFilter = "State_Id=" + Convert.ToInt32(dsStated.Tables[0].Rows[i]["State_Id"].ToString());
                                DataTable dt = dv.ToTable();
                                if (dt.Rows.Count == 0)
                                { continue; }
                                dsCities = objDal.GetCities(Convert.ToInt32(dsStated.Tables[0].Rows[i]["State_Id"]));
                                objDal.SaveTransaction_Cars(Convert.ToInt32(dsStated.Tables[0].Rows[i]["State_Id"]), "1", "0");
                                SessionStateid = Convert.ToInt32(dsStated.Tables[0].Rows[i]["State_Id"]);
                                if (dsCities != null)
                                {
                                    if (dsCities.Tables.Count > 0)
                                    {
                                        if (dsCities.Tables[0].Rows.Count > 0)
                                        {
                                            int p = 0;
                                            if (stopcld)
                                            {
                                                for (p = 0; p < dsCities.Tables[0].Rows.Count; p++)
                                                {
                                                    if (stopcld)
                                                    {
                                                        txt_cityname.Text = dsCities.Tables[0].Rows[p]["cityname"].ToString();
                                                        label5.Text = (p + 1).ToString();
                                                        objDal.SaveTransaction_Cars(dsStated.Tables[0].Rows[i]["State_name"].ToString(), dsCities.Tables[0].Rows[p]["cityname"].ToString(), "1", "0");
                                                        GetLeadsForCraigslistDealers(dsStated.Tables[0].Rows[i]["State_name"].ToString(), dsCities.Tables[0].Rows[p]["cityname"].ToString(), Convert.ToInt32(dsStated.Tables[0].Rows[i]["State_Id"]));
                                                        objDal.SaveTransaction_Cars(dsStated.Tables[0].Rows[i]["State_name"].ToString(), dsCities.Tables[0].Rows[p]["cityname"].ToString(), "1", "1");
                                                    }
                                                    else return;
                                                }
                                            }
                                            objDal.SaveTransaction_Cars(Convert.ToInt32(dsStated.Tables[0].Rows[i]["State_Id"]), "1", "1");
                                        }
                                    }
                                }
                            }
                        }
                    }
                    MessageBox.Show(" Leads Collected Successfully ");
                    #endregion
                }
                else if (cboWebsite.SelectedItem.ToString() == "CraigslistRVS")
                {
                    #region clrv
                    DataSet dsStated = new DataSet();
                    int stateId = Convert.ToInt32(cmbState.SelectedValue);
                    DataSet dsCities = new DataSet();
                    dsStated = objDal.GetStates();
                    label4.Visible = true;
                    txt_cityname.Visible = true;
                    if (stopclrv)
                    {
                        for (int i = 0; i < dsStated.Tables[0].Rows.Count; i++)
                        {
                            if (stopclrv)
                            {
                                DataSet dsStatesAfter = new DataSet();
                                dsStatesAfter = objDal.GetStates();
                                DataView dv = dsStatesAfter.Tables[0].DefaultView;
                                dv.RowFilter = "State_Id=" + Convert.ToInt32(dsStated.Tables[0].Rows[i]["State_Id"].ToString());
                                DataTable dt = dv.ToTable();
                                if (dt.Rows.Count == 0)
                                { continue; }
                                dsCities = objDal.GetCities(Convert.ToInt32(dsStated.Tables[0].Rows[i]["State_Id"]));
                                objDal.SaveTransaction_Cars(Convert.ToInt32(dsStated.Tables[0].Rows[i]["State_Id"]), "1", "0");
                                SessionStateid = Convert.ToInt32(dsStated.Tables[0].Rows[i]["State_Id"]);
                                if (dsCities != null)
                                {
                                    if (dsCities.Tables.Count > 0)
                                    {
                                        if (dsCities.Tables[0].Rows.Count > 0)
                                        {
                                            int p = 0;
                                            if (stopclrv)
                                            {
                                                for (p = 0; p < dsCities.Tables[0].Rows.Count; p++)
                                                {
                                                    if (stopclrv)
                                                    {
                                                        txt_cityname.Text = dsCities.Tables[0].Rows[p]["cityname"].ToString();
                                                        label5.Text = (p + 1).ToString();
                                                        objDal.SaveTransaction_Cars(dsStated.Tables[0].Rows[i]["State_name"].ToString(), dsCities.Tables[0].Rows[p]["cityname"].ToString(), "1", "0");
                                                        GetLeadsForcraigslistRVSAutoSelection(dsStated.Tables[0].Rows[i]["State_name"].ToString(), dsCities.Tables[0].Rows[p]["cityname"].ToString(), Convert.ToInt32(dsStated.Tables[0].Rows[i]["State_Id"]));
                                                        objDal.SaveTransaction_Cars(dsStated.Tables[0].Rows[i]["State_name"].ToString(), dsCities.Tables[0].Rows[p]["cityname"].ToString(), "1", "1");
                                                    }
                                                    else return;
                                                }
                                                objDal.SaveTransaction_Cars(Convert.ToInt32(dsStated.Tables[0].Rows[i]["State_Id"]), "1", "1");
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    MessageBox.Show("Leads Collected Successfully ");
                    #endregion
                }
                else if (cboWebsite.SelectedItem.ToString() == "CraigslistBikes")
                {
                    #region clb
                    DataSet dsCities = new DataSet();
                    DataSet dsStated = new DataSet();
                    int stateId = Convert.ToInt32(cmbState.SelectedValue);
                    dsStated = objDal.GET_STATES_Craiglistcars();
                    label4.Visible = true;
                    txt_cityname.Visible = true;
                    if (stopclrv)
                    {
                        for (int i = 0; i < dsStated.Tables[0].Rows.Count; i++)
                        {
                            if (stopclrv)
                            {
                                DataSet dsStatesAfter = new DataSet();
                                dsStatesAfter = objDal.GET_STATES_Craiglistcars();
                                DataView dv = dsStatesAfter.Tables[0].DefaultView;
                                dv.RowFilter = "State_Id=" + Convert.ToInt32(dsStated.Tables[0].Rows[i]["State_Id"].ToString());
                                DataTable dt = dv.ToTable();
                                if (dt.Rows.Count == 0)
                                { continue; }
                                dsCities = objDal.GetCities(stateId);
                                objDal.SaveTransaction_Cars(Convert.ToInt32(Convert.ToInt32(cmbState.SelectedValue)), "1", "0");
                                if (dsCities != null)
                                {
                                    if (dsCities.Tables.Count > 0)
                                    {
                                        if (dsCities.Tables[0].Rows.Count > 0)
                                        {
                                            int p = 0;
                                            if (stopclrv)
                                            {
                                                for (p = 0; p < dsCities.Tables[0].Rows.Count; p++)
                                                {
                                                    if (stopclrv)
                                                    {
                                                        txt_cityname.Text = dsCities.Tables[0].Rows[p]["cityname"].ToString();
                                                        label5.Text = (p + 1).ToString();
                                                        objDal.SaveTransaction_Cars(dsStated.Tables[0].Rows[i]["State_name"].ToString(), dsCities.Tables[0].Rows[p]["cityname"].ToString(), "1", "0");
                                                        GetLeadsForcraigslistBikeSAutoSelection(cmbState.Text, dsCities.Tables[0].Rows[p]["cityname"].ToString());
                                                        objDal.SaveTransaction_Cars(dsStated.Tables[0].Rows[i]["State_name"].ToString(), dsCities.Tables[0].Rows[p]["cityname"].ToString(), "1", "1");
                                                    }
                                                    else return;
                                                }
                                                objDal.SaveTransaction_Cars(Convert.ToInt32(cmbState.SelectedValue), "1", "1");
                                            }
                                        }
                                    }
                                }
                                MessageBox.Show("Leads Collected Successfully change another state");
                            }
                        }
                    }
                    #endregion
                }
                else if (cboWebsite.SelectedItem.ToString() == "Cars.com")
                {
                    #region cars
                    DataSet dsStated = new DataSet();
                    dsStated = objDal.GetStates_CarsSite();
                    string dsZip = "";
                    DataSet dsCities = new DataSet();
                    if (dsStated.Tables[0].Rows.Count > 0)
                    {
                        if (stopcars)
                        {
                            for (int i = 0; i < dsStated.Tables[0].Rows.Count; i++)
                            {
                                if (stopcars)
                                {
                                    DataSet dsStatesAfter = new DataSet();
                                    dsStatesAfter = objDal.GetStates_CarsSite();
                                    DataView dv = dsStatesAfter.Tables[0].DefaultView;
                                    dv.RowFilter = "state_name='" + dsStated.Tables[0].Rows[i]["state_name"].ToString() + "'";
                                    DataTable dt = dv.ToTable();
                                    if (dt.Rows.Count == 0)
                                    { continue; }
                                    dsCities = objDal.GetCities_CarsSite(dsStated.Tables[0].Rows[i]["State_Name"].ToString());
                                    //dsCities = objDal.GetCities_CarsSite("virginia");
                                    for (int j = 0; j < dsCities.Tables[0].Rows.Count; j++)
                                    {
                                        //dsZip = objDal.GetZip_ByState_FromCarsSite(Convert.ToInt32(dsCities.Tables[0].Rows[j]["zipid"].ToString()));
                                        dsZip = dsCities.Tables[0].Rows[j]["zipcode"].ToString();
                                        objDal.SaveTransaction_Cars(dsCities.Tables[0].Rows[j]["zipstate"].ToString(), dsZip, 1, 0,dsStated.Tables[0].Rows[i]["state_name"].ToString());
                                        cmbStatesCars.Text = dsCities.Tables[0].Rows[j]["zipstate"].ToString();
                                        txtZipCars.Text = dsZip;
                                        GetLeadsFromCarsSite(dsCities.Tables[0].Rows[j]["zipstate"].ToString(), dsZip);
                                        objDal.SaveTransaction_Cars(dsCities.Tables[0].Rows[j]["zipstate"].ToString(), dsZip, 1, 1, dsStated.Tables[0].Rows[i]["state_name"].ToString());
                                    }


                                }
                            }
                        }
                    }
                    #endregion
                }
                else if (cboWebsite.SelectedItem.ToString() == "CarPost")
                {
                    #region carpost
                    DataSet dsStated = new DataSet();
                    dsStated = objDal.GetStates_CarPost();
                    string dsZip = "";
                    DataSet dsCities = new DataSet();
                    if (dsStated.Tables[0].Rows.Count > 0)
                    {
                        if (stopcarposts)
                        {
                            for (int i = 0; i < dsStated.Tables[0].Rows.Count; i++)
                            {
                                if (stopcarposts)
                                {
                                    DataSet dsStatesAfter = new DataSet();
                                    dsStatesAfter = objDal.GetStates_CarPost();
                                    DataView dv = dsStatesAfter.Tables[0].DefaultView;
                                    dv.RowFilter = "state_name='" + dsStated.Tables[0].Rows[i]["state_name"].ToString() + "'";
                                    DataTable dt = dv.ToTable();
                                    if (dt.Rows.Count == 0)
                                    { continue; }
                                    dsCities = objDal.GetCities_CarPost(dsStated.Tables[0].Rows[i]["State_Name"].ToString());
                                    for (int j = 0; j < dsCities.Tables[0].Rows.Count; j++)
                                    {
                                        dsZip = dsCities.Tables[0].Rows[j]["zipcode"].ToString();
                                        objDal.SaveTransaction_CarPost(dsCities.Tables[0].Rows[j]["zipstate"].ToString(), dsZip, 1, 0, dsStated.Tables[0].Rows[i]["state_name"].ToString());
                                        cmbStatesCars.Text = dsCities.Tables[0].Rows[j]["zipstate"].ToString();
                                        txtZipCars.Text = dsZip;
                                        GetCarPostLeads(dsCities.Tables[0].Rows[j]["zipstate"].ToString(), dsZip);
                                        objDal.SaveTransaction_CarPost(dsCities.Tables[0].Rows[j]["zipstate"].ToString(), dsZip, 1, 1, dsStated.Tables[0].Rows[i]["state_name"].ToString());
                                    }


                                }
                            }
                            MessageBox.Show("Leads Collected for CarPost Site");
                        }
                    }
                    #endregion
                    
                }
                else if (cboWebsite.SelectedItem.ToString() == "ClassifiedsValley")
                {
                    GetClassifiedsValleyLeads();
                }
                else if (cboWebsite.SelectedItem.ToString() == "ClassifiedsCiti")
                {
                    GetClassifiedsCitiLeads();
                }
                if (cmbAutoCA.Visible == true)
                {
                    if (cmbAutoCA.Text == "Select")
                    {
                        MessageBox.Show("Please select State.");
                        return;
                    }
                }
                if (cboWebsite.SelectedItem.ToString() == "AutoTradersCA")
                {
                    getLeadsAutoTrades_CA();
                }
                if (cmbState.Visible == true)
                {
                    if (cmbState.Text == "Select")
                    {
                        MessageBox.Show("Please select State.");
                    }
                }
                if (cmbStatesCars.Visible == true)
                {
                    if (cmbStatesCars.Text == "Select")
                    {
                        MessageBox.Show("Please select State.");
                    }
                }
                
                
           // }
           // catch (Exception ex)
           //{
           //   MessageBox.Show(ex.ToString());
           //}
        }
        private void btnEnd_Click(object sender, EventArgs e)
        {
            if (cboWebsite.SelectedIndex != -1)
            {
                if (cboWebsite.SelectedItem.ToString() == "Craigslist")
                {
                    objDal.SaveTransaction_Cars(SessionStateid, "1", "1");
                    SessionStateid = 0;
                }
            }
            varexit = 0;
            if (cboWebsite.SelectedIndex != -1)
            {
                if (cboWebsite.SelectedItem.ToString() == "Craigslist")
                    stopclo = false;
                if (cboWebsite.SelectedItem.ToString() == "CraigslistDealers")
                    stopcld = false;
                if (cboWebsite.SelectedItem.ToString() == "CraigslistRVS")
                    stopclrv = false;
                if (cboWebsite.SelectedItem.ToString() == "Cars.com")
                    stopcars = false;
                if (cboWebsite.SelectedItem.ToString() == "CarPost")
                    stopcarposts = false;

            }
            Application.Exit();
        }

        private void cboWebsite_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboWebsite.SelectedItem.ToString() == "Craigslist")
            {
                Global.DBConnection = "DBCars";

                Form1.ActiveForm.Text = "Craigslist";
                //  CCityNames.Visible = true;
                LoadStates_Cars();
                LoadCities();
                cmbState.Visible = true;
                lblCity.Visible = true;
                lblState.Visible = true;
                cmbStatesCars.Visible = false;
                txtZipCars.Visible = false;
                lblState.Text = "State";
                lblCity.Text = "";
                lnkProcessLeads.Visible = true;

            }

            else if (cboWebsite.SelectedItem.ToString() == "CraigslistDealers")
            {
                Global.DBConnection = "DBDealersCars";
                Form1.ActiveForm.Text = "CraigslistDealers";

                //  CCityNames.Visible = true;
                LoadStates_Cars();
                LoadCities();
                cmbState.Visible = true;
                lblCity.Visible = true;
                lblState.Visible = true;
                cmbStatesCars.Visible = false;
                txtZipCars.Visible = false;
                lblState.Text = "State";
                lblCity.Text = "";
                lnkProcessLeads.Visible = true;

            }


            else if (cboWebsite.SelectedItem.ToString() == "AutoTrades")
            {
                Form1.ActiveForm.Text = "AutoTrades";
                CCityNames.Visible = false;
                cmbState.Visible = false;
                lblCity.Visible = false;
                lblState.Visible = false;
                cmbStatesCars.Visible = false;
                txtZipCars.Visible = false;
                lnkProcessLeads.Visible = false;
            }
            else if (cboWebsite.SelectedItem.ToString() == "Cars.com" || cboWebsite.SelectedItem.ToString() == "CarPost")
            {
                if (cboWebsite.SelectedItem.ToString() == "Cars.com")
                    Form1.ActiveForm.Text = "Cars.com";
                else Form1.ActiveForm.Text = "CarPost";
                Global.DBConnection = "DBCars";
                Load_States_Cars();
                Load_Zip_ByState_Cars();
                cmbStatesCars.Visible = true;
                txtZipCars.Visible = true;
                CCityNames.Visible = false;
                cmbState.Visible = false;

                lblState.Text = "State";
                lblCity.Text = "Zip";
                lblCity.Visible = true;
                lblState.Visible = true;
                lnkProcessLeads.Visible = false;
            }
            else if (cboWebsite.SelectedItem.ToString() == "AutoTradersCA")
            {
                Form1.ActiveForm.Text = "AutoTradesCA";
                CCityNames.Visible = false;
                cmbState.Visible = false;
                lblCity.Visible = false;
                lblState.Visible = false;
                cmbStatesCars.Visible = false;
                txtZipCars.Visible = false;

                cmbAutoCA.Visible = true;
                lblAutoCA.Visible = true;
                lnkProcessLeads.Visible = false;
                // GetLeadsFromCarsSite();
            }
            else if (cboWebsite.SelectedItem.ToString() == "CraigslistRVS")
            {
                Form1.ActiveForm.Text = "CraigslistRVS";
                Global.DBConnection = "Rvleads";
                CCityNames.Visible = false;
                LoadStates();
                LoadCities();
                cmbState.Visible = true;
                lblCity.Visible = false;
                lblState.Visible = true;
                cmbStatesCars.Visible = false;
                txtZipCars.Visible = false;
                lblState.Text = "State";
                lblCity.Text = "City";
                lnkProcessLeads.Visible = false;
                lnkProcessLeads.Visible = true;

            }
            else if (cboWebsite.SelectedItem.ToString() == "CraigslistBikes")
            {
                Form1.ActiveForm.Text = "CraigslistBikes";
                Global.DBConnection = "DBBikes";

                LoadStates_Cars();
                LoadCities();
                cmbState.Visible = true;
                lblCity.Visible = true;
                lblState.Visible = true;
                cmbStatesCars.Visible = false;
                txtZipCars.Visible = false;
                lblState.Text = "State";
                lblCity.Text = "";
                lnkProcessLeads.Visible = true;

            }
        }

        private void cmbStatesCars_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet dsZip = new DataSet();
            if (cmbStatesCars.SelectedIndex != 0)
            {
                //int stateId = Convert.ToInt32(cmbStatesCars.SelectedValue);
                dsZip = objDal.GetZip_ByState_FromCarsSite(1);
                if (dsZip.Tables[0].Rows.Count > 0)
                {
                    txtZipCars.Text = dsZip.Tables[0].Rows[0]["zipcode"].ToString();
                    txtZipCars.Enabled = false;
                }
                else
                {
                    txtZipCars.Text = "";
                }
            }
        }

        private void cmbState_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet dsCities = new DataSet();
            if (cmbState.SelectedIndex != 0)
            {
                int stateId = Convert.ToInt32(cmbState.SelectedValue);
                dsCities = objDal.GetCities(stateId);
                if (dsCities.Tables[0].Rows.Count > 0)
                {
                    CCityNames.DisplayMember = "Table.CITYNAME";
                    CCityNames.ValueMember = "Table.CITYCODE";
                    CCityNames.DataSource = dsCities;
                }
                else
                {
                    CCityNames.DataBindings.Clear();
                    CCityNames.DataSource = null;
                }
            }
        }

        private void cmb_Days_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_Days.SelectedIndex == -1)
            {

                edate = sdate.AddDays(-2);
                sdate = sdate.Date + ts;
                edate = edate.Date + ts;
            }
            if (cmb_Days.SelectedItem.ToString() == "Last 1Day")
            {


                edate = sdate.AddDays(-1);
                //edate = sdate;
                sdate = sdate.Date + ts;
                edate = edate.Date + ts;
            }
            if (cmb_Days.SelectedItem.ToString() == "Last 2Days")
            {

                edate = sdate.AddDays(-2);
                //edate = sdate.AddDays(-1);
                sdate = sdate.Date + ts;
                edate = edate.Date + ts;
            }
            if (cmb_Days.SelectedItem.ToString() == "Last 3Days")
            {

                edate = sdate.AddDays(-3);
                sdate = sdate.Date + ts;
                edate = edate.Date + ts;
            }
            if (cmb_Days.SelectedItem.ToString() == "Last 4Days")
            {

                edate = sdate.AddDays(-4);
                sdate = sdate.Date + ts;
                edate = edate.Date + ts;
            }
            if (cmb_Days.SelectedItem.ToString() == "Last 5Days")
            {

                edate = sdate.AddDays(-5);
                sdate = sdate.Date + ts;
                edate = edate.Date + ts;
            }
            if (cmb_Days.SelectedItem.ToString() == "Last 6Days")
            {

                edate = sdate.AddDays(-6);
                sdate = sdate.Date + ts;
                edate = edate.Date + ts;
            }
            if (cmb_Days.SelectedItem.ToString() == "Last 7Days")
            {

                edate = sdate.AddDays(-7);
                sdate = sdate.Date + ts;
                edate = edate.Date + ts;
            }
        }

        private void Del_History_Click(object sender, EventArgs e)
        {
            if (cboWebsite.SelectedIndex == -1)
                MessageBox.Show("Select Website for Deleting Transaction History");
            else
            {
                var confirmResult = MessageBox.Show("Do you want to delete transaction history ?", "Confirm Creation!!", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    if (cboWebsite.SelectedItem.ToString() == "Craigslist" || cboWebsite.SelectedItem.ToString() == "CraigslistDealers" || cboWebsite.SelectedItem.ToString() == "CraigslistRVS" )
                    {
                        objDal.del_history("delete from dbo.tbl_transaction_craiglist ;delete from dbo.tbl_TransWithCity_Craigslist;");
                    }
                    else if (cboWebsite.SelectedItem.ToString() == "Cars.com")
                    {
                        objDal.del_history("delete from dbo.tbl_transaction_cars");
                    }
                    else if (cboWebsite.SelectedItem.ToString() == "CarPost")
                    {
                        objDal.del_history("delete from dbo.tbl_transaction_carpost");
                    }
                }
                else if (confirmResult == DialogResult.No)
                {
                    MessageBox.Show("History not deleted");
                }
            }
        }
    }
}
