using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class game : MonoBehaviour
{

    public double Cookies;
    public double CPS;
    public double CPC;
    public double Autoclickers;
    public double Doublecookies;
    public double AutoclickerPrice;
    public double DoublecookiePrice;
    public TMP_Text CookiesText;
    public TMP_Text AutoclickerShop;
    public TMP_Text DoublecookieShop;

    // Start is called before the first frame update
    void Start()
    {
        ResetData();
        StartCoroutine(Tick());
    }

    public void ResetData()
    {
        Cookies = 0;
        CPS = 0;
        CPC = 1;
        Autoclickers = 0;
        Doublecookies = 0;
        AutoclickerPrice = 25;
        DoublecookiePrice = 50;
    }

    IEnumerator Tick()
    {
        yield return new WaitForSeconds(1);
        Cookies += CPS;
        StartCoroutine(Tick());
    }

    public void BakeCookie()
    {
        Cookies += CPC;
    }

    public void BuyAutoclicker()
    {
        if (Cookies >= AutoclickerPrice)
        {
            Cookies -= AutoclickerPrice;
            Autoclickers += 1;
            CPS += 1;
            AutoclickerPrice += 50;
        }
    }

    public void BuyDoublecookie()
    {
        if (Cookies >= DoublecookiePrice)
        {
            Cookies -= DoublecookiePrice;
            Doublecookies += 1;
            CPC += 1;
            DoublecookiePrice += 25;
        }
    }

    // Update is called once per frame
    void Update()
    {
        CookiesText.text =  "Cookies: " + Cookies;
        DoublecookieShop.text = "Buy Doublecookie (" + DoublecookiePrice + " Cookies";
        AutoclickerShop.text = "Buy Autoclicker (" + AutoclickerPrice + " Cookies";
    }
}
