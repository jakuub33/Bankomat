using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bankomat
{
    /// <summary>
    /// Aplikacja przedstawia Bankomat, z którego można wypłacać banknoty oraz uzupełniać je w odpowiednim trybie.
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Bankomat przechodzi w Użytkownika.
        /// </summary>
        private void btnUzytkownika_Click(object sender, RoutedEventArgs e)
        {
            btnUzytkownika.Background = Brushes.LightGreen;
            btnSerwisowy.ClearValue(BackgroundProperty);

            btnWyplata.Visibility = Visibility.Visible;
            btnIloscBanknotow.Visibility = Visibility.Hidden;
            lbIlosc.Visibility = Visibility.Hidden;
            lbSaldo.Visibility = Visibility.Hidden;
            txtIlosc.Visibility = Visibility.Hidden;
            btnUsun2.Visibility = Visibility.Hidden;
            cbNominaly.Visibility = Visibility.Hidden;
            tbTekst.Text = "";
            txtIlosc.Text = "";
            SprawdzStanUzytkownika();
        }

        /// <summary>
        /// Sprawdzany jest stan bankomatu w trybie Użytkownika.
        /// </summary>
        private void SprawdzStanUzytkownika()
        {
            if (Operacje.n200.Count > 0 && Operacje.n100.Count > 0 && Operacje.n50.Count > 0 && Operacje.n20.Count > 0 && Operacje.n10.Count > 0)
            {
                tbStan.Text = "Aktualny stan to: GOTOWY DO DZIAŁANIA";
            }
            else if (Operacje.n200.Count == 0 && Operacje.n100.Count == 0 && Operacje.n50.Count == 0
                        && Operacje.n20.Count == 0 && Operacje.n10.Count == 0)
            {
                tbStan.Text = "Aktualny stan to: PUSTY";
            }
            else
            {
                tbStan.Text = "Aktualny stan to: DZIAŁAJĄCY";
            }
        }

        /// <summary>
        /// Bankomat przechodzi w Serwisowy.
        /// </summary>
        private void btnSerwisowy_Click(object sender, RoutedEventArgs e)
        {
            btnSerwisowy.Background = Brushes.LightGreen;
            btnUzytkownika.ClearValue(BackgroundProperty);

            btnWyplata.Visibility = Visibility.Hidden;
            btnIloscBanknotow.Visibility = Visibility.Visible;
            tbTekst.Text = "";
            txtKwota.Visibility = Visibility.Hidden;
            btnUsun.Visibility = Visibility.Hidden;
            btn1.Visibility = Visibility.Hidden;
            btn2.Visibility = Visibility.Hidden;
            btn3.Visibility = Visibility.Hidden;
            btn4.Visibility = Visibility.Hidden;
            btn5.Visibility = Visibility.Hidden;
            btn6.Visibility = Visibility.Hidden;
            btn7.Visibility = Visibility.Hidden;
            btn8.Visibility = Visibility.Hidden;
            btn9.Visibility = Visibility.Hidden;
            btn0.Visibility = Visibility.Hidden;
            btnWyplac.Visibility = Visibility.Hidden;            
            tb200.Text = "";
            tb100.Text = "";
            tb50.Text = "";
            tb20.Text = "";
            tb10.Text = "";
            SprawdzStanSerwisowy();
        }

        /// <summary>
        /// Sprawdzany jest stan bankomatu w trybie Użytkownika.
        /// </summary>
        private void SprawdzStanSerwisowy()
        {
            if (Operacje.n200.Count > 0 && Operacje.n100.Count > 0 && Operacje.n50.Count > 0 && Operacje.n20.Count > 0 && Operacje.n10.Count > 0)
            {
                tbStan.Text = "Aktualny stan to: GOTOWY DO DZIAŁANIA";
            }
            else if (Operacje.n200.Count == 0 && Operacje.n100.Count == 0 && Operacje.n50.Count == 0
                        && Operacje.n20.Count == 0 && Operacje.n10.Count == 0)
            {
                tbStan.Text = "Aktualny stan to: PUSTY";
            }
        }

        /// <summary>
        /// Pokazywany jest interfejs potrzebny do wyplaty.
        /// </summary>
        private void btnWyplata_Click(object sender, RoutedEventArgs e)
        {
            tbTekst.Text = "";
            tbTekst.Text = "Podaj kwotę, którą chcesz wypłacić";
            txtKwota.Visibility = Visibility.Visible;
            btnUsun.Visibility = Visibility.Visible;
            btn1.Visibility = Visibility.Visible;
            btn2.Visibility = Visibility.Visible;
            btn3.Visibility = Visibility.Visible;
            btn4.Visibility = Visibility.Visible;
            btn5.Visibility = Visibility.Visible;
            btn6.Visibility = Visibility.Visible;
            btn7.Visibility = Visibility.Visible;
            btn8.Visibility = Visibility.Visible;
            btn9.Visibility = Visibility.Visible;
            btn0.Visibility = Visibility.Visible;
            btnWyplac.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Opisuje jak działa algorytm wydawania banknotów.
        /// </summary>
        private void btnWyplac_Click(object sender, RoutedEventArgs e)
        {
            tb200.Text = "";
            tb100.Text = "";
            tb50.Text = "";
            tb20.Text = "";
            tb10.Text = "";
            if (txtKwota.Text.Length > 0)
            {
                Operacje.kwota = int.Parse(txtKwota.Text);                
                if (Operacje.kwota > 0)
                {
                    //Łączna kwota, która jest w bankomacie.
                    int saldo = Operacje.n200.Count * 200 + Operacje.n100.Count * 100 + Operacje.n50.Count * 50 + Operacje.n20.Count * 20
                                + Operacje.n10.Count * 10;
                    if (Operacje.kwota <= saldo)
                    {
                        if (Operacje.kwota % 10 == 0)
                        {
                            bool blad = false; bool blad200 = false; bool blad100 = false; bool blad50 = false; bool blad20 = false; bool blad10 = false;
                            int srednia, ilosc200, ilosc100, ilosc50, ilosc20, ilosc10, suma;
                            ilosc200 = 0; ilosc100 = 0; ilosc50 = 0; ilosc20 = 0; ilosc10 = 0; suma = 0;

                            suma = Operacje.n200.Count + Operacje.n100.Count + Operacje.n50.Count + Operacje.n20.Count + Operacje.n10.Count;
                            srednia = (Operacje.n200.Count + Operacje.n100.Count + Operacje.n50.Count + Operacje.n20.Count + Operacje.n10.Count) / 5;
                            while (Operacje.kwota > 0 && !blad)
                            {
                                //Banknot 200 ZŁ
                                if ((Operacje.kwota >= 200 && Operacje.n200.Count > 0 && Operacje.n200.Count > Operacje.n100.Count) ||
                                    (Operacje.kwota >= 200 && Operacje.n200.Count > 0 && Operacje.n200.Count >= srednia) ||
                                    (Operacje.kwota >= 200 && Operacje.n200.Count > suma - Operacje.n200.Count))
                                {
                                    ilosc200++;
                                    Operacje.kwota -= 200;
                                    Operacje.n200.RemoveAt(0);
                                    suma = Operacje.n200.Count + Operacje.n100.Count + Operacje.n50.Count + Operacje.n20.Count + Operacje.n10.Count;
                                    srednia = (Operacje.n200.Count + Operacje.n100.Count + Operacje.n50.Count + Operacje.n20.Count + Operacje.n10.Count) / 5;
                                }
                                else { blad200 = true; }
                                //Banknot 100 ZŁ
                                if ((Operacje.kwota >= 100 && Operacje.n100.Count > 0 && Operacje.n100.Count > Operacje.n50.Count && Operacje.n100.Count > Operacje.n20.Count) ||
                                    (Operacje.kwota >= 100 && Operacje.n100.Count > 0 && Operacje.n100.Count >= srednia) ||
                                    (Operacje.kwota >= 100 && Operacje.n100.Count > suma - Operacje.n100.Count))
                                {
                                    ilosc100++;
                                    Operacje.kwota -= 100;
                                    Operacje.n100.RemoveAt(0);
                                    suma = Operacje.n200.Count + Operacje.n100.Count + Operacje.n50.Count + Operacje.n20.Count + Operacje.n10.Count;
                                    srednia = (Operacje.n200.Count + Operacje.n100.Count + Operacje.n50.Count + Operacje.n20.Count + Operacje.n10.Count) / 5;
                                }
                                else { blad100 = true; }
                                //Banknot 50 ZŁ
                                if ((Operacje.kwota >= 50 && Operacje.n50.Count > 0 && Operacje.n50.Count > Operacje.n20.Count && Operacje.n50.Count > Operacje.n10.Count) ||
                                    (Operacje.kwota >= 50 && Operacje.n50.Count > 0 && Operacje.n50.Count >= srednia) ||
                                    (Operacje.kwota >= 50 && Operacje.n50.Count > suma - Operacje.n50.Count))
                                {
                                    ilosc50++;
                                    Operacje.kwota -= 50;
                                    Operacje.n50.RemoveAt(0);
                                    suma = Operacje.n200.Count + Operacje.n100.Count + Operacje.n50.Count + Operacje.n20.Count + Operacje.n10.Count;
                                    srednia = (Operacje.n200.Count + Operacje.n100.Count + Operacje.n50.Count + Operacje.n20.Count + Operacje.n10.Count) / 5;
                                }
                                else { blad50 = true; }
                                //Banknot 20 ZŁ
                                if ((Operacje.kwota >= 20 && Operacje.n20.Count > 0 && Operacje.n20.Count >= Operacje.n10.Count) ||
                                    (Operacje.kwota == 20 && Operacje.n20.Count > 0) ||
                                    (Operacje.kwota >= 20 && Operacje.n20.Count > suma - Operacje.n20.Count))
                                {
                                    ilosc20++;
                                    Operacje.kwota -= 20;
                                    Operacje.n20.RemoveAt(0);
                                    suma = Operacje.n200.Count + Operacje.n100.Count + Operacje.n50.Count + Operacje.n20.Count + Operacje.n10.Count;
                                    srednia = (Operacje.n200.Count + Operacje.n100.Count + Operacje.n50.Count + Operacje.n20.Count + Operacje.n10.Count) / 5;
                                }
                                else { blad20 = true; }
                                //Banknot 10 ZŁ
                                if ((Operacje.kwota >= 10 && Operacje.n10.Count > 0) ||
                                    (Operacje.kwota == 10 && Operacje.n10.Count > 0) ||
                                    (Operacje.kwota >= 10 && Operacje.n10.Count > suma - Operacje.n10.Count))
                                {
                                    ilosc10++;
                                    Operacje.kwota -= 10;
                                    Operacje.n10.RemoveAt(0);
                                    suma = Operacje.n200.Count + Operacje.n100.Count + Operacje.n50.Count + Operacje.n20.Count + Operacje.n10.Count;
                                    srednia = (Operacje.n200.Count + Operacje.n100.Count + Operacje.n50.Count + Operacje.n20.Count + Operacje.n10.Count) / 5;
                                }
                                else { blad10 = true; }

                                if (blad200 && blad100 && blad50 && blad20 && blad10)
                                {
                                    blad = true;    //Jeśli kwota nie może być zrealizowana, trzeba zatrzymać pętle.
                                }
                            }
                            if (blad) //Jeśli nie ma potrzebnych nominałów, to do pojemników trzeba oddać nominały, które z początku były zarezerwowane.
                            {
                                while (ilosc200 > 0)
                                {
                                    Operacje.n200.Add(200);
                                    ilosc200 -= 1;
                                }                                
                                while (ilosc100 > 0)
                                {
                                    Operacje.n100.Add(100);
                                    ilosc100 -= 1;
                                }
                                while (ilosc50 > 0)
                                {
                                    Operacje.n50.Add(50);
                                    ilosc50 -= 1;
                                }
                                while (ilosc20 > 0)
                                {
                                    Operacje.n20.Add(20);
                                    ilosc20 -= 1;
                                }
                                while (ilosc10 > 0)
                                {
                                    Operacje.n10.Add(10);
                                    ilosc10 -= 1;
                                }
                                MessageBox.Show("Brak odpowiednich nominałów!", "Błąd!", MessageBoxButton.OK, MessageBoxImage.Error);
                                txtKwota.Text = "";
                            }
                            else
                            {
                                if (ilosc200 > 0)
                                {
                                    tb200.Text = "Wypłacono " + ilosc200 + " razy 200 ZŁ";
                                }
                                if (ilosc100 > 0)
                                {
                                    tb100.Text = "Wypłacono " + ilosc100 + " razy 100 ZŁ";
                                }
                                if (ilosc50 > 0)
                                {
                                    tb50.Text = "Wypłacono " + ilosc50 + " razy 50 ZŁ";
                                }
                                if (ilosc20 > 0)
                                {
                                    tb20.Text = "Wypłacono " + ilosc20 + " razy 20 ZŁ";
                                }
                                if (ilosc10 > 0)
                                {
                                    tb10.Text = "Wypłacono " + ilosc10 + " razy 10 ZŁ";
                                }
                                MessageBox.Show("Pamiętaj o wzięciu pieniędzy!", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);
                                txtKwota.Text = "";
                            }
                            SprawdzStanUzytkownika();
                        }
                        else
                        {
                            MessageBox.Show("Kwota musi być podzielna przez 10!", "Błąd!", MessageBoxButton.OK, MessageBoxImage.Error);
                            txtKwota.Text = "";
                        }
                    }
                    else
                    {
                        MessageBox.Show("Brak wystarczających środków!", "Błąd!", MessageBoxButton.OK, MessageBoxImage.Error);
                        txtKwota.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Kwota musi być większa od 0!", "Błąd!", MessageBoxButton.OK, MessageBoxImage.Error);
                    txtKwota.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Nie podano kwoty!", "Błąd!", MessageBoxButton.OK, MessageBoxImage.Error);
                txtKwota.Text = "";
            }            
        }

        /// <summary>
        /// Pokazywany jest interfejs potrzebny do trybu Serwisowego.
        /// </summary>
        private void btnIloscBanknotow_Click(object sender, RoutedEventArgs e)
        {
            WyswietlNominaly();
            lbIlosc.Visibility = Visibility.Visible;
            txtIlosc.Visibility = Visibility.Visible;
            btnUsun2.Visibility = Visibility.Visible;
            cbNominaly.Visibility = Visibility.Visible;
            txtIlosc.Text = "";
            lbSaldo.Visibility = Visibility.Visible;
        }

        private void WyswietlNominaly()
        {
            tbTekst.Text = "Dostępne nominały:";
            tbTekst.Text = tbTekst.Text + "\n Ilość 200 ZŁ: " + Operacje.n200.Count.ToString();
            tbTekst.Text = tbTekst.Text + "\n Ilość 100 ZŁ: " + Operacje.n100.Count.ToString();
            tbTekst.Text = tbTekst.Text + "\n Ilość 50 ZŁ: " + Operacje.n50.Count.ToString();
            tbTekst.Text = tbTekst.Text + "\n Ilość 20 ZŁ: " + Operacje.n20.Count.ToString();
            tbTekst.Text = tbTekst.Text + "\n Ilość 10 ZŁ: " + Operacje.n10.Count.ToString();
            lbSaldo.Content = "Stan bankomatu: " + (Operacje.n200.Count * 200 + Operacje.n100.Count * 100 + Operacje.n50.Count * 50 + Operacje.n20.Count * 20
                                + Operacje.n10.Count * 10) + " ZŁ";
        }

        //Opcje do wybrania w ComboBox.
        private void cbAll_Selected(object sender, RoutedEventArgs e)
        {
            int ilosc = 0;
            if (txtIlosc.Text.Length > 0)
            {
                ilosc = int.Parse(txtIlosc.Text);
                Operacje.n200.Clear();
                Operacje.n100.Clear();
                Operacje.n50.Clear();
                Operacje.n20.Clear();
                Operacje.n10.Clear();
                while (ilosc > 0)
                {
                    Operacje.n200.Add(200);
                    Operacje.n100.Add(100);
                    Operacje.n50.Add(50);
                    Operacje.n20.Add(20);
                    Operacje.n10.Add(10);
                    ilosc -= 1;
                }                
                WyswietlNominaly();
                SprawdzStanSerwisowy();
            }
            else
            {
                MessageBox.Show("Nie podano ilości!", "Błąd!", MessageBoxButton.OK, MessageBoxImage.Error);
                txtIlosc.Text = "";
            }
        }

        private void cb200_Selected(object sender, RoutedEventArgs e)
        {
            int ilosc = 0;
            if (txtIlosc.Text.Length > 0)
            {
                ilosc = int.Parse(txtIlosc.Text);
                Operacje.n200.Clear();
                while (ilosc > 0)
                {
                    Operacje.n200.Add(200);
                    ilosc -= 1;
                }                
                WyswietlNominaly();
                SprawdzStanSerwisowy();
            }
            else
            {
                MessageBox.Show("Nie podano ilości!", "Błąd!", MessageBoxButton.OK, MessageBoxImage.Error);
                txtIlosc.Text = "";
            }
        }

        private void cb100_Selected(object sender, RoutedEventArgs e)
        {
            int ilosc = 0;
            if (txtIlosc.Text.Length > 0)
            {
                ilosc = int.Parse(txtIlosc.Text);
                Operacje.n100.Clear();
                while (ilosc > 0)
                {
                    Operacje.n100.Add(100);
                    ilosc -= 1;
                }                
                WyswietlNominaly();
                SprawdzStanSerwisowy();
            }
            else
            {
                MessageBox.Show("Nie podano ilości!", "Błąd!", MessageBoxButton.OK, MessageBoxImage.Error);
                txtIlosc.Text = "";
            }
        }

        private void cb50_Selected(object sender, RoutedEventArgs e)
        {
            int ilosc = 0;
            if (txtIlosc.Text.Length > 0)
            {
                ilosc = int.Parse(txtIlosc.Text);
                Operacje.n50.Clear();
                while (ilosc > 0)
                {
                    Operacje.n50.Add(50);
                    ilosc -= 1;
                }                
                WyswietlNominaly();
                SprawdzStanSerwisowy();
            }
            else
            {
                MessageBox.Show("Nie podano ilości!", "Błąd!", MessageBoxButton.OK, MessageBoxImage.Error);
                txtIlosc.Text = "";
            }
        }

        private void cb20_Selected(object sender, RoutedEventArgs e)
        {
            int ilosc = 0;
            if (txtIlosc.Text.Length > 0)
            {
                ilosc = int.Parse(txtIlosc.Text);
                Operacje.n20.Clear();
                while (ilosc > 0)
                {
                    Operacje.n20.Add(20);
                    ilosc -= 1;
                }                
                WyswietlNominaly();
                SprawdzStanSerwisowy();
            }
            else
            {
                MessageBox.Show("Nie podano ilości!", "Błąd!", MessageBoxButton.OK, MessageBoxImage.Error);
                txtIlosc.Text = "";
            }
        }

        private void cb10_Selected(object sender, RoutedEventArgs e)
        {
            int ilosc = 0;
            if (txtIlosc.Text.Length > 0)
            {
                ilosc = int.Parse(txtIlosc.Text);
                Operacje.n10.Clear();
                while (ilosc > 0)
                {
                    Operacje.n10.Add(10);
                    ilosc -= 1;
                }                
                WyswietlNominaly();
                SprawdzStanSerwisowy();
            }
            else
            {
                MessageBox.Show("Nie podano ilości!", "Błąd!", MessageBoxButton.OK, MessageBoxImage.Error);
                txtIlosc.Text = "";
            }
        }     

        private void TylkoCyfry_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtKwota.Text, "[^0-9]"))
            {
                MessageBox.Show("Możesz wpisać tylko cyfry!", "Błąd!", MessageBoxButton.OK, MessageBoxImage.Error);
                txtKwota.Text = "";
            }
        }

        private void txtIloscCyfry_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtIlosc.Text, "[^0-9]"))
            {
                MessageBox.Show("Możesz wpisać tylko cyfry!", "Błąd!", MessageBoxButton.OK, MessageBoxImage.Error);
                txtIlosc.Text = "";
            }
        }

        //Guziki za pomocą których możemy dodać kwotę do wypłaty.
        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            txtKwota.Text = txtKwota.Text + "1";
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            txtKwota.Text = txtKwota.Text + "2";
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            txtKwota.Text = txtKwota.Text + "3";
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            txtKwota.Text = txtKwota.Text + "4";
        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            txtKwota.Text = txtKwota.Text + "5";
        }

        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            txtKwota.Text = txtKwota.Text + "6";
        }

        private void btn7_Click(object sender, RoutedEventArgs e)
        {
            txtKwota.Text = txtKwota.Text + "7";
        }

        private void btn8_Click(object sender, RoutedEventArgs e)
        {
            txtKwota.Text = txtKwota.Text + "8";
        }

        private void btn9_Click(object sender, RoutedEventArgs e)
        {
            txtKwota.Text = txtKwota.Text + "9";
        }

        private void btn0_Click(object sender, RoutedEventArgs e)
        {
            txtKwota.Text = txtKwota.Text + "0";
        }

        private void btnUsun_Click(object sender, RoutedEventArgs e)
        {
            txtKwota.Text = "";
        }

        private void btnUsun2_Click(object sender, RoutedEventArgs e)
        {
            txtIlosc.Text = "";
        }        
    }
}
