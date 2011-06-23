using System.Drawing;

public class element
{
    private int x, y;
    private Rectangle klocek;
    private Color kolor;
    private bool pusta;
    public const int rozmiar = 15;

    //pusty klocek
    public element()
    {
        klocek = new Rectangle(x * rozmiar + 2, y * rozmiar + 2, rozmiar - 2, rozmiar - 2);
        pusta = false;
        x = y = 0;
        kolor = Color.Black;
    }

    //zmien polozenie
    public element(int a, int b)
    {
        x = a;
        y = b;
        klocek = new Rectangle(x * rozmiar + 2, y * rozmiar + 2, rozmiar - 2, rozmiar - 2);
        pusta = false;
        kolor = Color.Black;
    }

    //zmien polozenie i kolor
    public element(int a, int b, Color k)
    {
        x = a;
        y = b;
        kolor = k;
        klocek = new Rectangle(x * rozmiar + 2, y * rozmiar + 2, rozmiar - 2, rozmiar - 2);
        pusta = false;
    }
    public void setkolor(Color k)
    {
        kolor = k;
    }

    public Color getkolor()
    {
        return kolor;
    }

    public bool spr()
    {
        return pusta;
    }

  
    //wyswietlanie
    public void wyswietl(Graphics w)
    {
        SolidBrush barwa = new SolidBrush(kolor);
        w.FillRectangle(barwa, klocek);
        w.DrawRectangle(Pens.Black, klocek);
        pusta = true;
    }

    //usun
    public void usun(Graphics w, Color k)
    {
        SolidBrush barwa = new SolidBrush(k);
        w.FillRectangle(barwa, klocek);
        w.DrawRectangle(new Pen(barwa), klocek);
        pusta = false;
    }
}