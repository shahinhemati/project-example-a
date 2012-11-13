using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Collections;

namespace IB.Common
{
    class ConvertToVND
    {
        static Hashtable hs = new Hashtable();
        static Hashtable h = new Hashtable();
        public static string ConvertToMoney(string number)
        {

            h["0"] = " nghìn ";
            h["1"] = " triệu ";
            h["2"] = " tỉ ";
            h["3"] = " nghìn tỉ ";
            h["4"] = " triệu tỉ ";
            h["5"] = " tỉ tỉ ";

            hs["0"] = "Lẻ";
            hs["1"] = "Một";
            hs["2"] = "Hai";
            hs["3"] = "Ba";
            hs["4"] = "Bốn";
            hs["5"] = "Năm";
            hs["6"] = "Sáu";
            hs["7"] = "Bảy";
            hs["8"] = "Tám";
            hs["9"] = "Chín";
            hs["10"] = "Mười";
            hs["11"] = "Mười một";
            hs["12"] = "Mười hai";
            hs["13"] = "Mười ba";
            hs["14"] = "Mười bốn";
            hs["15"] = "Mười lăm";
            hs["16"] = "Mười sáu";
            hs["17"] = "Mười bảy";
            hs["18"] = "Mười tám";
            hs["19"] = "Mười chín";
            hs["20"] = "Hai mươi";
            hs["30"] = "Ba mươi";
            hs["40"] = "Bốn mươi";
            hs["50"] = "Năm mươi";
            hs["60"] = "Sáu mươi";
            hs["70"] = "Bảy mươi";
            hs["80"] = "Tám mươi";
            hs["90"] = "Chín mươi";
            string returnkqua = "";

            string chuoicd;

            chuoicd = AddCommaToString(number);

            int countdauphay = 0;
            foreach (char item in chuoicd)
            {
                if (item == ',')
                {
                    countdauphay++;
                }
            }

            string[] chuoiktra = chuoicd.Split(',');

            for (int i = 0; i < chuoiktra.Length; i++)
            {
                countdauphay = countdauphay - 1;
                returnkqua += KTText(chuoiktra[i]);
                if (chuoiktra[i] != "000")
                {
                    returnkqua += h[countdauphay.ToString()];
                }

            }
            return returnkqua;

        }

        public static string AddCommaToString(string strInput)
        {
            string chuoicd;
            int sodu = strInput.Length % 3;

            if (sodu != 0)
            {
                chuoicd = strInput.Insert(sodu, ",");
                for (int i = 1; i < strInput.Length / 3; i++)
                {
                    sodu += 4;
                    chuoicd = chuoicd.Insert(sodu, ",");
                }
            }
            else
            {
                sodu += 3;
                chuoicd = strInput;
                for (int i = 1; i < strInput.Length / 3; i++)
                {
                    chuoicd = chuoicd.Insert(sodu, ",");
                    sodu += 4;

                }
            }
            return chuoicd;
        }


        private static string KTText(string text)
        {
            string kqua = "";
            
            if (text == "000" || text == "00" || text == "0")
            {
                kqua = "";
            }
            else if (text.Length == 3)
            {
                int dv, c, tram;
                dv = int.Parse(text.Substring(text.Length - 1));
                c = int.Parse(text.Substring(1));
                int chuc = c - dv;
                tram = int.Parse(text.Substring(0, 1));

                if (dv == 0 && chuc != 0)
                    kqua = hs[tram.ToString()] + " trăm " + hs[chuc.ToString()].ToString().ToLower() + " ";
                else if (chuc == 0 && dv == 0)
                    kqua = hs[tram.ToString()] + " trăm ";
                else if (tram == 0 && chuc == 0)
                {
                    if (dv != 1)
                        kqua = "không trăm " + hs[chuc.ToString()].ToString().ToLower() + " " + hs[dv.ToString()].ToString().ToLower() + " ";
                    else
                        kqua = "không trăm " + hs[chuc.ToString()].ToString().ToLower() + " một ";
                }
                else if (tram == 0)
                {
                    if (dv != 1)
                        kqua = "không trăm " + hs[chuc.ToString()].ToString().ToLower() + " " + hs[dv.ToString()].ToString().ToLower() + " ";
                    else
                        kqua = "không trăm " + hs[chuc.ToString()].ToString().ToLower() + " mốt ";
                }
                else
                {
                    if(dv!=1)
                        kqua = hs[tram.ToString()] + " trăm " + hs[chuc.ToString()].ToString().ToLower() + " " + hs[dv.ToString()].ToString().ToLower() + " ";
                    else
                        kqua = hs[tram.ToString()] + " trăm " + hs[chuc.ToString()].ToString().ToLower() + " mốt ";
                }
            }
            else if (text.Length == 2)
            {
                int dv;
                dv = int.Parse(text.Substring(1));
                int chuc = int.Parse(text) - dv;
                if (dv == 0)
                    kqua = hs[chuc.ToString()].ToString() + " ";
                else
                {
                    if (dv != 1||dv!=5)
                        kqua = hs[chuc.ToString()].ToString() + " " + hs[dv.ToString()].ToString().ToLower() + " ";
                    else if(dv==1)
                        kqua = hs[chuc.ToString()].ToString() + " mốt ";
                    else if(dv==5&&chuc==0)
                        kqua = hs[chuc.ToString()].ToString() + " năm ";
                }
            }
            else if (text.Length == 1)
            {
                int dv;
                dv = int.Parse(text);
                if (dv != 5)
                    kqua = hs[dv.ToString()].ToString() + " ";
                else
                    kqua = "năm ";

            }
            return kqua;
        }
    }
}
