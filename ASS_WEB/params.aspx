<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="params.aspx.cs" Inherits="ASS_WEB._params" Async="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
  

    <link href="StyleSheet1.css" rel="stylesheet" />

    <style type="text/css">
        .auto-style4 {
            width: 205px;
        }
        .auto-style5 {
            height: 23px;
            width: 205px;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Parametry</h1>
            <asp:Button ID="btnSave" CssClass="btnSuccess" runat="server" Text="Zapisz" OnClick="btnSave_Click" />


            <asp:Button ID="Button1" runat="server" Text="Test świateł włącz" OnClick="Button1_Click" />
              <asp:Button ID="Button2" runat="server" Text="Test świateł wyłącz" OnClick="Button2_Click" />


            <table>
                <tr>
                    <td class="auto-style4">
                        <asp:Label ID="Label1" runat="server" Text="Interwał detekcji obrotu taśmy"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="numwork" runat="server" TextMode="Number" Width="60px" ToolTip="Czas [ms] pomiędzy taktami, którego przekroczenie definiuje zatrzymanie taśmy maszyny"></asp:TextBox>
                    </td>
                    <td class="auto-style2">
                        &nbsp;</td>
                    <td colspan="3">
                        <asp:Label ID="Label4" runat="server" Text="Korekcja zajętych markerów"></asp:Label>

                    </td>
                    <td>
                        <asp:CheckBox ID="checkBox1" runat="server" ToolTip="Takt przesyłki zostanie skorygowany o wartość ilości tac, którą przesyłka zajmuje" />

                    </td>
                    <td class="auto-style2">
                        &nbsp;</td>
                    <td>
                        <asp:Label ID="Label10" runat="server" Text="Kamera 1 adres"></asp:Label>

                    </td>
                    <td>
                        <asp:TextBox ID="txCamAdres" runat="server" Width="250px"></asp:TextBox>

                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">
                         <asp:Label ID="Label7" runat="server" Text="Korekcja po zatrzymaniu"></asp:Label>

                    </td>
                    <td>
                         <asp:TextBox ID="numstopcorection" runat="server" TextMode="Number" Width="60px" ToolTip="Po wykryciu zatrzymania maszyny, wszystkie przesyłki na taśmie po ponownym uruchomieniu otrzymują określoną liczbę taktów"></asp:TextBox>
                    </td>
                    <td class="auto-style2">
                        &nbsp;</td>
                    <td colspan="3">
                        <asp:Label ID="Label3" runat="server" Text="Gaszenie lamp timerem"></asp:Label>

                    </td>
                    <td>
                        <asp:CheckBox ID="ckturnofftimer" runat="server" ToolTip="Lampa 2 zgaśnie po czasie określonym wartością z czujnika długości przesyłki" />

                    </td>
                    <td class="auto-style2">
                        &nbsp;</td>
                    <td>
                        <asp:Label ID="Label12" runat="server" Text="Kamera 1 zoom"></asp:Label>

                    </td>
                    <td>
                        <asp:TextBox ID="numzum1" runat="server" TextMode="Number" Width="60px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:Label ID="Label2" runat="server" Text="Liczba markerów taktu"></asp:Label>

                    </td>
                    <td>
                        <asp:TextBox ID="numalltacts" runat="server" TextMode="Number" Width="60px" ToolTip="Liczba wszystkich tac"></asp:TextBox>

                    </td>
                    <td class="auto-style2">
                           &nbsp;</td>
                    <td colspan="3">
                           <asp:Label ID="Label8" runat="server" Text="Automatyczne ustawianie interwału detekcji STOP"></asp:Label>

                    </td>
                    <td>
                         <asp:CheckBox ID="ckautowork" runat="server" ToolTip="Wartość pola Interwał detekcji obrotu taśmy jest ustawiana automatycznie na podstawie średniej czasów pomiędzy taktami + 100ms" />
                    </td>
                    <td class="auto-style2">
                          &nbsp;</td>
                    <td>
                        <asp:Label ID="Label14" runat="server" Text="Kamera 1 tryb mono"></asp:Label>

                    </td>
                    <td>
                         <asp:CheckBox ID="ckblack1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:Label ID="Label6" runat="server" Text="Długość taktu [cm]"></asp:Label>

                    </td>
                    <td>
                        <asp:TextBox ID="numtactlenghtcm" runat="server" TextMode="Number" Width="60px" ToolTip="Odległosć [cm] pomiędzy tagami tac"></asp:TextBox>
                    </td>
                    <td class="auto-style2">
                        &nbsp;</td>
                    <td colspan="3">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td class="auto-style2">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style4">
                          <asp:Label ID="Label9" runat="server" Text="Takty czujnika STOP"></asp:Label>

                    </td>
                    <td>
                          <asp:TextBox ID="numSTOPTacts" runat="server" TextMode="Number" Width="60px" ToolTip="Numer taktu czujnika STOP"></asp:TextBox>
                    </td>
                    <td class="auto-style2">
                        &nbsp;</td>
                    <td colspan="3">
                        &nbsp;</td>
                    <td>
                         &nbsp;</td>
                    <td class="auto-style2">
                        &nbsp;</td>
                    <td>
                        <asp:Label ID="Label11" runat="server" Text="Kamera 2 adres"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txCamadres2" runat="server" Width="250px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">

                        <asp:Label ID="Label5" runat="server" Text="Współczynnik czujnika długości przesyłki"></asp:Label>

                    </td>
                    <td>

                        <asp:TextBox ID="numparcelfactor" runat="server" TextMode="Number" Width="60px" ToolTip="Wartość przez którąodczytana długość przesyłki jest mnożona"></asp:TextBox>

                    </td>
                    <td class="auto-style2">

                        &nbsp;</td>
                    <td colspan="3">

                        &nbsp;</td>
                    <td>

                        &nbsp;</td>
                    <td class="auto-style2">

                        &nbsp;</td>
                    <td>

                        <asp:Label ID="Label13" runat="server" Text="Kamera 2 zoom"></asp:Label>

                    </td>
                    <td>

                        <asp:TextBox ID="numzum2" runat="server" TextMode="Number" Width="60px"></asp:TextBox>

                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">

                           Długość tagu tacy</td>
                    <td>

                        <asp:TextBox ID="txplateidlenght" runat="server" TextMode="Number" Width="60px" ToolTip="Liczba znakód tagu tacy"></asp:TextBox>

                    </td>
                    <td class="auto-style2">

                        &nbsp;</td>
                    <td colspan="3">

                        &nbsp;</td>
                    <td>

                        &nbsp;</td>
                    <td class="auto-style2">

                        &nbsp;</td>
                    <td>

                        <asp:Label ID="Label15" runat="server" Text="Kamera 2 tryb mono"></asp:Label>

                    </td>
                    <td>

                         <asp:CheckBox ID="ckBlack2" runat="server" />

                    </td>
                </tr>
                <tr>
                    <td class="auto-style5">

                           &nbsp;</td>
                    <td class="auto-style1">

                        &nbsp;</td>
                    <td class="auto-style3">

                        &nbsp;</td>
                    <td class="auto-style1">

                        &nbsp;</td>
                    <td class="auto-style3">

                        &nbsp;</td>
                    <td class="auto-style1">

                        &nbsp;</td>
                    <td class="auto-style1">

                        &nbsp;</td>
                    <td class="auto-style3">

                        &nbsp;</td>
                    <td class="auto-style1">

                        &nbsp;</td>
                    <td class="auto-style1">

                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style5">

                           &nbsp;</td>
                    <td class="auto-style1">

                        &nbsp;</td>
                    <td class="auto-style3">

                        &nbsp;</td>
                    <td class="auto-style1">

                        &nbsp;</td>
                    <td class="auto-style3">

                        &nbsp;</td>
                    <td class="auto-style1">

                        &nbsp;</td>
                    <td class="auto-style1">

                        &nbsp;</td>
                    <td class="auto-style3">

                        &nbsp;</td>
                    <td class="auto-style1">

                        &nbsp;</td>
                    <td class="auto-style1">

                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style5">

                    </td>
                    <td class="auto-style1">

                        <asp:Label ID="Label22" runat="server" Text="Port"></asp:Label>

                    </td>
                    <td class="auto-style3">

                        &nbsp;</td>
                    <td class="auto-style1">

                        <asp:Label ID="Label23" runat="server" Text="Prędkość"></asp:Label>

                    </td>
                    <td class="auto-style3">

                    </td>
                    <td class="auto-style1">

                        <asp:Label ID="Label24" runat="server" Text="Opóźnienie odczytu"></asp:Label>

                    </td>
                    <td class="auto-style1">

                        <asp:Label ID="Label40" runat="server" Text="Aktywny"></asp:Label>

                    </td>
                    <td class="auto-style3">

                        &nbsp;</td>
                    <td class="auto-style1">

                    </td>
                    <td class="auto-style1">

                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">

                        <asp:Label ID="Label16" runat="server" Text="Start sensor"></asp:Label>

                    </td>
                    <td>

                        <asp:DropDownList ID="ddlstart" runat="server">
                            <asp:ListItem>COM1</asp:ListItem>
                            <asp:ListItem>COM2</asp:ListItem>
                            <asp:ListItem>COM3</asp:ListItem>
                            <asp:ListItem>COM4</asp:ListItem>
                            <asp:ListItem>COM5</asp:ListItem>
                            <asp:ListItem>COM6</asp:ListItem>
                            <asp:ListItem>COM7</asp:ListItem>
                            <asp:ListItem>COM8</asp:ListItem>
                            <asp:ListItem>COM9</asp:ListItem>
                            <asp:ListItem>COM10</asp:ListItem>
                            <asp:ListItem>COM11</asp:ListItem>
                            <asp:ListItem>COM12</asp:ListItem>
                            <asp:ListItem>COM13</asp:ListItem>
                            <asp:ListItem>COM14</asp:ListItem>
                            <asp:ListItem>COM15</asp:ListItem>
                            <asp:ListItem>COM16</asp:ListItem>
                            <asp:ListItem>COM17</asp:ListItem>
                            <asp:ListItem>COM18</asp:ListItem>
                            <asp:ListItem>COM19</asp:ListItem>
                            <asp:ListItem>COM20</asp:ListItem>
                            <asp:ListItem>COM21</asp:ListItem>
                            <asp:ListItem>COM22</asp:ListItem>
                            <asp:ListItem>COM23</asp:ListItem>
                            <asp:ListItem>COM24</asp:ListItem>
                            <asp:ListItem>COM25</asp:ListItem>
                            <asp:ListItem>COM26</asp:ListItem>
                            <asp:ListItem>COM27</asp:ListItem>
                            <asp:ListItem>COM28</asp:ListItem>
                            <asp:ListItem>COM29</asp:ListItem>
                            <asp:ListItem>COM30</asp:ListItem>
                            <asp:ListItem>COM31</asp:ListItem>
                            <asp:ListItem>COM32</asp:ListItem>
                            <asp:ListItem>COM33</asp:ListItem>
                            <asp:ListItem>COM34</asp:ListItem>
                            <asp:ListItem>COM35</asp:ListItem>
                            <asp:ListItem>COM36</asp:ListItem>
                            <asp:ListItem>COM37</asp:ListItem>
                            <asp:ListItem>COM38</asp:ListItem>
                            <asp:ListItem>COM39</asp:ListItem>
                            <asp:ListItem>COM40</asp:ListItem>
                            <asp:ListItem>COM41</asp:ListItem>
                            <asp:ListItem>COM42</asp:ListItem>
                            <asp:ListItem>COM43</asp:ListItem>
                            <asp:ListItem>COM44</asp:ListItem>
                            <asp:ListItem>COM45</asp:ListItem>
                            <asp:ListItem>COM46</asp:ListItem>
                            <asp:ListItem>COM47</asp:ListItem>
                            <asp:ListItem>COM48</asp:ListItem>
                            <asp:ListItem>COM49</asp:ListItem>
                            <asp:ListItem>COM50</asp:ListItem>
                            <asp:ListItem>COM51</asp:ListItem>
                            <asp:ListItem>COM52</asp:ListItem>
                            <asp:ListItem>COM53</asp:ListItem>
                            <asp:ListItem>COM54</asp:ListItem>
                            <asp:ListItem>COM55</asp:ListItem>
                            <asp:ListItem>COM56</asp:ListItem>
                            <asp:ListItem>COM57</asp:ListItem>
                            <asp:ListItem>COM58</asp:ListItem>
                            <asp:ListItem>COM59</asp:ListItem>
                            <asp:ListItem>COM60</asp:ListItem>
                            <asp:ListItem>COM61</asp:ListItem>
                            <asp:ListItem>COM62</asp:ListItem>
                            <asp:ListItem>COM63</asp:ListItem>
                            <asp:ListItem>COM64</asp:ListItem>
                            <asp:ListItem>COM65</asp:ListItem>
                            <asp:ListItem>COM66</asp:ListItem>
                            <asp:ListItem>COM67</asp:ListItem>
                            <asp:ListItem>COM68</asp:ListItem>
                            <asp:ListItem>COM69</asp:ListItem>
                            <asp:ListItem>COM70</asp:ListItem>
                            <asp:ListItem>COM71</asp:ListItem>
                            <asp:ListItem>COM72</asp:ListItem>
                            <asp:ListItem>COM73</asp:ListItem>
                            <asp:ListItem>COM74</asp:ListItem>
                            <asp:ListItem>COM75</asp:ListItem>
                            <asp:ListItem>COM76</asp:ListItem>
                            <asp:ListItem>COM77</asp:ListItem>
                            <asp:ListItem>COM78</asp:ListItem>
                            <asp:ListItem>COM79</asp:ListItem>
                            <asp:ListItem>COM80</asp:ListItem>
                            <asp:ListItem>COM81</asp:ListItem>
                            <asp:ListItem>COM82</asp:ListItem>
                            <asp:ListItem>COM83</asp:ListItem>
                            <asp:ListItem>COM84</asp:ListItem>
                            <asp:ListItem>COM85</asp:ListItem>
                            <asp:ListItem>COM86</asp:ListItem>
                            <asp:ListItem>COM87</asp:ListItem>
                            <asp:ListItem>COM88</asp:ListItem>
                            <asp:ListItem>COM89</asp:ListItem>
                            <asp:ListItem>COM90</asp:ListItem>
                            <asp:ListItem>COM91</asp:ListItem>
                            <asp:ListItem>COM92</asp:ListItem>
                            <asp:ListItem>COM93</asp:ListItem>
                            <asp:ListItem>COM94</asp:ListItem>
                            <asp:ListItem>COM95</asp:ListItem>
                            <asp:ListItem>COM96</asp:ListItem>
                            <asp:ListItem>COM97</asp:ListItem>
                            <asp:ListItem>COM98</asp:ListItem>
                            <asp:ListItem>COM99</asp:ListItem>
                        </asp:DropDownList>

                    </td>
                    <td class="auto-style2">

                        &nbsp;</td>
                    <td>

                        <asp:TextBox ID="txstartspeed" runat="server" TextMode="Number" Width="60px"></asp:TextBox>

                    </td>
                    <td class="auto-style2">

                    </td>
                    <td>

                        <asp:TextBox ID="txstartdelay" runat="server" TextMode="Number" Width="60px"></asp:TextBox>

                    </td>
                    <td>

                        <asp:CheckBox ID="CheckBox2" runat="server" />

                    </td>
                    <td class="auto-style2">

                        &nbsp;</td>
                    <td>

                    </td>
                    <td>

                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">

                        <asp:Label ID="Label17" runat="server" Text="Stop sensor"></asp:Label>

                    </td>
                    <td>

                        <asp:DropDownList ID="ddlstop" runat="server">
                                 <asp:ListItem>COM1</asp:ListItem>
                            <asp:ListItem>COM2</asp:ListItem>
                            <asp:ListItem>COM3</asp:ListItem>
                            <asp:ListItem>COM4</asp:ListItem>
                            <asp:ListItem>COM5</asp:ListItem>
                            <asp:ListItem>COM6</asp:ListItem>
                            <asp:ListItem>COM7</asp:ListItem>
                            <asp:ListItem>COM8</asp:ListItem>
                            <asp:ListItem>COM9</asp:ListItem>
                            <asp:ListItem>COM10</asp:ListItem>
                            <asp:ListItem>COM11</asp:ListItem>
                            <asp:ListItem>COM12</asp:ListItem>
                            <asp:ListItem>COM13</asp:ListItem>
                            <asp:ListItem>COM14</asp:ListItem>
                            <asp:ListItem>COM15</asp:ListItem>
                            <asp:ListItem>COM16</asp:ListItem>
                            <asp:ListItem>COM17</asp:ListItem>
                            <asp:ListItem>COM18</asp:ListItem>
                            <asp:ListItem>COM19</asp:ListItem>
                            <asp:ListItem>COM20</asp:ListItem>
                            <asp:ListItem>COM21</asp:ListItem>
                            <asp:ListItem>COM22</asp:ListItem>
                            <asp:ListItem>COM23</asp:ListItem>
                            <asp:ListItem>COM24</asp:ListItem>
                            <asp:ListItem>COM25</asp:ListItem>
                            <asp:ListItem>COM26</asp:ListItem>
                            <asp:ListItem>COM27</asp:ListItem>
                            <asp:ListItem>COM28</asp:ListItem>
                            <asp:ListItem>COM29</asp:ListItem>
                            <asp:ListItem>COM30</asp:ListItem>
                            <asp:ListItem>COM31</asp:ListItem>
                            <asp:ListItem>COM32</asp:ListItem>
                            <asp:ListItem>COM33</asp:ListItem>
                            <asp:ListItem>COM34</asp:ListItem>
                            <asp:ListItem>COM35</asp:ListItem>
                            <asp:ListItem>COM36</asp:ListItem>
                            <asp:ListItem>COM37</asp:ListItem>
                            <asp:ListItem>COM38</asp:ListItem>
                            <asp:ListItem>COM39</asp:ListItem>
                            <asp:ListItem>COM40</asp:ListItem>
                            <asp:ListItem>COM41</asp:ListItem>
                            <asp:ListItem>COM42</asp:ListItem>
                            <asp:ListItem>COM43</asp:ListItem>
                            <asp:ListItem>COM44</asp:ListItem>
                            <asp:ListItem>COM45</asp:ListItem>
                            <asp:ListItem>COM46</asp:ListItem>
                            <asp:ListItem>COM47</asp:ListItem>
                            <asp:ListItem>COM48</asp:ListItem>
                            <asp:ListItem>COM49</asp:ListItem>
                            <asp:ListItem>COM50</asp:ListItem>
                            <asp:ListItem>COM51</asp:ListItem>
                            <asp:ListItem>COM52</asp:ListItem>
                            <asp:ListItem>COM53</asp:ListItem>
                            <asp:ListItem>COM54</asp:ListItem>
                            <asp:ListItem>COM55</asp:ListItem>
                            <asp:ListItem>COM56</asp:ListItem>
                            <asp:ListItem>COM57</asp:ListItem>
                            <asp:ListItem>COM58</asp:ListItem>
                            <asp:ListItem>COM59</asp:ListItem>
                            <asp:ListItem>COM60</asp:ListItem>
                            <asp:ListItem>COM61</asp:ListItem>
                            <asp:ListItem>COM62</asp:ListItem>
                            <asp:ListItem>COM63</asp:ListItem>
                            <asp:ListItem>COM64</asp:ListItem>
                            <asp:ListItem>COM65</asp:ListItem>
                            <asp:ListItem>COM66</asp:ListItem>
                            <asp:ListItem>COM67</asp:ListItem>
                            <asp:ListItem>COM68</asp:ListItem>
                            <asp:ListItem>COM69</asp:ListItem>
                            <asp:ListItem>COM70</asp:ListItem>
                            <asp:ListItem>COM71</asp:ListItem>
                            <asp:ListItem>COM72</asp:ListItem>
                            <asp:ListItem>COM73</asp:ListItem>
                            <asp:ListItem>COM74</asp:ListItem>
                            <asp:ListItem>COM75</asp:ListItem>
                            <asp:ListItem>COM76</asp:ListItem>
                            <asp:ListItem>COM77</asp:ListItem>
                            <asp:ListItem>COM78</asp:ListItem>
                            <asp:ListItem>COM79</asp:ListItem>
                            <asp:ListItem>COM80</asp:ListItem>
                            <asp:ListItem>COM81</asp:ListItem>
                            <asp:ListItem>COM82</asp:ListItem>
                            <asp:ListItem>COM83</asp:ListItem>
                            <asp:ListItem>COM84</asp:ListItem>
                            <asp:ListItem>COM85</asp:ListItem>
                            <asp:ListItem>COM86</asp:ListItem>
                            <asp:ListItem>COM87</asp:ListItem>
                            <asp:ListItem>COM88</asp:ListItem>
                            <asp:ListItem>COM89</asp:ListItem>
                            <asp:ListItem>COM90</asp:ListItem>
                            <asp:ListItem>COM91</asp:ListItem>
                            <asp:ListItem>COM92</asp:ListItem>
                            <asp:ListItem>COM93</asp:ListItem>
                            <asp:ListItem>COM94</asp:ListItem>
                            <asp:ListItem>COM95</asp:ListItem>
                            <asp:ListItem>COM96</asp:ListItem>
                            <asp:ListItem>COM97</asp:ListItem>
                            <asp:ListItem>COM98</asp:ListItem>
                            <asp:ListItem>COM99</asp:ListItem>
                        </asp:DropDownList>

                    </td>
                    <td class="auto-style2">

                        &nbsp;</td>
                    <td>

                        <asp:TextBox ID="txstopspeed" runat="server" TextMode="Number" Width="60px"></asp:TextBox>

                    </td>
                    <td class="auto-style2">

                    </td>
                    <td>

                        <asp:TextBox ID="txstopdelay" runat="server" TextMode="Number" Width="60px"></asp:TextBox>

                    </td>
                    <td>

                        <asp:CheckBox ID="CheckBox3" runat="server" />

                    </td>
                    <td class="auto-style2">

                        &nbsp;</td>
                    <td>

                    </td>
                    <td>

                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">

                        <asp:Label ID="Label18" runat="server" Text="Tact sensor"></asp:Label>

                    </td>
                    <td>

                        <asp:DropDownList ID="ddltact" runat="server">
                                 <asp:ListItem>COM1</asp:ListItem>
                            <asp:ListItem>COM2</asp:ListItem>
                            <asp:ListItem>COM3</asp:ListItem>
                            <asp:ListItem>COM4</asp:ListItem>
                            <asp:ListItem>COM5</asp:ListItem>
                            <asp:ListItem>COM6</asp:ListItem>
                            <asp:ListItem>COM7</asp:ListItem>
                            <asp:ListItem>COM8</asp:ListItem>
                            <asp:ListItem>COM9</asp:ListItem>
                            <asp:ListItem>COM10</asp:ListItem>
                            <asp:ListItem>COM11</asp:ListItem>
                            <asp:ListItem>COM12</asp:ListItem>
                            <asp:ListItem>COM13</asp:ListItem>
                            <asp:ListItem>COM14</asp:ListItem>
                            <asp:ListItem>COM15</asp:ListItem>
                            <asp:ListItem>COM16</asp:ListItem>
                            <asp:ListItem>COM17</asp:ListItem>
                            <asp:ListItem>COM18</asp:ListItem>
                            <asp:ListItem>COM19</asp:ListItem>
                            <asp:ListItem>COM20</asp:ListItem>
                            <asp:ListItem>COM21</asp:ListItem>
                            <asp:ListItem>COM22</asp:ListItem>
                            <asp:ListItem>COM23</asp:ListItem>
                            <asp:ListItem>COM24</asp:ListItem>
                            <asp:ListItem>COM25</asp:ListItem>
                            <asp:ListItem>COM26</asp:ListItem>
                            <asp:ListItem>COM27</asp:ListItem>
                            <asp:ListItem>COM28</asp:ListItem>
                            <asp:ListItem>COM29</asp:ListItem>
                            <asp:ListItem>COM30</asp:ListItem>
                            <asp:ListItem>COM31</asp:ListItem>
                            <asp:ListItem>COM32</asp:ListItem>
                            <asp:ListItem>COM33</asp:ListItem>
                            <asp:ListItem>COM34</asp:ListItem>
                            <asp:ListItem>COM35</asp:ListItem>
                            <asp:ListItem>COM36</asp:ListItem>
                            <asp:ListItem>COM37</asp:ListItem>
                            <asp:ListItem>COM38</asp:ListItem>
                            <asp:ListItem>COM39</asp:ListItem>
                            <asp:ListItem>COM40</asp:ListItem>
                            <asp:ListItem>COM41</asp:ListItem>
                            <asp:ListItem>COM42</asp:ListItem>
                            <asp:ListItem>COM43</asp:ListItem>
                            <asp:ListItem>COM44</asp:ListItem>
                            <asp:ListItem>COM45</asp:ListItem>
                            <asp:ListItem>COM46</asp:ListItem>
                            <asp:ListItem>COM47</asp:ListItem>
                            <asp:ListItem>COM48</asp:ListItem>
                            <asp:ListItem>COM49</asp:ListItem>
                            <asp:ListItem>COM50</asp:ListItem>
                            <asp:ListItem>COM51</asp:ListItem>
                            <asp:ListItem>COM52</asp:ListItem>
                            <asp:ListItem>COM53</asp:ListItem>
                            <asp:ListItem>COM54</asp:ListItem>
                            <asp:ListItem>COM55</asp:ListItem>
                            <asp:ListItem>COM56</asp:ListItem>
                            <asp:ListItem>COM57</asp:ListItem>
                            <asp:ListItem>COM58</asp:ListItem>
                            <asp:ListItem>COM59</asp:ListItem>
                            <asp:ListItem>COM60</asp:ListItem>
                            <asp:ListItem>COM61</asp:ListItem>
                            <asp:ListItem>COM62</asp:ListItem>
                            <asp:ListItem>COM63</asp:ListItem>
                            <asp:ListItem>COM64</asp:ListItem>
                            <asp:ListItem>COM65</asp:ListItem>
                            <asp:ListItem>COM66</asp:ListItem>
                            <asp:ListItem>COM67</asp:ListItem>
                            <asp:ListItem>COM68</asp:ListItem>
                            <asp:ListItem>COM69</asp:ListItem>
                            <asp:ListItem>COM70</asp:ListItem>
                            <asp:ListItem>COM71</asp:ListItem>
                            <asp:ListItem>COM72</asp:ListItem>
                            <asp:ListItem>COM73</asp:ListItem>
                            <asp:ListItem>COM74</asp:ListItem>
                            <asp:ListItem>COM75</asp:ListItem>
                            <asp:ListItem>COM76</asp:ListItem>
                            <asp:ListItem>COM77</asp:ListItem>
                            <asp:ListItem>COM78</asp:ListItem>
                            <asp:ListItem>COM79</asp:ListItem>
                            <asp:ListItem>COM80</asp:ListItem>
                            <asp:ListItem>COM81</asp:ListItem>
                            <asp:ListItem>COM82</asp:ListItem>
                            <asp:ListItem>COM83</asp:ListItem>
                            <asp:ListItem>COM84</asp:ListItem>
                            <asp:ListItem>COM85</asp:ListItem>
                            <asp:ListItem>COM86</asp:ListItem>
                            <asp:ListItem>COM87</asp:ListItem>
                            <asp:ListItem>COM88</asp:ListItem>
                            <asp:ListItem>COM89</asp:ListItem>
                            <asp:ListItem>COM90</asp:ListItem>
                            <asp:ListItem>COM91</asp:ListItem>
                            <asp:ListItem>COM92</asp:ListItem>
                            <asp:ListItem>COM93</asp:ListItem>
                            <asp:ListItem>COM94</asp:ListItem>
                            <asp:ListItem>COM95</asp:ListItem>
                            <asp:ListItem>COM96</asp:ListItem>
                            <asp:ListItem>COM97</asp:ListItem>
                            <asp:ListItem>COM98</asp:ListItem>
                            <asp:ListItem>COM99</asp:ListItem>
                        </asp:DropDownList>

                    </td>
                    <td class="auto-style2">

                        &nbsp;</td>
                    <td>

                        <asp:TextBox ID="txtactspeed" runat="server" TextMode="Number" Width="60px"></asp:TextBox>

                    </td>
                    <td class="auto-style2">

                    </td>
                    <td>

                        <asp:TextBox ID="txtactdelay" runat="server" TextMode="Number" Width="60px"></asp:TextBox>

                    </td>
                    <td>

                        <asp:CheckBox ID="CheckBox4" runat="server" />

                    </td>
                    <td class="auto-style2">

                        &nbsp;</td>
                    <td>

                        <asp:CheckBox ID="CheckBox24" runat="server" Text="Symulowanie tagów" ToolTip="Czujnik taktu określa id tacy zamiast czujnika kontroli trakcji" />

                    </td>
                    <td>

                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">

                        <asp:Label ID="Label20" runat="server" Text="Lenght sensor"></asp:Label>

                    </td>
                    <td>

                        <asp:DropDownList ID="ddllenght" runat="server">
                                 <asp:ListItem>COM1</asp:ListItem>
                            <asp:ListItem>COM2</asp:ListItem>
                            <asp:ListItem>COM3</asp:ListItem>
                            <asp:ListItem>COM4</asp:ListItem>
                            <asp:ListItem>COM5</asp:ListItem>
                            <asp:ListItem>COM6</asp:ListItem>
                            <asp:ListItem>COM7</asp:ListItem>
                            <asp:ListItem>COM8</asp:ListItem>
                            <asp:ListItem>COM9</asp:ListItem>
                            <asp:ListItem>COM10</asp:ListItem>
                            <asp:ListItem>COM11</asp:ListItem>
                            <asp:ListItem>COM12</asp:ListItem>
                            <asp:ListItem>COM13</asp:ListItem>
                            <asp:ListItem>COM14</asp:ListItem>
                            <asp:ListItem>COM15</asp:ListItem>
                            <asp:ListItem>COM16</asp:ListItem>
                            <asp:ListItem>COM17</asp:ListItem>
                            <asp:ListItem>COM18</asp:ListItem>
                            <asp:ListItem>COM19</asp:ListItem>
                            <asp:ListItem>COM20</asp:ListItem>
                            <asp:ListItem>COM21</asp:ListItem>
                            <asp:ListItem>COM22</asp:ListItem>
                            <asp:ListItem>COM23</asp:ListItem>
                            <asp:ListItem>COM24</asp:ListItem>
                            <asp:ListItem>COM25</asp:ListItem>
                            <asp:ListItem>COM26</asp:ListItem>
                            <asp:ListItem>COM27</asp:ListItem>
                            <asp:ListItem>COM28</asp:ListItem>
                            <asp:ListItem>COM29</asp:ListItem>
                            <asp:ListItem>COM30</asp:ListItem>
                            <asp:ListItem>COM31</asp:ListItem>
                            <asp:ListItem>COM32</asp:ListItem>
                            <asp:ListItem>COM33</asp:ListItem>
                            <asp:ListItem>COM34</asp:ListItem>
                            <asp:ListItem>COM35</asp:ListItem>
                            <asp:ListItem>COM36</asp:ListItem>
                            <asp:ListItem>COM37</asp:ListItem>
                            <asp:ListItem>COM38</asp:ListItem>
                            <asp:ListItem>COM39</asp:ListItem>
                            <asp:ListItem>COM40</asp:ListItem>
                            <asp:ListItem>COM41</asp:ListItem>
                            <asp:ListItem>COM42</asp:ListItem>
                            <asp:ListItem>COM43</asp:ListItem>
                            <asp:ListItem>COM44</asp:ListItem>
                            <asp:ListItem>COM45</asp:ListItem>
                            <asp:ListItem>COM46</asp:ListItem>
                            <asp:ListItem>COM47</asp:ListItem>
                            <asp:ListItem>COM48</asp:ListItem>
                            <asp:ListItem>COM49</asp:ListItem>
                            <asp:ListItem>COM50</asp:ListItem>
                            <asp:ListItem>COM51</asp:ListItem>
                            <asp:ListItem>COM52</asp:ListItem>
                            <asp:ListItem>COM53</asp:ListItem>
                            <asp:ListItem>COM54</asp:ListItem>
                            <asp:ListItem>COM55</asp:ListItem>
                            <asp:ListItem>COM56</asp:ListItem>
                            <asp:ListItem>COM57</asp:ListItem>
                            <asp:ListItem>COM58</asp:ListItem>
                            <asp:ListItem>COM59</asp:ListItem>
                            <asp:ListItem>COM60</asp:ListItem>
                            <asp:ListItem>COM61</asp:ListItem>
                            <asp:ListItem>COM62</asp:ListItem>
                            <asp:ListItem>COM63</asp:ListItem>
                            <asp:ListItem>COM64</asp:ListItem>
                            <asp:ListItem>COM65</asp:ListItem>
                            <asp:ListItem>COM66</asp:ListItem>
                            <asp:ListItem>COM67</asp:ListItem>
                            <asp:ListItem>COM68</asp:ListItem>
                            <asp:ListItem>COM69</asp:ListItem>
                            <asp:ListItem>COM70</asp:ListItem>
                            <asp:ListItem>COM71</asp:ListItem>
                            <asp:ListItem>COM72</asp:ListItem>
                            <asp:ListItem>COM73</asp:ListItem>
                            <asp:ListItem>COM74</asp:ListItem>
                            <asp:ListItem>COM75</asp:ListItem>
                            <asp:ListItem>COM76</asp:ListItem>
                            <asp:ListItem>COM77</asp:ListItem>
                            <asp:ListItem>COM78</asp:ListItem>
                            <asp:ListItem>COM79</asp:ListItem>
                            <asp:ListItem>COM80</asp:ListItem>
                            <asp:ListItem>COM81</asp:ListItem>
                            <asp:ListItem>COM82</asp:ListItem>
                            <asp:ListItem>COM83</asp:ListItem>
                            <asp:ListItem>COM84</asp:ListItem>
                            <asp:ListItem>COM85</asp:ListItem>
                            <asp:ListItem>COM86</asp:ListItem>
                            <asp:ListItem>COM87</asp:ListItem>
                            <asp:ListItem>COM88</asp:ListItem>
                            <asp:ListItem>COM89</asp:ListItem>
                            <asp:ListItem>COM90</asp:ListItem>
                            <asp:ListItem>COM91</asp:ListItem>
                            <asp:ListItem>COM92</asp:ListItem>
                            <asp:ListItem>COM93</asp:ListItem>
                            <asp:ListItem>COM94</asp:ListItem>
                            <asp:ListItem>COM95</asp:ListItem>
                            <asp:ListItem>COM96</asp:ListItem>
                            <asp:ListItem>COM97</asp:ListItem>
                            <asp:ListItem>COM98</asp:ListItem>
                            <asp:ListItem>COM99</asp:ListItem>
                        </asp:DropDownList>

                    </td>
                    <td class="auto-style2">

                        &nbsp;</td>
                    <td>

                        <asp:TextBox ID="txlenghtspeed" runat="server" TextMode="Number" Width="60px"></asp:TextBox>

                    </td>
                    <td class="auto-style2">

                    </td>
                    <td>

                        <asp:TextBox ID="txlenghtdelay" runat="server" TextMode="Number" Width="60px"></asp:TextBox>

                    </td>
                    <td>

                        <asp:CheckBox ID="CheckBox5" runat="server" />

                    </td>
                    <td class="auto-style2">

                        &nbsp;</td>
                    <td>

                    </td>
                    <td>

                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">

                        <asp:Label ID="Label19" runat="server" Text="Sygnalizacja"></asp:Label>

                    </td>
                    <td>

                        <asp:DropDownList ID="ddlsignaling" runat="server">
                                 <asp:ListItem>COM1</asp:ListItem>
                            <asp:ListItem>COM2</asp:ListItem>
                            <asp:ListItem>COM3</asp:ListItem>
                            <asp:ListItem>COM4</asp:ListItem>
                            <asp:ListItem>COM5</asp:ListItem>
                            <asp:ListItem>COM6</asp:ListItem>
                            <asp:ListItem>COM7</asp:ListItem>
                            <asp:ListItem>COM8</asp:ListItem>
                            <asp:ListItem>COM9</asp:ListItem>
                            <asp:ListItem>COM10</asp:ListItem>
                            <asp:ListItem>COM11</asp:ListItem>
                            <asp:ListItem>COM12</asp:ListItem>
                            <asp:ListItem>COM13</asp:ListItem>
                            <asp:ListItem>COM14</asp:ListItem>
                            <asp:ListItem>COM15</asp:ListItem>
                            <asp:ListItem>COM16</asp:ListItem>
                            <asp:ListItem>COM17</asp:ListItem>
                            <asp:ListItem>COM18</asp:ListItem>
                            <asp:ListItem>COM19</asp:ListItem>
                            <asp:ListItem>COM20</asp:ListItem>
                            <asp:ListItem>COM21</asp:ListItem>
                            <asp:ListItem>COM22</asp:ListItem>
                            <asp:ListItem>COM23</asp:ListItem>
                            <asp:ListItem>COM24</asp:ListItem>
                            <asp:ListItem>COM25</asp:ListItem>
                            <asp:ListItem>COM26</asp:ListItem>
                            <asp:ListItem>COM27</asp:ListItem>
                            <asp:ListItem>COM28</asp:ListItem>
                            <asp:ListItem>COM29</asp:ListItem>
                            <asp:ListItem>COM30</asp:ListItem>
                            <asp:ListItem>COM31</asp:ListItem>
                            <asp:ListItem>COM32</asp:ListItem>
                            <asp:ListItem>COM33</asp:ListItem>
                            <asp:ListItem>COM34</asp:ListItem>
                            <asp:ListItem>COM35</asp:ListItem>
                            <asp:ListItem>COM36</asp:ListItem>
                            <asp:ListItem>COM37</asp:ListItem>
                            <asp:ListItem>COM38</asp:ListItem>
                            <asp:ListItem>COM39</asp:ListItem>
                            <asp:ListItem>COM40</asp:ListItem>
                            <asp:ListItem>COM41</asp:ListItem>
                            <asp:ListItem>COM42</asp:ListItem>
                            <asp:ListItem>COM43</asp:ListItem>
                            <asp:ListItem>COM44</asp:ListItem>
                            <asp:ListItem>COM45</asp:ListItem>
                            <asp:ListItem>COM46</asp:ListItem>
                            <asp:ListItem>COM47</asp:ListItem>
                            <asp:ListItem>COM48</asp:ListItem>
                            <asp:ListItem>COM49</asp:ListItem>
                            <asp:ListItem>COM50</asp:ListItem>
                            <asp:ListItem>COM51</asp:ListItem>
                            <asp:ListItem>COM52</asp:ListItem>
                            <asp:ListItem>COM53</asp:ListItem>
                            <asp:ListItem>COM54</asp:ListItem>
                            <asp:ListItem>COM55</asp:ListItem>
                            <asp:ListItem>COM56</asp:ListItem>
                            <asp:ListItem>COM57</asp:ListItem>
                            <asp:ListItem>COM58</asp:ListItem>
                            <asp:ListItem>COM59</asp:ListItem>
                            <asp:ListItem>COM60</asp:ListItem>
                            <asp:ListItem>COM61</asp:ListItem>
                            <asp:ListItem>COM62</asp:ListItem>
                            <asp:ListItem>COM63</asp:ListItem>
                            <asp:ListItem>COM64</asp:ListItem>
                            <asp:ListItem>COM65</asp:ListItem>
                            <asp:ListItem>COM66</asp:ListItem>
                            <asp:ListItem>COM67</asp:ListItem>
                            <asp:ListItem>COM68</asp:ListItem>
                            <asp:ListItem>COM69</asp:ListItem>
                            <asp:ListItem>COM70</asp:ListItem>
                            <asp:ListItem>COM71</asp:ListItem>
                            <asp:ListItem>COM72</asp:ListItem>
                            <asp:ListItem>COM73</asp:ListItem>
                            <asp:ListItem>COM74</asp:ListItem>
                            <asp:ListItem>COM75</asp:ListItem>
                            <asp:ListItem>COM76</asp:ListItem>
                            <asp:ListItem>COM77</asp:ListItem>
                            <asp:ListItem>COM78</asp:ListItem>
                            <asp:ListItem>COM79</asp:ListItem>
                            <asp:ListItem>COM80</asp:ListItem>
                            <asp:ListItem>COM81</asp:ListItem>
                            <asp:ListItem>COM82</asp:ListItem>
                            <asp:ListItem>COM83</asp:ListItem>
                            <asp:ListItem>COM84</asp:ListItem>
                            <asp:ListItem>COM85</asp:ListItem>
                            <asp:ListItem>COM86</asp:ListItem>
                            <asp:ListItem>COM87</asp:ListItem>
                            <asp:ListItem>COM88</asp:ListItem>
                            <asp:ListItem>COM89</asp:ListItem>
                            <asp:ListItem>COM90</asp:ListItem>
                            <asp:ListItem>COM91</asp:ListItem>
                            <asp:ListItem>COM92</asp:ListItem>
                            <asp:ListItem>COM93</asp:ListItem>
                            <asp:ListItem>COM94</asp:ListItem>
                            <asp:ListItem>COM95</asp:ListItem>
                            <asp:ListItem>COM96</asp:ListItem>
                            <asp:ListItem>COM97</asp:ListItem>
                            <asp:ListItem>COM98</asp:ListItem>
                            <asp:ListItem>COM99</asp:ListItem>
                        </asp:DropDownList>

                    </td>
                    <td class="auto-style2">

                        &nbsp;</td>
                    <td>

                        <asp:TextBox ID="txsignalspeed" runat="server" TextMode="Number" Width="60px"></asp:TextBox>

                    </td>
                    <td class="auto-style2">

                    </td>
                    <td>

                        <asp:TextBox ID="txsignalingdelay" runat="server" TextMode="Number" Width="60px"></asp:TextBox>

                    </td>
                    <td>

                        <asp:CheckBox ID="CheckBox6" runat="server" />

                    </td>
                    <td class="auto-style2">

                        &nbsp;</td>
                    <td>

                    </td>
                    <td>

                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">

                        <asp:Label ID="Label21" runat="server" Text="Skaner 1"></asp:Label>

                    </td>
                    <td>

                        <asp:DropDownList ID="ddlscanner1" runat="server">
                                 <asp:ListItem>COM1</asp:ListItem>
                            <asp:ListItem>COM2</asp:ListItem>
                            <asp:ListItem>COM3</asp:ListItem>
                            <asp:ListItem>COM4</asp:ListItem>
                            <asp:ListItem>COM5</asp:ListItem>
                            <asp:ListItem>COM6</asp:ListItem>
                            <asp:ListItem>COM7</asp:ListItem>
                            <asp:ListItem>COM8</asp:ListItem>
                            <asp:ListItem>COM9</asp:ListItem>
                            <asp:ListItem>COM10</asp:ListItem>
                            <asp:ListItem>COM11</asp:ListItem>
                            <asp:ListItem>COM12</asp:ListItem>
                            <asp:ListItem>COM13</asp:ListItem>
                            <asp:ListItem>COM14</asp:ListItem>
                            <asp:ListItem>COM15</asp:ListItem>
                            <asp:ListItem>COM16</asp:ListItem>
                            <asp:ListItem>COM17</asp:ListItem>
                            <asp:ListItem>COM18</asp:ListItem>
                            <asp:ListItem>COM19</asp:ListItem>
                            <asp:ListItem>COM20</asp:ListItem>
                            <asp:ListItem>COM21</asp:ListItem>
                            <asp:ListItem>COM22</asp:ListItem>
                            <asp:ListItem>COM23</asp:ListItem>
                            <asp:ListItem>COM24</asp:ListItem>
                            <asp:ListItem>COM25</asp:ListItem>
                            <asp:ListItem>COM26</asp:ListItem>
                            <asp:ListItem>COM27</asp:ListItem>
                            <asp:ListItem>COM28</asp:ListItem>
                            <asp:ListItem>COM29</asp:ListItem>
                            <asp:ListItem>COM30</asp:ListItem>
                            <asp:ListItem>COM31</asp:ListItem>
                            <asp:ListItem>COM32</asp:ListItem>
                            <asp:ListItem>COM33</asp:ListItem>
                            <asp:ListItem>COM34</asp:ListItem>
                            <asp:ListItem>COM35</asp:ListItem>
                            <asp:ListItem>COM36</asp:ListItem>
                            <asp:ListItem>COM37</asp:ListItem>
                            <asp:ListItem>COM38</asp:ListItem>
                            <asp:ListItem>COM39</asp:ListItem>
                            <asp:ListItem>COM40</asp:ListItem>
                            <asp:ListItem>COM41</asp:ListItem>
                            <asp:ListItem>COM42</asp:ListItem>
                            <asp:ListItem>COM43</asp:ListItem>
                            <asp:ListItem>COM44</asp:ListItem>
                            <asp:ListItem>COM45</asp:ListItem>
                            <asp:ListItem>COM46</asp:ListItem>
                            <asp:ListItem>COM47</asp:ListItem>
                            <asp:ListItem>COM48</asp:ListItem>
                            <asp:ListItem>COM49</asp:ListItem>
                            <asp:ListItem>COM50</asp:ListItem>
                            <asp:ListItem>COM51</asp:ListItem>
                            <asp:ListItem>COM52</asp:ListItem>
                            <asp:ListItem>COM53</asp:ListItem>
                            <asp:ListItem>COM54</asp:ListItem>
                            <asp:ListItem>COM55</asp:ListItem>
                            <asp:ListItem>COM56</asp:ListItem>
                            <asp:ListItem>COM57</asp:ListItem>
                            <asp:ListItem>COM58</asp:ListItem>
                            <asp:ListItem>COM59</asp:ListItem>
                            <asp:ListItem>COM60</asp:ListItem>
                            <asp:ListItem>COM61</asp:ListItem>
                            <asp:ListItem>COM62</asp:ListItem>
                            <asp:ListItem>COM63</asp:ListItem>
                            <asp:ListItem>COM64</asp:ListItem>
                            <asp:ListItem>COM65</asp:ListItem>
                            <asp:ListItem>COM66</asp:ListItem>
                            <asp:ListItem>COM67</asp:ListItem>
                            <asp:ListItem>COM68</asp:ListItem>
                            <asp:ListItem>COM69</asp:ListItem>
                            <asp:ListItem>COM70</asp:ListItem>
                            <asp:ListItem>COM71</asp:ListItem>
                            <asp:ListItem>COM72</asp:ListItem>
                            <asp:ListItem>COM73</asp:ListItem>
                            <asp:ListItem>COM74</asp:ListItem>
                            <asp:ListItem>COM75</asp:ListItem>
                            <asp:ListItem>COM76</asp:ListItem>
                            <asp:ListItem>COM77</asp:ListItem>
                            <asp:ListItem>COM78</asp:ListItem>
                            <asp:ListItem>COM79</asp:ListItem>
                            <asp:ListItem>COM80</asp:ListItem>
                            <asp:ListItem>COM81</asp:ListItem>
                            <asp:ListItem>COM82</asp:ListItem>
                            <asp:ListItem>COM83</asp:ListItem>
                            <asp:ListItem>COM84</asp:ListItem>
                            <asp:ListItem>COM85</asp:ListItem>
                            <asp:ListItem>COM86</asp:ListItem>
                            <asp:ListItem>COM87</asp:ListItem>
                            <asp:ListItem>COM88</asp:ListItem>
                            <asp:ListItem>COM89</asp:ListItem>
                            <asp:ListItem>COM90</asp:ListItem>
                            <asp:ListItem>COM91</asp:ListItem>
                            <asp:ListItem>COM92</asp:ListItem>
                            <asp:ListItem>COM93</asp:ListItem>
                            <asp:ListItem>COM94</asp:ListItem>
                            <asp:ListItem>COM95</asp:ListItem>
                            <asp:ListItem>COM96</asp:ListItem>
                            <asp:ListItem>COM97</asp:ListItem>
                            <asp:ListItem>COM98</asp:ListItem>
                            <asp:ListItem>COM99</asp:ListItem>
                        </asp:DropDownList>

                    </td>
                    <td class="auto-style2">

                        &nbsp;</td>
                    <td>

                        <asp:TextBox ID="txscanner1speed" runat="server" TextMode="Number" Width="60px"></asp:TextBox>

                    </td>
                    <td class="auto-style2">

                    </td>
                    <td>

                        <asp:TextBox ID="txscanner1delay" runat="server" TextMode="Number" Width="60px"></asp:TextBox>

                    </td>
                    <td>

                        <asp:CheckBox ID="CheckBox7" runat="server" />

                    </td>
                    <td class="auto-style2">

                        &nbsp;</td>
                    <td>

                    </td>
                    <td>

                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">

                        <asp:Label ID="Label25" runat="server" Text="Czujnik kontroli trakcji"></asp:Label>

                    </td>
                    <td>

                        <asp:DropDownList ID="ddlrfidtactport" runat="server">
                                 <asp:ListItem>COM1</asp:ListItem>
                            <asp:ListItem>COM2</asp:ListItem>
                            <asp:ListItem>COM3</asp:ListItem>
                            <asp:ListItem>COM4</asp:ListItem>
                            <asp:ListItem>COM5</asp:ListItem>
                            <asp:ListItem>COM6</asp:ListItem>
                            <asp:ListItem>COM7</asp:ListItem>
                            <asp:ListItem>COM8</asp:ListItem>
                            <asp:ListItem>COM9</asp:ListItem>
                            <asp:ListItem>COM10</asp:ListItem>
                            <asp:ListItem>COM11</asp:ListItem>
                            <asp:ListItem>COM12</asp:ListItem>
                            <asp:ListItem>COM13</asp:ListItem>
                            <asp:ListItem>COM14</asp:ListItem>
                            <asp:ListItem>COM15</asp:ListItem>
                            <asp:ListItem>COM16</asp:ListItem>
                            <asp:ListItem>COM17</asp:ListItem>
                            <asp:ListItem>COM18</asp:ListItem>
                            <asp:ListItem>COM19</asp:ListItem>
                            <asp:ListItem>COM20</asp:ListItem>
                            <asp:ListItem>COM21</asp:ListItem>
                            <asp:ListItem>COM22</asp:ListItem>
                            <asp:ListItem>COM23</asp:ListItem>
                            <asp:ListItem>COM24</asp:ListItem>
                            <asp:ListItem>COM25</asp:ListItem>
                            <asp:ListItem>COM26</asp:ListItem>
                            <asp:ListItem>COM27</asp:ListItem>
                            <asp:ListItem>COM28</asp:ListItem>
                            <asp:ListItem>COM29</asp:ListItem>
                            <asp:ListItem>COM30</asp:ListItem>
                            <asp:ListItem>COM31</asp:ListItem>
                            <asp:ListItem>COM32</asp:ListItem>
                            <asp:ListItem>COM33</asp:ListItem>
                            <asp:ListItem>COM34</asp:ListItem>
                            <asp:ListItem>COM35</asp:ListItem>
                            <asp:ListItem>COM36</asp:ListItem>
                            <asp:ListItem>COM37</asp:ListItem>
                            <asp:ListItem>COM38</asp:ListItem>
                            <asp:ListItem>COM39</asp:ListItem>
                            <asp:ListItem>COM40</asp:ListItem>
                            <asp:ListItem>COM41</asp:ListItem>
                            <asp:ListItem>COM42</asp:ListItem>
                            <asp:ListItem>COM43</asp:ListItem>
                            <asp:ListItem>COM44</asp:ListItem>
                            <asp:ListItem>COM45</asp:ListItem>
                            <asp:ListItem>COM46</asp:ListItem>
                            <asp:ListItem>COM47</asp:ListItem>
                            <asp:ListItem>COM48</asp:ListItem>
                            <asp:ListItem>COM49</asp:ListItem>
                            <asp:ListItem>COM50</asp:ListItem>
                            <asp:ListItem>COM51</asp:ListItem>
                            <asp:ListItem>COM52</asp:ListItem>
                            <asp:ListItem>COM53</asp:ListItem>
                            <asp:ListItem>COM54</asp:ListItem>
                            <asp:ListItem>COM55</asp:ListItem>
                            <asp:ListItem>COM56</asp:ListItem>
                            <asp:ListItem>COM57</asp:ListItem>
                            <asp:ListItem>COM58</asp:ListItem>
                            <asp:ListItem>COM59</asp:ListItem>
                            <asp:ListItem>COM60</asp:ListItem>
                            <asp:ListItem>COM61</asp:ListItem>
                            <asp:ListItem>COM62</asp:ListItem>
                            <asp:ListItem>COM63</asp:ListItem>
                            <asp:ListItem>COM64</asp:ListItem>
                            <asp:ListItem>COM65</asp:ListItem>
                            <asp:ListItem>COM66</asp:ListItem>
                            <asp:ListItem>COM67</asp:ListItem>
                            <asp:ListItem>COM68</asp:ListItem>
                            <asp:ListItem>COM69</asp:ListItem>
                            <asp:ListItem>COM70</asp:ListItem>
                            <asp:ListItem>COM71</asp:ListItem>
                            <asp:ListItem>COM72</asp:ListItem>
                            <asp:ListItem>COM73</asp:ListItem>
                            <asp:ListItem>COM74</asp:ListItem>
                            <asp:ListItem>COM75</asp:ListItem>
                            <asp:ListItem>COM76</asp:ListItem>
                            <asp:ListItem>COM77</asp:ListItem>
                            <asp:ListItem>COM78</asp:ListItem>
                            <asp:ListItem>COM79</asp:ListItem>
                            <asp:ListItem>COM80</asp:ListItem>
                            <asp:ListItem>COM81</asp:ListItem>
                            <asp:ListItem>COM82</asp:ListItem>
                            <asp:ListItem>COM83</asp:ListItem>
                            <asp:ListItem>COM84</asp:ListItem>
                            <asp:ListItem>COM85</asp:ListItem>
                            <asp:ListItem>COM86</asp:ListItem>
                            <asp:ListItem>COM87</asp:ListItem>
                            <asp:ListItem>COM88</asp:ListItem>
                            <asp:ListItem>COM89</asp:ListItem>
                            <asp:ListItem>COM90</asp:ListItem>
                            <asp:ListItem>COM91</asp:ListItem>
                            <asp:ListItem>COM92</asp:ListItem>
                            <asp:ListItem>COM93</asp:ListItem>
                            <asp:ListItem>COM94</asp:ListItem>
                            <asp:ListItem>COM95</asp:ListItem>
                            <asp:ListItem>COM96</asp:ListItem>
                            <asp:ListItem>COM97</asp:ListItem>
                            <asp:ListItem>COM98</asp:ListItem>
                            <asp:ListItem>COM99</asp:ListItem>
                        </asp:DropDownList>

                    </td>
                    <td class="auto-style2">

                        &nbsp;</td>
                    <td>

                        <asp:TextBox ID="txrfidtactspeed" runat="server" TextMode="Number" Width="60px"></asp:TextBox>

                    </td>
                    <td class="auto-style2">

                    </td>
                    <td>

                        <asp:TextBox ID="txrfidtactdelay" runat="server" TextMode="Number" Width="60px"></asp:TextBox>

                    </td>
                    <td>

                        <asp:CheckBox ID="CheckBox8" runat="server" />

                    </td>
                    <td class="auto-style2">

                        &nbsp;</td>
                    <td>

                        <asp:CheckBox ID="CheckBox23" runat="server" Text="Taktowanie" ToolTip="Czujnik nadaje takt zamiast czujnika taktu" />

                    </td>
                    <td>

                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">

                    </td>
                    <td>

                    </td>
                    <td class="auto-style2">

                        &nbsp;</td>
                    <td>

                    </td>
                    <td class="auto-style2">

                    </td>
                    <td>

                    </td>
                    <td>

                        &nbsp;</td>
                    <td class="auto-style2">

                        &nbsp;</td>
                    <td>

                    </td>
                    <td>

                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">

                        <asp:Label ID="Label26" runat="server" Text="Czujnik trakcji Stanowisko 1"></asp:Label>

                    </td>
                    <td>

                        <asp:DropDownList ID="ddltractionPort1" runat="server">
                                 <asp:ListItem>COM1</asp:ListItem>
                            <asp:ListItem>COM2</asp:ListItem>
                            <asp:ListItem>COM3</asp:ListItem>
                            <asp:ListItem>COM4</asp:ListItem>
                            <asp:ListItem>COM5</asp:ListItem>
                            <asp:ListItem>COM6</asp:ListItem>
                            <asp:ListItem>COM7</asp:ListItem>
                            <asp:ListItem>COM8</asp:ListItem>
                            <asp:ListItem>COM9</asp:ListItem>
                            <asp:ListItem>COM10</asp:ListItem>
                            <asp:ListItem>COM11</asp:ListItem>
                            <asp:ListItem>COM12</asp:ListItem>
                            <asp:ListItem>COM13</asp:ListItem>
                            <asp:ListItem>COM14</asp:ListItem>
                            <asp:ListItem>COM15</asp:ListItem>
                            <asp:ListItem>COM16</asp:ListItem>
                            <asp:ListItem>COM17</asp:ListItem>
                            <asp:ListItem>COM18</asp:ListItem>
                            <asp:ListItem>COM19</asp:ListItem>
                            <asp:ListItem>COM20</asp:ListItem>
                            <asp:ListItem>COM21</asp:ListItem>
                            <asp:ListItem>COM22</asp:ListItem>
                            <asp:ListItem>COM23</asp:ListItem>
                            <asp:ListItem>COM24</asp:ListItem>
                            <asp:ListItem>COM25</asp:ListItem>
                            <asp:ListItem>COM26</asp:ListItem>
                            <asp:ListItem>COM27</asp:ListItem>
                            <asp:ListItem>COM28</asp:ListItem>
                            <asp:ListItem>COM29</asp:ListItem>
                            <asp:ListItem>COM30</asp:ListItem>
                            <asp:ListItem>COM31</asp:ListItem>
                            <asp:ListItem>COM32</asp:ListItem>
                            <asp:ListItem>COM33</asp:ListItem>
                            <asp:ListItem>COM34</asp:ListItem>
                            <asp:ListItem>COM35</asp:ListItem>
                            <asp:ListItem>COM36</asp:ListItem>
                            <asp:ListItem>COM37</asp:ListItem>
                            <asp:ListItem>COM38</asp:ListItem>
                            <asp:ListItem>COM39</asp:ListItem>
                            <asp:ListItem>COM40</asp:ListItem>
                            <asp:ListItem>COM41</asp:ListItem>
                            <asp:ListItem>COM42</asp:ListItem>
                            <asp:ListItem>COM43</asp:ListItem>
                            <asp:ListItem>COM44</asp:ListItem>
                            <asp:ListItem>COM45</asp:ListItem>
                            <asp:ListItem>COM46</asp:ListItem>
                            <asp:ListItem>COM47</asp:ListItem>
                            <asp:ListItem>COM48</asp:ListItem>
                            <asp:ListItem>COM49</asp:ListItem>
                            <asp:ListItem>COM50</asp:ListItem>
                            <asp:ListItem>COM51</asp:ListItem>
                            <asp:ListItem>COM52</asp:ListItem>
                            <asp:ListItem>COM53</asp:ListItem>
                            <asp:ListItem>COM54</asp:ListItem>
                            <asp:ListItem>COM55</asp:ListItem>
                            <asp:ListItem>COM56</asp:ListItem>
                            <asp:ListItem>COM57</asp:ListItem>
                            <asp:ListItem>COM58</asp:ListItem>
                            <asp:ListItem>COM59</asp:ListItem>
                            <asp:ListItem>COM60</asp:ListItem>
                            <asp:ListItem>COM61</asp:ListItem>
                            <asp:ListItem>COM62</asp:ListItem>
                            <asp:ListItem>COM63</asp:ListItem>
                            <asp:ListItem>COM64</asp:ListItem>
                            <asp:ListItem>COM65</asp:ListItem>
                            <asp:ListItem>COM66</asp:ListItem>
                            <asp:ListItem>COM67</asp:ListItem>
                            <asp:ListItem>COM68</asp:ListItem>
                            <asp:ListItem>COM69</asp:ListItem>
                            <asp:ListItem>COM70</asp:ListItem>
                            <asp:ListItem>COM71</asp:ListItem>
                            <asp:ListItem>COM72</asp:ListItem>
                            <asp:ListItem>COM73</asp:ListItem>
                            <asp:ListItem>COM74</asp:ListItem>
                            <asp:ListItem>COM75</asp:ListItem>
                            <asp:ListItem>COM76</asp:ListItem>
                            <asp:ListItem>COM77</asp:ListItem>
                            <asp:ListItem>COM78</asp:ListItem>
                            <asp:ListItem>COM79</asp:ListItem>
                            <asp:ListItem>COM80</asp:ListItem>
                            <asp:ListItem>COM81</asp:ListItem>
                            <asp:ListItem>COM82</asp:ListItem>
                            <asp:ListItem>COM83</asp:ListItem>
                            <asp:ListItem>COM84</asp:ListItem>
                            <asp:ListItem>COM85</asp:ListItem>
                            <asp:ListItem>COM86</asp:ListItem>
                            <asp:ListItem>COM87</asp:ListItem>
                            <asp:ListItem>COM88</asp:ListItem>
                            <asp:ListItem>COM89</asp:ListItem>
                            <asp:ListItem>COM90</asp:ListItem>
                            <asp:ListItem>COM91</asp:ListItem>
                            <asp:ListItem>COM92</asp:ListItem>
                            <asp:ListItem>COM93</asp:ListItem>
                            <asp:ListItem>COM94</asp:ListItem>
                            <asp:ListItem>COM95</asp:ListItem>
                            <asp:ListItem>COM96</asp:ListItem>
                            <asp:ListItem>COM97</asp:ListItem>
                            <asp:ListItem>COM98</asp:ListItem>
                            <asp:ListItem>COM99</asp:ListItem>
                        </asp:DropDownList>

                    </td>
                    <td class="auto-style2">

                        &nbsp;</td>
                    <td>

                        <asp:TextBox ID="txTractionSpeed1" runat="server" TextMode="Number" Width="60px"></asp:TextBox>

                    </td>
                    <td class="auto-style2">

                        &nbsp;</td>
                    <td>

                        <asp:TextBox ID="txTractionDelay1" runat="server" TextMode="Number" Width="60px"></asp:TextBox>

                    </td>
                    <td>

                        <asp:CheckBox ID="CheckBox10" runat="server" />
                    </td>
                    <td class="auto-style2">

                        &nbsp;</td>
                    <td>

                        &nbsp;</td>
                    <td>

                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style4">

                        <asp:Label ID="Label31" runat="server" Text="Czujnik trakcji Stanowisko 2"></asp:Label>

                    </td>
                    <td>

                        <asp:DropDownList ID="ddltractionPort2" runat="server">
                                 <asp:ListItem>COM1</asp:ListItem>
                            <asp:ListItem>COM2</asp:ListItem>
                            <asp:ListItem>COM3</asp:ListItem>
                            <asp:ListItem>COM4</asp:ListItem>
                            <asp:ListItem>COM5</asp:ListItem>
                            <asp:ListItem>COM6</asp:ListItem>
                            <asp:ListItem>COM7</asp:ListItem>
                            <asp:ListItem>COM8</asp:ListItem>
                            <asp:ListItem>COM9</asp:ListItem>
                            <asp:ListItem>COM10</asp:ListItem>
                            <asp:ListItem>COM11</asp:ListItem>
                            <asp:ListItem>COM12</asp:ListItem>
                            <asp:ListItem>COM13</asp:ListItem>
                            <asp:ListItem>COM14</asp:ListItem>
                            <asp:ListItem>COM15</asp:ListItem>
                            <asp:ListItem>COM16</asp:ListItem>
                            <asp:ListItem>COM17</asp:ListItem>
                            <asp:ListItem>COM18</asp:ListItem>
                            <asp:ListItem>COM19</asp:ListItem>
                            <asp:ListItem>COM20</asp:ListItem>
                            <asp:ListItem>COM21</asp:ListItem>
                            <asp:ListItem>COM22</asp:ListItem>
                            <asp:ListItem>COM23</asp:ListItem>
                            <asp:ListItem>COM24</asp:ListItem>
                            <asp:ListItem>COM25</asp:ListItem>
                            <asp:ListItem>COM26</asp:ListItem>
                            <asp:ListItem>COM27</asp:ListItem>
                            <asp:ListItem>COM28</asp:ListItem>
                            <asp:ListItem>COM29</asp:ListItem>
                            <asp:ListItem>COM30</asp:ListItem>
                            <asp:ListItem>COM31</asp:ListItem>
                            <asp:ListItem>COM32</asp:ListItem>
                            <asp:ListItem>COM33</asp:ListItem>
                            <asp:ListItem>COM34</asp:ListItem>
                            <asp:ListItem>COM35</asp:ListItem>
                            <asp:ListItem>COM36</asp:ListItem>
                            <asp:ListItem>COM37</asp:ListItem>
                            <asp:ListItem>COM38</asp:ListItem>
                            <asp:ListItem>COM39</asp:ListItem>
                            <asp:ListItem>COM40</asp:ListItem>
                            <asp:ListItem>COM41</asp:ListItem>
                            <asp:ListItem>COM42</asp:ListItem>
                            <asp:ListItem>COM43</asp:ListItem>
                            <asp:ListItem>COM44</asp:ListItem>
                            <asp:ListItem>COM45</asp:ListItem>
                            <asp:ListItem>COM46</asp:ListItem>
                            <asp:ListItem>COM47</asp:ListItem>
                            <asp:ListItem>COM48</asp:ListItem>
                            <asp:ListItem>COM49</asp:ListItem>
                            <asp:ListItem>COM50</asp:ListItem>
                            <asp:ListItem>COM51</asp:ListItem>
                            <asp:ListItem>COM52</asp:ListItem>
                            <asp:ListItem>COM53</asp:ListItem>
                            <asp:ListItem>COM54</asp:ListItem>
                            <asp:ListItem>COM55</asp:ListItem>
                            <asp:ListItem>COM56</asp:ListItem>
                            <asp:ListItem>COM57</asp:ListItem>
                            <asp:ListItem>COM58</asp:ListItem>
                            <asp:ListItem>COM59</asp:ListItem>
                            <asp:ListItem>COM60</asp:ListItem>
                            <asp:ListItem>COM61</asp:ListItem>
                            <asp:ListItem>COM62</asp:ListItem>
                            <asp:ListItem>COM63</asp:ListItem>
                            <asp:ListItem>COM64</asp:ListItem>
                            <asp:ListItem>COM65</asp:ListItem>
                            <asp:ListItem>COM66</asp:ListItem>
                            <asp:ListItem>COM67</asp:ListItem>
                            <asp:ListItem>COM68</asp:ListItem>
                            <asp:ListItem>COM69</asp:ListItem>
                            <asp:ListItem>COM70</asp:ListItem>
                            <asp:ListItem>COM71</asp:ListItem>
                            <asp:ListItem>COM72</asp:ListItem>
                            <asp:ListItem>COM73</asp:ListItem>
                            <asp:ListItem>COM74</asp:ListItem>
                            <asp:ListItem>COM75</asp:ListItem>
                            <asp:ListItem>COM76</asp:ListItem>
                            <asp:ListItem>COM77</asp:ListItem>
                            <asp:ListItem>COM78</asp:ListItem>
                            <asp:ListItem>COM79</asp:ListItem>
                            <asp:ListItem>COM80</asp:ListItem>
                            <asp:ListItem>COM81</asp:ListItem>
                            <asp:ListItem>COM82</asp:ListItem>
                            <asp:ListItem>COM83</asp:ListItem>
                            <asp:ListItem>COM84</asp:ListItem>
                            <asp:ListItem>COM85</asp:ListItem>
                            <asp:ListItem>COM86</asp:ListItem>
                            <asp:ListItem>COM87</asp:ListItem>
                            <asp:ListItem>COM88</asp:ListItem>
                            <asp:ListItem>COM89</asp:ListItem>
                            <asp:ListItem>COM90</asp:ListItem>
                            <asp:ListItem>COM91</asp:ListItem>
                            <asp:ListItem>COM92</asp:ListItem>
                            <asp:ListItem>COM93</asp:ListItem>
                            <asp:ListItem>COM94</asp:ListItem>
                            <asp:ListItem>COM95</asp:ListItem>
                            <asp:ListItem>COM96</asp:ListItem>
                            <asp:ListItem>COM97</asp:ListItem>
                            <asp:ListItem>COM98</asp:ListItem>
                            <asp:ListItem>COM99</asp:ListItem>
                        </asp:DropDownList>

                    </td>
                    <td class="auto-style2">

                        &nbsp;</td>
                    <td>

                        <asp:TextBox ID="txTractionSpeed2" runat="server" TextMode="Number" Width="60px"></asp:TextBox>

                    </td>
                    <td class="auto-style2">

                        &nbsp;</td>
                    <td>

                        <asp:TextBox ID="txTractionDelay2" runat="server" TextMode="Number" Width="60px"></asp:TextBox>

                    </td>
                    <td>

                        <asp:CheckBox ID="CheckBox11" runat="server" />
                    </td>
                    <td class="auto-style2">

                        &nbsp;</td>
                    <td>

                        &nbsp;</td>
                    <td>

                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style4">

                        <asp:Label ID="Label28" runat="server" Text="Czujnik trakcji Stanowisko 3"></asp:Label>

                    </td>
                    <td>

                        <asp:DropDownList ID="ddltractionPort3" runat="server">
                                 <asp:ListItem>COM1</asp:ListItem>
                            <asp:ListItem>COM2</asp:ListItem>
                            <asp:ListItem>COM3</asp:ListItem>
                            <asp:ListItem>COM4</asp:ListItem>
                            <asp:ListItem>COM5</asp:ListItem>
                            <asp:ListItem>COM6</asp:ListItem>
                            <asp:ListItem>COM7</asp:ListItem>
                            <asp:ListItem>COM8</asp:ListItem>
                            <asp:ListItem>COM9</asp:ListItem>
                            <asp:ListItem>COM10</asp:ListItem>
                            <asp:ListItem>COM11</asp:ListItem>
                            <asp:ListItem>COM12</asp:ListItem>
                            <asp:ListItem>COM13</asp:ListItem>
                            <asp:ListItem>COM14</asp:ListItem>
                            <asp:ListItem>COM15</asp:ListItem>
                            <asp:ListItem>COM16</asp:ListItem>
                            <asp:ListItem>COM17</asp:ListItem>
                            <asp:ListItem>COM18</asp:ListItem>
                            <asp:ListItem>COM19</asp:ListItem>
                            <asp:ListItem>COM20</asp:ListItem>
                            <asp:ListItem>COM21</asp:ListItem>
                            <asp:ListItem>COM22</asp:ListItem>
                            <asp:ListItem>COM23</asp:ListItem>
                            <asp:ListItem>COM24</asp:ListItem>
                            <asp:ListItem>COM25</asp:ListItem>
                            <asp:ListItem>COM26</asp:ListItem>
                            <asp:ListItem>COM27</asp:ListItem>
                            <asp:ListItem>COM28</asp:ListItem>
                            <asp:ListItem>COM29</asp:ListItem>
                            <asp:ListItem>COM30</asp:ListItem>
                            <asp:ListItem>COM31</asp:ListItem>
                            <asp:ListItem>COM32</asp:ListItem>
                            <asp:ListItem>COM33</asp:ListItem>
                            <asp:ListItem>COM34</asp:ListItem>
                            <asp:ListItem>COM35</asp:ListItem>
                            <asp:ListItem>COM36</asp:ListItem>
                            <asp:ListItem>COM37</asp:ListItem>
                            <asp:ListItem>COM38</asp:ListItem>
                            <asp:ListItem>COM39</asp:ListItem>
                            <asp:ListItem>COM40</asp:ListItem>
                            <asp:ListItem>COM41</asp:ListItem>
                            <asp:ListItem>COM42</asp:ListItem>
                            <asp:ListItem>COM43</asp:ListItem>
                            <asp:ListItem>COM44</asp:ListItem>
                            <asp:ListItem>COM45</asp:ListItem>
                            <asp:ListItem>COM46</asp:ListItem>
                            <asp:ListItem>COM47</asp:ListItem>
                            <asp:ListItem>COM48</asp:ListItem>
                            <asp:ListItem>COM49</asp:ListItem>
                            <asp:ListItem>COM50</asp:ListItem>
                            <asp:ListItem>COM51</asp:ListItem>
                            <asp:ListItem>COM52</asp:ListItem>
                            <asp:ListItem>COM53</asp:ListItem>
                            <asp:ListItem>COM54</asp:ListItem>
                            <asp:ListItem>COM55</asp:ListItem>
                            <asp:ListItem>COM56</asp:ListItem>
                            <asp:ListItem>COM57</asp:ListItem>
                            <asp:ListItem>COM58</asp:ListItem>
                            <asp:ListItem>COM59</asp:ListItem>
                            <asp:ListItem>COM60</asp:ListItem>
                            <asp:ListItem>COM61</asp:ListItem>
                            <asp:ListItem>COM62</asp:ListItem>
                            <asp:ListItem>COM63</asp:ListItem>
                            <asp:ListItem>COM64</asp:ListItem>
                            <asp:ListItem>COM65</asp:ListItem>
                            <asp:ListItem>COM66</asp:ListItem>
                            <asp:ListItem>COM67</asp:ListItem>
                            <asp:ListItem>COM68</asp:ListItem>
                            <asp:ListItem>COM69</asp:ListItem>
                            <asp:ListItem>COM70</asp:ListItem>
                            <asp:ListItem>COM71</asp:ListItem>
                            <asp:ListItem>COM72</asp:ListItem>
                            <asp:ListItem>COM73</asp:ListItem>
                            <asp:ListItem>COM74</asp:ListItem>
                            <asp:ListItem>COM75</asp:ListItem>
                            <asp:ListItem>COM76</asp:ListItem>
                            <asp:ListItem>COM77</asp:ListItem>
                            <asp:ListItem>COM78</asp:ListItem>
                            <asp:ListItem>COM79</asp:ListItem>
                            <asp:ListItem>COM80</asp:ListItem>
                            <asp:ListItem>COM81</asp:ListItem>
                            <asp:ListItem>COM82</asp:ListItem>
                            <asp:ListItem>COM83</asp:ListItem>
                            <asp:ListItem>COM84</asp:ListItem>
                            <asp:ListItem>COM85</asp:ListItem>
                            <asp:ListItem>COM86</asp:ListItem>
                            <asp:ListItem>COM87</asp:ListItem>
                            <asp:ListItem>COM88</asp:ListItem>
                            <asp:ListItem>COM89</asp:ListItem>
                            <asp:ListItem>COM90</asp:ListItem>
                            <asp:ListItem>COM91</asp:ListItem>
                            <asp:ListItem>COM92</asp:ListItem>
                            <asp:ListItem>COM93</asp:ListItem>
                            <asp:ListItem>COM94</asp:ListItem>
                            <asp:ListItem>COM95</asp:ListItem>
                            <asp:ListItem>COM96</asp:ListItem>
                            <asp:ListItem>COM97</asp:ListItem>
                            <asp:ListItem>COM98</asp:ListItem>
                            <asp:ListItem>COM99</asp:ListItem>
                        </asp:DropDownList>

                    </td>
                    <td class="auto-style2">

                        &nbsp;</td>
                    <td>

                        <asp:TextBox ID="txTractionSpeed3" runat="server" TextMode="Number" Width="60px"></asp:TextBox>

                    </td>
                    <td class="auto-style2">

                        &nbsp;</td>
                    <td>

                        <asp:TextBox ID="txTractionDelay3" runat="server" TextMode="Number" Width="60px"></asp:TextBox>

                    </td>
                    <td>

                        <asp:CheckBox ID="CheckBox12" runat="server" />
                    </td>
                    <td class="auto-style2">

                        &nbsp;</td>
                    <td>

                        &nbsp;</td>
                    <td>

                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style4">

                        <asp:Label ID="Label29" runat="server" Text="Czujnik trakcji Stanowisko 4"></asp:Label>

                    </td>
                    <td>

                        <asp:DropDownList ID="ddltractionPort4" runat="server">
                                 <asp:ListItem>COM1</asp:ListItem>
                            <asp:ListItem>COM2</asp:ListItem>
                            <asp:ListItem>COM3</asp:ListItem>
                            <asp:ListItem>COM4</asp:ListItem>
                            <asp:ListItem>COM5</asp:ListItem>
                            <asp:ListItem>COM6</asp:ListItem>
                            <asp:ListItem>COM7</asp:ListItem>
                            <asp:ListItem>COM8</asp:ListItem>
                            <asp:ListItem>COM9</asp:ListItem>
                            <asp:ListItem>COM10</asp:ListItem>
                            <asp:ListItem>COM11</asp:ListItem>
                            <asp:ListItem>COM12</asp:ListItem>
                            <asp:ListItem>COM13</asp:ListItem>
                            <asp:ListItem>COM14</asp:ListItem>
                            <asp:ListItem>COM15</asp:ListItem>
                            <asp:ListItem>COM16</asp:ListItem>
                            <asp:ListItem>COM17</asp:ListItem>
                            <asp:ListItem>COM18</asp:ListItem>
                            <asp:ListItem>COM19</asp:ListItem>
                            <asp:ListItem>COM20</asp:ListItem>
                            <asp:ListItem>COM21</asp:ListItem>
                            <asp:ListItem>COM22</asp:ListItem>
                            <asp:ListItem>COM23</asp:ListItem>
                            <asp:ListItem>COM24</asp:ListItem>
                            <asp:ListItem>COM25</asp:ListItem>
                            <asp:ListItem>COM26</asp:ListItem>
                            <asp:ListItem>COM27</asp:ListItem>
                            <asp:ListItem>COM28</asp:ListItem>
                            <asp:ListItem>COM29</asp:ListItem>
                            <asp:ListItem>COM30</asp:ListItem>
                            <asp:ListItem>COM31</asp:ListItem>
                            <asp:ListItem>COM32</asp:ListItem>
                            <asp:ListItem>COM33</asp:ListItem>
                            <asp:ListItem>COM34</asp:ListItem>
                            <asp:ListItem>COM35</asp:ListItem>
                            <asp:ListItem>COM36</asp:ListItem>
                            <asp:ListItem>COM37</asp:ListItem>
                            <asp:ListItem>COM38</asp:ListItem>
                            <asp:ListItem>COM39</asp:ListItem>
                            <asp:ListItem>COM40</asp:ListItem>
                            <asp:ListItem>COM41</asp:ListItem>
                            <asp:ListItem>COM42</asp:ListItem>
                            <asp:ListItem>COM43</asp:ListItem>
                            <asp:ListItem>COM44</asp:ListItem>
                            <asp:ListItem>COM45</asp:ListItem>
                            <asp:ListItem>COM46</asp:ListItem>
                            <asp:ListItem>COM47</asp:ListItem>
                            <asp:ListItem>COM48</asp:ListItem>
                            <asp:ListItem>COM49</asp:ListItem>
                            <asp:ListItem>COM50</asp:ListItem>
                            <asp:ListItem>COM51</asp:ListItem>
                            <asp:ListItem>COM52</asp:ListItem>
                            <asp:ListItem>COM53</asp:ListItem>
                            <asp:ListItem>COM54</asp:ListItem>
                            <asp:ListItem>COM55</asp:ListItem>
                            <asp:ListItem>COM56</asp:ListItem>
                            <asp:ListItem>COM57</asp:ListItem>
                            <asp:ListItem>COM58</asp:ListItem>
                            <asp:ListItem>COM59</asp:ListItem>
                            <asp:ListItem>COM60</asp:ListItem>
                            <asp:ListItem>COM61</asp:ListItem>
                            <asp:ListItem>COM62</asp:ListItem>
                            <asp:ListItem>COM63</asp:ListItem>
                            <asp:ListItem>COM64</asp:ListItem>
                            <asp:ListItem>COM65</asp:ListItem>
                            <asp:ListItem>COM66</asp:ListItem>
                            <asp:ListItem>COM67</asp:ListItem>
                            <asp:ListItem>COM68</asp:ListItem>
                            <asp:ListItem>COM69</asp:ListItem>
                            <asp:ListItem>COM70</asp:ListItem>
                            <asp:ListItem>COM71</asp:ListItem>
                            <asp:ListItem>COM72</asp:ListItem>
                            <asp:ListItem>COM73</asp:ListItem>
                            <asp:ListItem>COM74</asp:ListItem>
                            <asp:ListItem>COM75</asp:ListItem>
                            <asp:ListItem>COM76</asp:ListItem>
                            <asp:ListItem>COM77</asp:ListItem>
                            <asp:ListItem>COM78</asp:ListItem>
                            <asp:ListItem>COM79</asp:ListItem>
                            <asp:ListItem>COM80</asp:ListItem>
                            <asp:ListItem>COM81</asp:ListItem>
                            <asp:ListItem>COM82</asp:ListItem>
                            <asp:ListItem>COM83</asp:ListItem>
                            <asp:ListItem>COM84</asp:ListItem>
                            <asp:ListItem>COM85</asp:ListItem>
                            <asp:ListItem>COM86</asp:ListItem>
                            <asp:ListItem>COM87</asp:ListItem>
                            <asp:ListItem>COM88</asp:ListItem>
                            <asp:ListItem>COM89</asp:ListItem>
                            <asp:ListItem>COM90</asp:ListItem>
                            <asp:ListItem>COM91</asp:ListItem>
                            <asp:ListItem>COM92</asp:ListItem>
                            <asp:ListItem>COM93</asp:ListItem>
                            <asp:ListItem>COM94</asp:ListItem>
                            <asp:ListItem>COM95</asp:ListItem>
                            <asp:ListItem>COM96</asp:ListItem>
                            <asp:ListItem>COM97</asp:ListItem>
                            <asp:ListItem>COM98</asp:ListItem>
                            <asp:ListItem>COM99</asp:ListItem>
                        </asp:DropDownList>

                    </td>
                    <td class="auto-style2">

                        &nbsp;</td>
                    <td>

                        <asp:TextBox ID="txTractionSpeed4" runat="server" TextMode="Number" Width="60px"></asp:TextBox>

                    </td>
                    <td class="auto-style2">

                        &nbsp;</td>
                    <td>

                        <asp:TextBox ID="txTractionDelay4" runat="server" TextMode="Number" Width="60px"></asp:TextBox>

                    </td>
                    <td>

                        <asp:CheckBox ID="CheckBox13" runat="server" />
                    </td>
                    <td class="auto-style2">

                        &nbsp;</td>
                    <td>

                        &nbsp;</td>
                    <td>

                        &nbsp;</td>
                </tr>
                                <tr>
                    <td class="auto-style4">

                        <asp:Label ID="Label30" runat="server" Text="Czujnik trakcji Stanowisko 5"></asp:Label>

                                    </td>
                    <td>

                        <asp:DropDownList ID="ddltractionPort5" runat="server">
                                 <asp:ListItem>COM1</asp:ListItem>
                            <asp:ListItem>COM2</asp:ListItem>
                            <asp:ListItem>COM3</asp:ListItem>
                            <asp:ListItem>COM4</asp:ListItem>
                            <asp:ListItem>COM5</asp:ListItem>
                            <asp:ListItem>COM6</asp:ListItem>
                            <asp:ListItem>COM7</asp:ListItem>
                            <asp:ListItem>COM8</asp:ListItem>
                            <asp:ListItem>COM9</asp:ListItem>
                            <asp:ListItem>COM10</asp:ListItem>
                            <asp:ListItem>COM11</asp:ListItem>
                            <asp:ListItem>COM12</asp:ListItem>
                            <asp:ListItem>COM13</asp:ListItem>
                            <asp:ListItem>COM14</asp:ListItem>
                            <asp:ListItem>COM15</asp:ListItem>
                            <asp:ListItem>COM16</asp:ListItem>
                            <asp:ListItem>COM17</asp:ListItem>
                            <asp:ListItem>COM18</asp:ListItem>
                            <asp:ListItem>COM19</asp:ListItem>
                            <asp:ListItem>COM20</asp:ListItem>
                            <asp:ListItem>COM21</asp:ListItem>
                            <asp:ListItem>COM22</asp:ListItem>
                            <asp:ListItem>COM23</asp:ListItem>
                            <asp:ListItem>COM24</asp:ListItem>
                            <asp:ListItem>COM25</asp:ListItem>
                            <asp:ListItem>COM26</asp:ListItem>
                            <asp:ListItem>COM27</asp:ListItem>
                            <asp:ListItem>COM28</asp:ListItem>
                            <asp:ListItem>COM29</asp:ListItem>
                            <asp:ListItem>COM30</asp:ListItem>
                            <asp:ListItem>COM31</asp:ListItem>
                            <asp:ListItem>COM32</asp:ListItem>
                            <asp:ListItem>COM33</asp:ListItem>
                            <asp:ListItem>COM34</asp:ListItem>
                            <asp:ListItem>COM35</asp:ListItem>
                            <asp:ListItem>COM36</asp:ListItem>
                            <asp:ListItem>COM37</asp:ListItem>
                            <asp:ListItem>COM38</asp:ListItem>
                            <asp:ListItem>COM39</asp:ListItem>
                            <asp:ListItem>COM40</asp:ListItem>
                            <asp:ListItem>COM41</asp:ListItem>
                            <asp:ListItem>COM42</asp:ListItem>
                            <asp:ListItem>COM43</asp:ListItem>
                            <asp:ListItem>COM44</asp:ListItem>
                            <asp:ListItem>COM45</asp:ListItem>
                            <asp:ListItem>COM46</asp:ListItem>
                            <asp:ListItem>COM47</asp:ListItem>
                            <asp:ListItem>COM48</asp:ListItem>
                            <asp:ListItem>COM49</asp:ListItem>
                            <asp:ListItem>COM50</asp:ListItem>
                            <asp:ListItem>COM51</asp:ListItem>
                            <asp:ListItem>COM52</asp:ListItem>
                            <asp:ListItem>COM53</asp:ListItem>
                            <asp:ListItem>COM54</asp:ListItem>
                            <asp:ListItem>COM55</asp:ListItem>
                            <asp:ListItem>COM56</asp:ListItem>
                            <asp:ListItem>COM57</asp:ListItem>
                            <asp:ListItem>COM58</asp:ListItem>
                            <asp:ListItem>COM59</asp:ListItem>
                            <asp:ListItem>COM60</asp:ListItem>
                            <asp:ListItem>COM61</asp:ListItem>
                            <asp:ListItem>COM62</asp:ListItem>
                            <asp:ListItem>COM63</asp:ListItem>
                            <asp:ListItem>COM64</asp:ListItem>
                            <asp:ListItem>COM65</asp:ListItem>
                            <asp:ListItem>COM66</asp:ListItem>
                            <asp:ListItem>COM67</asp:ListItem>
                            <asp:ListItem>COM68</asp:ListItem>
                            <asp:ListItem>COM69</asp:ListItem>
                            <asp:ListItem>COM70</asp:ListItem>
                            <asp:ListItem>COM71</asp:ListItem>
                            <asp:ListItem>COM72</asp:ListItem>
                            <asp:ListItem>COM73</asp:ListItem>
                            <asp:ListItem>COM74</asp:ListItem>
                            <asp:ListItem>COM75</asp:ListItem>
                            <asp:ListItem>COM76</asp:ListItem>
                            <asp:ListItem>COM77</asp:ListItem>
                            <asp:ListItem>COM78</asp:ListItem>
                            <asp:ListItem>COM79</asp:ListItem>
                            <asp:ListItem>COM80</asp:ListItem>
                            <asp:ListItem>COM81</asp:ListItem>
                            <asp:ListItem>COM82</asp:ListItem>
                            <asp:ListItem>COM83</asp:ListItem>
                            <asp:ListItem>COM84</asp:ListItem>
                            <asp:ListItem>COM85</asp:ListItem>
                            <asp:ListItem>COM86</asp:ListItem>
                            <asp:ListItem>COM87</asp:ListItem>
                            <asp:ListItem>COM88</asp:ListItem>
                            <asp:ListItem>COM89</asp:ListItem>
                            <asp:ListItem>COM90</asp:ListItem>
                            <asp:ListItem>COM91</asp:ListItem>
                            <asp:ListItem>COM92</asp:ListItem>
                            <asp:ListItem>COM93</asp:ListItem>
                            <asp:ListItem>COM94</asp:ListItem>
                            <asp:ListItem>COM95</asp:ListItem>
                            <asp:ListItem>COM96</asp:ListItem>
                            <asp:ListItem>COM97</asp:ListItem>
                            <asp:ListItem>COM98</asp:ListItem>
                            <asp:ListItem>COM99</asp:ListItem>
                        </asp:DropDownList>

                                    </td>
                    <td class="auto-style2">

                        &nbsp;</td>
                    <td>

                        <asp:TextBox ID="txTractionSpeed5" runat="server" TextMode="Number" Width="60px"></asp:TextBox>

                                    </td>
                    <td class="auto-style2">

                        &nbsp;</td>
                    <td>

                        <asp:TextBox ID="txTractionDelay5" runat="server" TextMode="Number" Width="60px"></asp:TextBox>

                                    </td>
                    <td>

                        <asp:CheckBox ID="CheckBox14" runat="server" />
                                    </td>
                    <td class="auto-style2">

                        &nbsp;</td>
                    <td>

                        &nbsp;</td>
                    <td>

                        &nbsp;</td>
                </tr>
                                <tr>
                    <td class="auto-style4">

                        <asp:Label ID="Label32" runat="server" Text="Czujnik trakcji Stanowisko 6"></asp:Label>

                                    </td>
                    <td>

                        <asp:DropDownList ID="ddltractionPort6" runat="server">
                                 <asp:ListItem>COM1</asp:ListItem>
                            <asp:ListItem>COM2</asp:ListItem>
                            <asp:ListItem>COM3</asp:ListItem>
                            <asp:ListItem>COM4</asp:ListItem>
                            <asp:ListItem>COM5</asp:ListItem>
                            <asp:ListItem>COM6</asp:ListItem>
                            <asp:ListItem>COM7</asp:ListItem>
                            <asp:ListItem>COM8</asp:ListItem>
                            <asp:ListItem>COM9</asp:ListItem>
                            <asp:ListItem>COM10</asp:ListItem>
                            <asp:ListItem>COM11</asp:ListItem>
                            <asp:ListItem>COM12</asp:ListItem>
                            <asp:ListItem>COM13</asp:ListItem>
                            <asp:ListItem>COM14</asp:ListItem>
                            <asp:ListItem>COM15</asp:ListItem>
                            <asp:ListItem>COM16</asp:ListItem>
                            <asp:ListItem>COM17</asp:ListItem>
                            <asp:ListItem>COM18</asp:ListItem>
                            <asp:ListItem>COM19</asp:ListItem>
                            <asp:ListItem>COM20</asp:ListItem>
                            <asp:ListItem>COM21</asp:ListItem>
                            <asp:ListItem>COM22</asp:ListItem>
                            <asp:ListItem>COM23</asp:ListItem>
                            <asp:ListItem>COM24</asp:ListItem>
                            <asp:ListItem>COM25</asp:ListItem>
                            <asp:ListItem>COM26</asp:ListItem>
                            <asp:ListItem>COM27</asp:ListItem>
                            <asp:ListItem>COM28</asp:ListItem>
                            <asp:ListItem>COM29</asp:ListItem>
                            <asp:ListItem>COM30</asp:ListItem>
                            <asp:ListItem>COM31</asp:ListItem>
                            <asp:ListItem>COM32</asp:ListItem>
                            <asp:ListItem>COM33</asp:ListItem>
                            <asp:ListItem>COM34</asp:ListItem>
                            <asp:ListItem>COM35</asp:ListItem>
                            <asp:ListItem>COM36</asp:ListItem>
                            <asp:ListItem>COM37</asp:ListItem>
                            <asp:ListItem>COM38</asp:ListItem>
                            <asp:ListItem>COM39</asp:ListItem>
                            <asp:ListItem>COM40</asp:ListItem>
                            <asp:ListItem>COM41</asp:ListItem>
                            <asp:ListItem>COM42</asp:ListItem>
                            <asp:ListItem>COM43</asp:ListItem>
                            <asp:ListItem>COM44</asp:ListItem>
                            <asp:ListItem>COM45</asp:ListItem>
                            <asp:ListItem>COM46</asp:ListItem>
                            <asp:ListItem>COM47</asp:ListItem>
                            <asp:ListItem>COM48</asp:ListItem>
                            <asp:ListItem>COM49</asp:ListItem>
                            <asp:ListItem>COM50</asp:ListItem>
                            <asp:ListItem>COM51</asp:ListItem>
                            <asp:ListItem>COM52</asp:ListItem>
                            <asp:ListItem>COM53</asp:ListItem>
                            <asp:ListItem>COM54</asp:ListItem>
                            <asp:ListItem>COM55</asp:ListItem>
                            <asp:ListItem>COM56</asp:ListItem>
                            <asp:ListItem>COM57</asp:ListItem>
                            <asp:ListItem>COM58</asp:ListItem>
                            <asp:ListItem>COM59</asp:ListItem>
                            <asp:ListItem>COM60</asp:ListItem>
                            <asp:ListItem>COM61</asp:ListItem>
                            <asp:ListItem>COM62</asp:ListItem>
                            <asp:ListItem>COM63</asp:ListItem>
                            <asp:ListItem>COM64</asp:ListItem>
                            <asp:ListItem>COM65</asp:ListItem>
                            <asp:ListItem>COM66</asp:ListItem>
                            <asp:ListItem>COM67</asp:ListItem>
                            <asp:ListItem>COM68</asp:ListItem>
                            <asp:ListItem>COM69</asp:ListItem>
                            <asp:ListItem>COM70</asp:ListItem>
                            <asp:ListItem>COM71</asp:ListItem>
                            <asp:ListItem>COM72</asp:ListItem>
                            <asp:ListItem>COM73</asp:ListItem>
                            <asp:ListItem>COM74</asp:ListItem>
                            <asp:ListItem>COM75</asp:ListItem>
                            <asp:ListItem>COM76</asp:ListItem>
                            <asp:ListItem>COM77</asp:ListItem>
                            <asp:ListItem>COM78</asp:ListItem>
                            <asp:ListItem>COM79</asp:ListItem>
                            <asp:ListItem>COM80</asp:ListItem>
                            <asp:ListItem>COM81</asp:ListItem>
                            <asp:ListItem>COM82</asp:ListItem>
                            <asp:ListItem>COM83</asp:ListItem>
                            <asp:ListItem>COM84</asp:ListItem>
                            <asp:ListItem>COM85</asp:ListItem>
                            <asp:ListItem>COM86</asp:ListItem>
                            <asp:ListItem>COM87</asp:ListItem>
                            <asp:ListItem>COM88</asp:ListItem>
                            <asp:ListItem>COM89</asp:ListItem>
                            <asp:ListItem>COM90</asp:ListItem>
                            <asp:ListItem>COM91</asp:ListItem>
                            <asp:ListItem>COM92</asp:ListItem>
                            <asp:ListItem>COM93</asp:ListItem>
                            <asp:ListItem>COM94</asp:ListItem>
                            <asp:ListItem>COM95</asp:ListItem>
                            <asp:ListItem>COM96</asp:ListItem>
                            <asp:ListItem>COM97</asp:ListItem>
                            <asp:ListItem>COM98</asp:ListItem>
                            <asp:ListItem>COM99</asp:ListItem>
                        </asp:DropDownList>

                                    </td>
                    <td class="auto-style2">

                        &nbsp;</td>
                    <td>

                        <asp:TextBox ID="txTractionSpeed6" runat="server" TextMode="Number" Width="60px"></asp:TextBox>

                                    </td>
                    <td class="auto-style2">

                        &nbsp;</td>
                    <td>

                        <asp:TextBox ID="txTractionDelay6" runat="server" TextMode="Number" Width="60px"></asp:TextBox>

                                    </td>
                    <td>

                        <asp:CheckBox ID="CheckBox15" runat="server" />
                                    </td>
                    <td class="auto-style2">

                        &nbsp;</td>
                    <td>

                        &nbsp;</td>
                    <td>

                        &nbsp;</td>
                </tr>
                                <tr>
                    <td class="auto-style4">

                        <asp:Label ID="Label33" runat="server" Text="Czujnik trakcji Stanowisko 7"></asp:Label>

                                    </td>
                    <td>

                        <asp:DropDownList ID="ddltractionPort7" runat="server">
                                 <asp:ListItem>COM1</asp:ListItem>
                            <asp:ListItem>COM2</asp:ListItem>
                            <asp:ListItem>COM3</asp:ListItem>
                            <asp:ListItem>COM4</asp:ListItem>
                            <asp:ListItem>COM5</asp:ListItem>
                            <asp:ListItem>COM6</asp:ListItem>
                            <asp:ListItem>COM7</asp:ListItem>
                            <asp:ListItem>COM8</asp:ListItem>
                            <asp:ListItem>COM9</asp:ListItem>
                            <asp:ListItem>COM10</asp:ListItem>
                            <asp:ListItem>COM11</asp:ListItem>
                            <asp:ListItem>COM12</asp:ListItem>
                            <asp:ListItem>COM13</asp:ListItem>
                            <asp:ListItem>COM14</asp:ListItem>
                            <asp:ListItem>COM15</asp:ListItem>
                            <asp:ListItem>COM16</asp:ListItem>
                            <asp:ListItem>COM17</asp:ListItem>
                            <asp:ListItem>COM18</asp:ListItem>
                            <asp:ListItem>COM19</asp:ListItem>
                            <asp:ListItem>COM20</asp:ListItem>
                            <asp:ListItem>COM21</asp:ListItem>
                            <asp:ListItem>COM22</asp:ListItem>
                            <asp:ListItem>COM23</asp:ListItem>
                            <asp:ListItem>COM24</asp:ListItem>
                            <asp:ListItem>COM25</asp:ListItem>
                            <asp:ListItem>COM26</asp:ListItem>
                            <asp:ListItem>COM27</asp:ListItem>
                            <asp:ListItem>COM28</asp:ListItem>
                            <asp:ListItem>COM29</asp:ListItem>
                            <asp:ListItem>COM30</asp:ListItem>
                            <asp:ListItem>COM31</asp:ListItem>
                            <asp:ListItem>COM32</asp:ListItem>
                            <asp:ListItem>COM33</asp:ListItem>
                            <asp:ListItem>COM34</asp:ListItem>
                            <asp:ListItem>COM35</asp:ListItem>
                            <asp:ListItem>COM36</asp:ListItem>
                            <asp:ListItem>COM37</asp:ListItem>
                            <asp:ListItem>COM38</asp:ListItem>
                            <asp:ListItem>COM39</asp:ListItem>
                            <asp:ListItem>COM40</asp:ListItem>
                            <asp:ListItem>COM41</asp:ListItem>
                            <asp:ListItem>COM42</asp:ListItem>
                            <asp:ListItem>COM43</asp:ListItem>
                            <asp:ListItem>COM44</asp:ListItem>
                            <asp:ListItem>COM45</asp:ListItem>
                            <asp:ListItem>COM46</asp:ListItem>
                            <asp:ListItem>COM47</asp:ListItem>
                            <asp:ListItem>COM48</asp:ListItem>
                            <asp:ListItem>COM49</asp:ListItem>
                            <asp:ListItem>COM50</asp:ListItem>
                            <asp:ListItem>COM51</asp:ListItem>
                            <asp:ListItem>COM52</asp:ListItem>
                            <asp:ListItem>COM53</asp:ListItem>
                            <asp:ListItem>COM54</asp:ListItem>
                            <asp:ListItem>COM55</asp:ListItem>
                            <asp:ListItem>COM56</asp:ListItem>
                            <asp:ListItem>COM57</asp:ListItem>
                            <asp:ListItem>COM58</asp:ListItem>
                            <asp:ListItem>COM59</asp:ListItem>
                            <asp:ListItem>COM60</asp:ListItem>
                            <asp:ListItem>COM61</asp:ListItem>
                            <asp:ListItem>COM62</asp:ListItem>
                            <asp:ListItem>COM63</asp:ListItem>
                            <asp:ListItem>COM64</asp:ListItem>
                            <asp:ListItem>COM65</asp:ListItem>
                            <asp:ListItem>COM66</asp:ListItem>
                            <asp:ListItem>COM67</asp:ListItem>
                            <asp:ListItem>COM68</asp:ListItem>
                            <asp:ListItem>COM69</asp:ListItem>
                            <asp:ListItem>COM70</asp:ListItem>
                            <asp:ListItem>COM71</asp:ListItem>
                            <asp:ListItem>COM72</asp:ListItem>
                            <asp:ListItem>COM73</asp:ListItem>
                            <asp:ListItem>COM74</asp:ListItem>
                            <asp:ListItem>COM75</asp:ListItem>
                            <asp:ListItem>COM76</asp:ListItem>
                            <asp:ListItem>COM77</asp:ListItem>
                            <asp:ListItem>COM78</asp:ListItem>
                            <asp:ListItem>COM79</asp:ListItem>
                            <asp:ListItem>COM80</asp:ListItem>
                            <asp:ListItem>COM81</asp:ListItem>
                            <asp:ListItem>COM82</asp:ListItem>
                            <asp:ListItem>COM83</asp:ListItem>
                            <asp:ListItem>COM84</asp:ListItem>
                            <asp:ListItem>COM85</asp:ListItem>
                            <asp:ListItem>COM86</asp:ListItem>
                            <asp:ListItem>COM87</asp:ListItem>
                            <asp:ListItem>COM88</asp:ListItem>
                            <asp:ListItem>COM89</asp:ListItem>
                            <asp:ListItem>COM90</asp:ListItem>
                            <asp:ListItem>COM91</asp:ListItem>
                            <asp:ListItem>COM92</asp:ListItem>
                            <asp:ListItem>COM93</asp:ListItem>
                            <asp:ListItem>COM94</asp:ListItem>
                            <asp:ListItem>COM95</asp:ListItem>
                            <asp:ListItem>COM96</asp:ListItem>
                            <asp:ListItem>COM97</asp:ListItem>
                            <asp:ListItem>COM98</asp:ListItem>
                            <asp:ListItem>COM99</asp:ListItem>
                        </asp:DropDownList>

                                    </td>
                    <td class="auto-style2">

                        &nbsp;</td>
                    <td>

                        <asp:TextBox ID="txTractionSpeed7" runat="server" TextMode="Number" Width="60px"></asp:TextBox>

                                    </td>
                    <td class="auto-style2">

                        &nbsp;</td>
                    <td>

                        <asp:TextBox ID="txTractionDelay7" runat="server" TextMode="Number" Width="60px"></asp:TextBox>

                                    </td>
                    <td>

                        <asp:CheckBox ID="CheckBox16" runat="server" />
                                    </td>
                    <td class="auto-style2">

                        &nbsp;</td>
                    <td>

                        &nbsp;</td>
                    <td>

                        &nbsp;</td>
                </tr>
                                <tr>
                    <td class="auto-style4">

                        <asp:Label ID="Label34" runat="server" Text="Czujnik trakcji Stanowisko 8"></asp:Label>

                                    </td>
                    <td>

                        <asp:DropDownList ID="ddltractionPort8" runat="server">
                                 <asp:ListItem>COM1</asp:ListItem>
                            <asp:ListItem>COM2</asp:ListItem>
                            <asp:ListItem>COM3</asp:ListItem>
                            <asp:ListItem>COM4</asp:ListItem>
                            <asp:ListItem>COM5</asp:ListItem>
                            <asp:ListItem>COM6</asp:ListItem>
                            <asp:ListItem>COM7</asp:ListItem>
                            <asp:ListItem>COM8</asp:ListItem>
                            <asp:ListItem>COM9</asp:ListItem>
                            <asp:ListItem>COM10</asp:ListItem>
                            <asp:ListItem>COM11</asp:ListItem>
                            <asp:ListItem>COM12</asp:ListItem>
                            <asp:ListItem>COM13</asp:ListItem>
                            <asp:ListItem>COM14</asp:ListItem>
                            <asp:ListItem>COM15</asp:ListItem>
                            <asp:ListItem>COM16</asp:ListItem>
                            <asp:ListItem>COM17</asp:ListItem>
                            <asp:ListItem>COM18</asp:ListItem>
                            <asp:ListItem>COM19</asp:ListItem>
                            <asp:ListItem>COM20</asp:ListItem>
                            <asp:ListItem>COM21</asp:ListItem>
                            <asp:ListItem>COM22</asp:ListItem>
                            <asp:ListItem>COM23</asp:ListItem>
                            <asp:ListItem>COM24</asp:ListItem>
                            <asp:ListItem>COM25</asp:ListItem>
                            <asp:ListItem>COM26</asp:ListItem>
                            <asp:ListItem>COM27</asp:ListItem>
                            <asp:ListItem>COM28</asp:ListItem>
                            <asp:ListItem>COM29</asp:ListItem>
                            <asp:ListItem>COM30</asp:ListItem>
                            <asp:ListItem>COM31</asp:ListItem>
                            <asp:ListItem>COM32</asp:ListItem>
                            <asp:ListItem>COM33</asp:ListItem>
                            <asp:ListItem>COM34</asp:ListItem>
                            <asp:ListItem>COM35</asp:ListItem>
                            <asp:ListItem>COM36</asp:ListItem>
                            <asp:ListItem>COM37</asp:ListItem>
                            <asp:ListItem>COM38</asp:ListItem>
                            <asp:ListItem>COM39</asp:ListItem>
                            <asp:ListItem>COM40</asp:ListItem>
                            <asp:ListItem>COM41</asp:ListItem>
                            <asp:ListItem>COM42</asp:ListItem>
                            <asp:ListItem>COM43</asp:ListItem>
                            <asp:ListItem>COM44</asp:ListItem>
                            <asp:ListItem>COM45</asp:ListItem>
                            <asp:ListItem>COM46</asp:ListItem>
                            <asp:ListItem>COM47</asp:ListItem>
                            <asp:ListItem>COM48</asp:ListItem>
                            <asp:ListItem>COM49</asp:ListItem>
                            <asp:ListItem>COM50</asp:ListItem>
                            <asp:ListItem>COM51</asp:ListItem>
                            <asp:ListItem>COM52</asp:ListItem>
                            <asp:ListItem>COM53</asp:ListItem>
                            <asp:ListItem>COM54</asp:ListItem>
                            <asp:ListItem>COM55</asp:ListItem>
                            <asp:ListItem>COM56</asp:ListItem>
                            <asp:ListItem>COM57</asp:ListItem>
                            <asp:ListItem>COM58</asp:ListItem>
                            <asp:ListItem>COM59</asp:ListItem>
                            <asp:ListItem>COM60</asp:ListItem>
                            <asp:ListItem>COM61</asp:ListItem>
                            <asp:ListItem>COM62</asp:ListItem>
                            <asp:ListItem>COM63</asp:ListItem>
                            <asp:ListItem>COM64</asp:ListItem>
                            <asp:ListItem>COM65</asp:ListItem>
                            <asp:ListItem>COM66</asp:ListItem>
                            <asp:ListItem>COM67</asp:ListItem>
                            <asp:ListItem>COM68</asp:ListItem>
                            <asp:ListItem>COM69</asp:ListItem>
                            <asp:ListItem>COM70</asp:ListItem>
                            <asp:ListItem>COM71</asp:ListItem>
                            <asp:ListItem>COM72</asp:ListItem>
                            <asp:ListItem>COM73</asp:ListItem>
                            <asp:ListItem>COM74</asp:ListItem>
                            <asp:ListItem>COM75</asp:ListItem>
                            <asp:ListItem>COM76</asp:ListItem>
                            <asp:ListItem>COM77</asp:ListItem>
                            <asp:ListItem>COM78</asp:ListItem>
                            <asp:ListItem>COM79</asp:ListItem>
                            <asp:ListItem>COM80</asp:ListItem>
                            <asp:ListItem>COM81</asp:ListItem>
                            <asp:ListItem>COM82</asp:ListItem>
                            <asp:ListItem>COM83</asp:ListItem>
                            <asp:ListItem>COM84</asp:ListItem>
                            <asp:ListItem>COM85</asp:ListItem>
                            <asp:ListItem>COM86</asp:ListItem>
                            <asp:ListItem>COM87</asp:ListItem>
                            <asp:ListItem>COM88</asp:ListItem>
                            <asp:ListItem>COM89</asp:ListItem>
                            <asp:ListItem>COM90</asp:ListItem>
                            <asp:ListItem>COM91</asp:ListItem>
                            <asp:ListItem>COM92</asp:ListItem>
                            <asp:ListItem>COM93</asp:ListItem>
                            <asp:ListItem>COM94</asp:ListItem>
                            <asp:ListItem>COM95</asp:ListItem>
                            <asp:ListItem>COM96</asp:ListItem>
                            <asp:ListItem>COM97</asp:ListItem>
                            <asp:ListItem>COM98</asp:ListItem>
                            <asp:ListItem>COM99</asp:ListItem>
                        </asp:DropDownList>

                                    </td>
                    <td class="auto-style2">

                        &nbsp;</td>
                    <td>

                        <asp:TextBox ID="txTractionSpeed8" runat="server" TextMode="Number" Width="60px"></asp:TextBox>

                                    </td>
                    <td class="auto-style2">

                        &nbsp;</td>
                    <td>

                        <asp:TextBox ID="txTractionDelay8" runat="server" TextMode="Number" Width="60px"></asp:TextBox>

                                    </td>
                    <td>

                        <asp:CheckBox ID="CheckBox17" runat="server" />
                                    </td>
                    <td class="auto-style2">

                        &nbsp;</td>
                    <td>

                        &nbsp;</td>
                    <td>

                        &nbsp;</td>
                </tr>
                                <tr>
                    <td class="auto-style4">

                        <asp:Label ID="Label35" runat="server" Text="Czujnik trakcji Stanowisko 9"></asp:Label>

                                    </td>
                    <td>

                        <asp:DropDownList ID="ddltractionPort9" runat="server">
                                 <asp:ListItem>COM1</asp:ListItem>
                            <asp:ListItem>COM2</asp:ListItem>
                            <asp:ListItem>COM3</asp:ListItem>
                            <asp:ListItem>COM4</asp:ListItem>
                            <asp:ListItem>COM5</asp:ListItem>
                            <asp:ListItem>COM6</asp:ListItem>
                            <asp:ListItem>COM7</asp:ListItem>
                            <asp:ListItem>COM8</asp:ListItem>
                            <asp:ListItem>COM9</asp:ListItem>
                            <asp:ListItem>COM10</asp:ListItem>
                            <asp:ListItem>COM11</asp:ListItem>
                            <asp:ListItem>COM12</asp:ListItem>
                            <asp:ListItem>COM13</asp:ListItem>
                            <asp:ListItem>COM14</asp:ListItem>
                            <asp:ListItem>COM15</asp:ListItem>
                            <asp:ListItem>COM16</asp:ListItem>
                            <asp:ListItem>COM17</asp:ListItem>
                            <asp:ListItem>COM18</asp:ListItem>
                            <asp:ListItem>COM19</asp:ListItem>
                            <asp:ListItem>COM20</asp:ListItem>
                            <asp:ListItem>COM21</asp:ListItem>
                            <asp:ListItem>COM22</asp:ListItem>
                            <asp:ListItem>COM23</asp:ListItem>
                            <asp:ListItem>COM24</asp:ListItem>
                            <asp:ListItem>COM25</asp:ListItem>
                            <asp:ListItem>COM26</asp:ListItem>
                            <asp:ListItem>COM27</asp:ListItem>
                            <asp:ListItem>COM28</asp:ListItem>
                            <asp:ListItem>COM29</asp:ListItem>
                            <asp:ListItem>COM30</asp:ListItem>
                            <asp:ListItem>COM31</asp:ListItem>
                            <asp:ListItem>COM32</asp:ListItem>
                            <asp:ListItem>COM33</asp:ListItem>
                            <asp:ListItem>COM34</asp:ListItem>
                            <asp:ListItem>COM35</asp:ListItem>
                            <asp:ListItem>COM36</asp:ListItem>
                            <asp:ListItem>COM37</asp:ListItem>
                            <asp:ListItem>COM38</asp:ListItem>
                            <asp:ListItem>COM39</asp:ListItem>
                            <asp:ListItem>COM40</asp:ListItem>
                            <asp:ListItem>COM41</asp:ListItem>
                            <asp:ListItem>COM42</asp:ListItem>
                            <asp:ListItem>COM43</asp:ListItem>
                            <asp:ListItem>COM44</asp:ListItem>
                            <asp:ListItem>COM45</asp:ListItem>
                            <asp:ListItem>COM46</asp:ListItem>
                            <asp:ListItem>COM47</asp:ListItem>
                            <asp:ListItem>COM48</asp:ListItem>
                            <asp:ListItem>COM49</asp:ListItem>
                            <asp:ListItem>COM50</asp:ListItem>
                            <asp:ListItem>COM51</asp:ListItem>
                            <asp:ListItem>COM52</asp:ListItem>
                            <asp:ListItem>COM53</asp:ListItem>
                            <asp:ListItem>COM54</asp:ListItem>
                            <asp:ListItem>COM55</asp:ListItem>
                            <asp:ListItem>COM56</asp:ListItem>
                            <asp:ListItem>COM57</asp:ListItem>
                            <asp:ListItem>COM58</asp:ListItem>
                            <asp:ListItem>COM59</asp:ListItem>
                            <asp:ListItem>COM60</asp:ListItem>
                            <asp:ListItem>COM61</asp:ListItem>
                            <asp:ListItem>COM62</asp:ListItem>
                            <asp:ListItem>COM63</asp:ListItem>
                            <asp:ListItem>COM64</asp:ListItem>
                            <asp:ListItem>COM65</asp:ListItem>
                            <asp:ListItem>COM66</asp:ListItem>
                            <asp:ListItem>COM67</asp:ListItem>
                            <asp:ListItem>COM68</asp:ListItem>
                            <asp:ListItem>COM69</asp:ListItem>
                            <asp:ListItem>COM70</asp:ListItem>
                            <asp:ListItem>COM71</asp:ListItem>
                            <asp:ListItem>COM72</asp:ListItem>
                            <asp:ListItem>COM73</asp:ListItem>
                            <asp:ListItem>COM74</asp:ListItem>
                            <asp:ListItem>COM75</asp:ListItem>
                            <asp:ListItem>COM76</asp:ListItem>
                            <asp:ListItem>COM77</asp:ListItem>
                            <asp:ListItem>COM78</asp:ListItem>
                            <asp:ListItem>COM79</asp:ListItem>
                            <asp:ListItem>COM80</asp:ListItem>
                            <asp:ListItem>COM81</asp:ListItem>
                            <asp:ListItem>COM82</asp:ListItem>
                            <asp:ListItem>COM83</asp:ListItem>
                            <asp:ListItem>COM84</asp:ListItem>
                            <asp:ListItem>COM85</asp:ListItem>
                            <asp:ListItem>COM86</asp:ListItem>
                            <asp:ListItem>COM87</asp:ListItem>
                            <asp:ListItem>COM88</asp:ListItem>
                            <asp:ListItem>COM89</asp:ListItem>
                            <asp:ListItem>COM90</asp:ListItem>
                            <asp:ListItem>COM91</asp:ListItem>
                            <asp:ListItem>COM92</asp:ListItem>
                            <asp:ListItem>COM93</asp:ListItem>
                            <asp:ListItem>COM94</asp:ListItem>
                            <asp:ListItem>COM95</asp:ListItem>
                            <asp:ListItem>COM96</asp:ListItem>
                            <asp:ListItem>COM97</asp:ListItem>
                            <asp:ListItem>COM98</asp:ListItem>
                            <asp:ListItem>COM99</asp:ListItem>
                        </asp:DropDownList>

                                    </td>
                    <td class="auto-style2">

                        &nbsp;</td>
                    <td>

                        <asp:TextBox ID="txTractionSpeed9" runat="server" TextMode="Number" Width="60px"></asp:TextBox>

                                    </td>
                    <td class="auto-style2">

                        &nbsp;</td>
                    <td>

                        <asp:TextBox ID="txTractionDelay9" runat="server" TextMode="Number" Width="60px"></asp:TextBox>

                                    </td>
                    <td>

                        <asp:CheckBox ID="CheckBox18" runat="server" />
                                    </td>
                    <td class="auto-style2">

                        &nbsp;</td>
                    <td>

                        &nbsp;</td>
                    <td>

                        &nbsp;</td>
                </tr>
                                <tr>
                    <td class="auto-style4">

                        <asp:Label ID="Label36" runat="server" Text="Czujnik trakcji Stanowisko 10"></asp:Label>

                                    </td>
                    <td>

                        <asp:DropDownList ID="ddltractionPort10" runat="server">
                                 <asp:ListItem>COM1</asp:ListItem>
                            <asp:ListItem>COM2</asp:ListItem>
                            <asp:ListItem>COM3</asp:ListItem>
                            <asp:ListItem>COM4</asp:ListItem>
                            <asp:ListItem>COM5</asp:ListItem>
                            <asp:ListItem>COM6</asp:ListItem>
                            <asp:ListItem>COM7</asp:ListItem>
                            <asp:ListItem>COM8</asp:ListItem>
                            <asp:ListItem>COM9</asp:ListItem>
                            <asp:ListItem>COM10</asp:ListItem>
                            <asp:ListItem>COM11</asp:ListItem>
                            <asp:ListItem>COM12</asp:ListItem>
                            <asp:ListItem>COM13</asp:ListItem>
                            <asp:ListItem>COM14</asp:ListItem>
                            <asp:ListItem>COM15</asp:ListItem>
                            <asp:ListItem>COM16</asp:ListItem>
                            <asp:ListItem>COM17</asp:ListItem>
                            <asp:ListItem>COM18</asp:ListItem>
                            <asp:ListItem>COM19</asp:ListItem>
                            <asp:ListItem>COM20</asp:ListItem>
                            <asp:ListItem>COM21</asp:ListItem>
                            <asp:ListItem>COM22</asp:ListItem>
                            <asp:ListItem>COM23</asp:ListItem>
                            <asp:ListItem>COM24</asp:ListItem>
                            <asp:ListItem>COM25</asp:ListItem>
                            <asp:ListItem>COM26</asp:ListItem>
                            <asp:ListItem>COM27</asp:ListItem>
                            <asp:ListItem>COM28</asp:ListItem>
                            <asp:ListItem>COM29</asp:ListItem>
                            <asp:ListItem>COM30</asp:ListItem>
                            <asp:ListItem>COM31</asp:ListItem>
                            <asp:ListItem>COM32</asp:ListItem>
                            <asp:ListItem>COM33</asp:ListItem>
                            <asp:ListItem>COM34</asp:ListItem>
                            <asp:ListItem>COM35</asp:ListItem>
                            <asp:ListItem>COM36</asp:ListItem>
                            <asp:ListItem>COM37</asp:ListItem>
                            <asp:ListItem>COM38</asp:ListItem>
                            <asp:ListItem>COM39</asp:ListItem>
                            <asp:ListItem>COM40</asp:ListItem>
                            <asp:ListItem>COM41</asp:ListItem>
                            <asp:ListItem>COM42</asp:ListItem>
                            <asp:ListItem>COM43</asp:ListItem>
                            <asp:ListItem>COM44</asp:ListItem>
                            <asp:ListItem>COM45</asp:ListItem>
                            <asp:ListItem>COM46</asp:ListItem>
                            <asp:ListItem>COM47</asp:ListItem>
                            <asp:ListItem>COM48</asp:ListItem>
                            <asp:ListItem>COM49</asp:ListItem>
                            <asp:ListItem>COM50</asp:ListItem>
                            <asp:ListItem>COM51</asp:ListItem>
                            <asp:ListItem>COM52</asp:ListItem>
                            <asp:ListItem>COM53</asp:ListItem>
                            <asp:ListItem>COM54</asp:ListItem>
                            <asp:ListItem>COM55</asp:ListItem>
                            <asp:ListItem>COM56</asp:ListItem>
                            <asp:ListItem>COM57</asp:ListItem>
                            <asp:ListItem>COM58</asp:ListItem>
                            <asp:ListItem>COM59</asp:ListItem>
                            <asp:ListItem>COM60</asp:ListItem>
                            <asp:ListItem>COM61</asp:ListItem>
                            <asp:ListItem>COM62</asp:ListItem>
                            <asp:ListItem>COM63</asp:ListItem>
                            <asp:ListItem>COM64</asp:ListItem>
                            <asp:ListItem>COM65</asp:ListItem>
                            <asp:ListItem>COM66</asp:ListItem>
                            <asp:ListItem>COM67</asp:ListItem>
                            <asp:ListItem>COM68</asp:ListItem>
                            <asp:ListItem>COM69</asp:ListItem>
                            <asp:ListItem>COM70</asp:ListItem>
                            <asp:ListItem>COM71</asp:ListItem>
                            <asp:ListItem>COM72</asp:ListItem>
                            <asp:ListItem>COM73</asp:ListItem>
                            <asp:ListItem>COM74</asp:ListItem>
                            <asp:ListItem>COM75</asp:ListItem>
                            <asp:ListItem>COM76</asp:ListItem>
                            <asp:ListItem>COM77</asp:ListItem>
                            <asp:ListItem>COM78</asp:ListItem>
                            <asp:ListItem>COM79</asp:ListItem>
                            <asp:ListItem>COM80</asp:ListItem>
                            <asp:ListItem>COM81</asp:ListItem>
                            <asp:ListItem>COM82</asp:ListItem>
                            <asp:ListItem>COM83</asp:ListItem>
                            <asp:ListItem>COM84</asp:ListItem>
                            <asp:ListItem>COM85</asp:ListItem>
                            <asp:ListItem>COM86</asp:ListItem>
                            <asp:ListItem>COM87</asp:ListItem>
                            <asp:ListItem>COM88</asp:ListItem>
                            <asp:ListItem>COM89</asp:ListItem>
                            <asp:ListItem>COM90</asp:ListItem>
                            <asp:ListItem>COM91</asp:ListItem>
                            <asp:ListItem>COM92</asp:ListItem>
                            <asp:ListItem>COM93</asp:ListItem>
                            <asp:ListItem>COM94</asp:ListItem>
                            <asp:ListItem>COM95</asp:ListItem>
                            <asp:ListItem>COM96</asp:ListItem>
                            <asp:ListItem>COM97</asp:ListItem>
                            <asp:ListItem>COM98</asp:ListItem>
                            <asp:ListItem>COM99</asp:ListItem>
                        </asp:DropDownList>

                                    </td>
                    <td class="auto-style2">

                        &nbsp;</td>
                    <td>

                        <asp:TextBox ID="txTractionSpeed10" runat="server" TextMode="Number" Width="60px"></asp:TextBox>

                                    </td>
                    <td class="auto-style2">

                        &nbsp;</td>
                    <td>

                        <asp:TextBox ID="txTractionDelay10" runat="server" TextMode="Number" Width="60px"></asp:TextBox>

                                    </td>
                    <td>

                        <asp:CheckBox ID="CheckBox19" runat="server" />
                                    </td>
                    <td class="auto-style2">

                        &nbsp;</td>
                    <td>

                        &nbsp;</td>
                    <td>

                        &nbsp;</td>
                </tr>
                                <tr>
                    <td class="auto-style4">

                        <asp:Label ID="Label37" runat="server" Text="Czujnik trakcji Stanowisko 11"></asp:Label>

                                    </td>
                    <td>

                        <asp:DropDownList ID="ddltractionPort11" runat="server">
                                 <asp:ListItem>COM1</asp:ListItem>
                            <asp:ListItem>COM2</asp:ListItem>
                            <asp:ListItem>COM3</asp:ListItem>
                            <asp:ListItem>COM4</asp:ListItem>
                            <asp:ListItem>COM5</asp:ListItem>
                            <asp:ListItem>COM6</asp:ListItem>
                            <asp:ListItem>COM7</asp:ListItem>
                            <asp:ListItem>COM8</asp:ListItem>
                            <asp:ListItem>COM9</asp:ListItem>
                            <asp:ListItem>COM10</asp:ListItem>
                            <asp:ListItem>COM11</asp:ListItem>
                            <asp:ListItem>COM12</asp:ListItem>
                            <asp:ListItem>COM13</asp:ListItem>
                            <asp:ListItem>COM14</asp:ListItem>
                            <asp:ListItem>COM15</asp:ListItem>
                            <asp:ListItem>COM16</asp:ListItem>
                            <asp:ListItem>COM17</asp:ListItem>
                            <asp:ListItem>COM18</asp:ListItem>
                            <asp:ListItem>COM19</asp:ListItem>
                            <asp:ListItem>COM20</asp:ListItem>
                            <asp:ListItem>COM21</asp:ListItem>
                            <asp:ListItem>COM22</asp:ListItem>
                            <asp:ListItem>COM23</asp:ListItem>
                            <asp:ListItem>COM24</asp:ListItem>
                            <asp:ListItem>COM25</asp:ListItem>
                            <asp:ListItem>COM26</asp:ListItem>
                            <asp:ListItem>COM27</asp:ListItem>
                            <asp:ListItem>COM28</asp:ListItem>
                            <asp:ListItem>COM29</asp:ListItem>
                            <asp:ListItem>COM30</asp:ListItem>
                            <asp:ListItem>COM31</asp:ListItem>
                            <asp:ListItem>COM32</asp:ListItem>
                            <asp:ListItem>COM33</asp:ListItem>
                            <asp:ListItem>COM34</asp:ListItem>
                            <asp:ListItem>COM35</asp:ListItem>
                            <asp:ListItem>COM36</asp:ListItem>
                            <asp:ListItem>COM37</asp:ListItem>
                            <asp:ListItem>COM38</asp:ListItem>
                            <asp:ListItem>COM39</asp:ListItem>
                            <asp:ListItem>COM40</asp:ListItem>
                            <asp:ListItem>COM41</asp:ListItem>
                            <asp:ListItem>COM42</asp:ListItem>
                            <asp:ListItem>COM43</asp:ListItem>
                            <asp:ListItem>COM44</asp:ListItem>
                            <asp:ListItem>COM45</asp:ListItem>
                            <asp:ListItem>COM46</asp:ListItem>
                            <asp:ListItem>COM47</asp:ListItem>
                            <asp:ListItem>COM48</asp:ListItem>
                            <asp:ListItem>COM49</asp:ListItem>
                            <asp:ListItem>COM50</asp:ListItem>
                            <asp:ListItem>COM51</asp:ListItem>
                            <asp:ListItem>COM52</asp:ListItem>
                            <asp:ListItem>COM53</asp:ListItem>
                            <asp:ListItem>COM54</asp:ListItem>
                            <asp:ListItem>COM55</asp:ListItem>
                            <asp:ListItem>COM56</asp:ListItem>
                            <asp:ListItem>COM57</asp:ListItem>
                            <asp:ListItem>COM58</asp:ListItem>
                            <asp:ListItem>COM59</asp:ListItem>
                            <asp:ListItem>COM60</asp:ListItem>
                            <asp:ListItem>COM61</asp:ListItem>
                            <asp:ListItem>COM62</asp:ListItem>
                            <asp:ListItem>COM63</asp:ListItem>
                            <asp:ListItem>COM64</asp:ListItem>
                            <asp:ListItem>COM65</asp:ListItem>
                            <asp:ListItem>COM66</asp:ListItem>
                            <asp:ListItem>COM67</asp:ListItem>
                            <asp:ListItem>COM68</asp:ListItem>
                            <asp:ListItem>COM69</asp:ListItem>
                            <asp:ListItem>COM70</asp:ListItem>
                            <asp:ListItem>COM71</asp:ListItem>
                            <asp:ListItem>COM72</asp:ListItem>
                            <asp:ListItem>COM73</asp:ListItem>
                            <asp:ListItem>COM74</asp:ListItem>
                            <asp:ListItem>COM75</asp:ListItem>
                            <asp:ListItem>COM76</asp:ListItem>
                            <asp:ListItem>COM77</asp:ListItem>
                            <asp:ListItem>COM78</asp:ListItem>
                            <asp:ListItem>COM79</asp:ListItem>
                            <asp:ListItem>COM80</asp:ListItem>
                            <asp:ListItem>COM81</asp:ListItem>
                            <asp:ListItem>COM82</asp:ListItem>
                            <asp:ListItem>COM83</asp:ListItem>
                            <asp:ListItem>COM84</asp:ListItem>
                            <asp:ListItem>COM85</asp:ListItem>
                            <asp:ListItem>COM86</asp:ListItem>
                            <asp:ListItem>COM87</asp:ListItem>
                            <asp:ListItem>COM88</asp:ListItem>
                            <asp:ListItem>COM89</asp:ListItem>
                            <asp:ListItem>COM90</asp:ListItem>
                            <asp:ListItem>COM91</asp:ListItem>
                            <asp:ListItem>COM92</asp:ListItem>
                            <asp:ListItem>COM93</asp:ListItem>
                            <asp:ListItem>COM94</asp:ListItem>
                            <asp:ListItem>COM95</asp:ListItem>
                            <asp:ListItem>COM96</asp:ListItem>
                            <asp:ListItem>COM97</asp:ListItem>
                            <asp:ListItem>COM98</asp:ListItem>
                            <asp:ListItem>COM99</asp:ListItem>
                        </asp:DropDownList>

                                    </td>
                    <td class="auto-style2">

                        &nbsp;</td>
                    <td>

                        <asp:TextBox ID="txTractionSpeed11" runat="server" TextMode="Number" Width="60px"></asp:TextBox>

                                    </td>
                    <td class="auto-style2">

                        &nbsp;</td>
                    <td>

                        <asp:TextBox ID="txTractionDelay11" runat="server" TextMode="Number" Width="60px"></asp:TextBox>

                                    </td>
                    <td>

                        <asp:CheckBox ID="CheckBox20" runat="server" />
                                    </td>
                    <td class="auto-style2">

                        &nbsp;</td>
                    <td>

                        &nbsp;</td>
                    <td>

                        &nbsp;</td>
                </tr>
                                <tr>
                    <td class="auto-style4">

                        <asp:Label ID="Label38" runat="server" Text="Czujnik trakcji Stanowisko 12"></asp:Label>

                                    </td>
                    <td>

                        <asp:DropDownList ID="ddltractionPort12" runat="server">
                                 <asp:ListItem>COM1</asp:ListItem>
                            <asp:ListItem>COM2</asp:ListItem>
                            <asp:ListItem>COM3</asp:ListItem>
                            <asp:ListItem>COM4</asp:ListItem>
                            <asp:ListItem>COM5</asp:ListItem>
                            <asp:ListItem>COM6</asp:ListItem>
                            <asp:ListItem>COM7</asp:ListItem>
                            <asp:ListItem>COM8</asp:ListItem>
                            <asp:ListItem>COM9</asp:ListItem>
                            <asp:ListItem>COM10</asp:ListItem>
                            <asp:ListItem>COM11</asp:ListItem>
                            <asp:ListItem>COM12</asp:ListItem>
                            <asp:ListItem>COM13</asp:ListItem>
                            <asp:ListItem>COM14</asp:ListItem>
                            <asp:ListItem>COM15</asp:ListItem>
                            <asp:ListItem>COM16</asp:ListItem>
                            <asp:ListItem>COM17</asp:ListItem>
                            <asp:ListItem>COM18</asp:ListItem>
                            <asp:ListItem>COM19</asp:ListItem>
                            <asp:ListItem>COM20</asp:ListItem>
                            <asp:ListItem>COM21</asp:ListItem>
                            <asp:ListItem>COM22</asp:ListItem>
                            <asp:ListItem>COM23</asp:ListItem>
                            <asp:ListItem>COM24</asp:ListItem>
                            <asp:ListItem>COM25</asp:ListItem>
                            <asp:ListItem>COM26</asp:ListItem>
                            <asp:ListItem>COM27</asp:ListItem>
                            <asp:ListItem>COM28</asp:ListItem>
                            <asp:ListItem>COM29</asp:ListItem>
                            <asp:ListItem>COM30</asp:ListItem>
                            <asp:ListItem>COM31</asp:ListItem>
                            <asp:ListItem>COM32</asp:ListItem>
                            <asp:ListItem>COM33</asp:ListItem>
                            <asp:ListItem>COM34</asp:ListItem>
                            <asp:ListItem>COM35</asp:ListItem>
                            <asp:ListItem>COM36</asp:ListItem>
                            <asp:ListItem>COM37</asp:ListItem>
                            <asp:ListItem>COM38</asp:ListItem>
                            <asp:ListItem>COM39</asp:ListItem>
                            <asp:ListItem>COM40</asp:ListItem>
                            <asp:ListItem>COM41</asp:ListItem>
                            <asp:ListItem>COM42</asp:ListItem>
                            <asp:ListItem>COM43</asp:ListItem>
                            <asp:ListItem>COM44</asp:ListItem>
                            <asp:ListItem>COM45</asp:ListItem>
                            <asp:ListItem>COM46</asp:ListItem>
                            <asp:ListItem>COM47</asp:ListItem>
                            <asp:ListItem>COM48</asp:ListItem>
                            <asp:ListItem>COM49</asp:ListItem>
                            <asp:ListItem>COM50</asp:ListItem>
                            <asp:ListItem>COM51</asp:ListItem>
                            <asp:ListItem>COM52</asp:ListItem>
                            <asp:ListItem>COM53</asp:ListItem>
                            <asp:ListItem>COM54</asp:ListItem>
                            <asp:ListItem>COM55</asp:ListItem>
                            <asp:ListItem>COM56</asp:ListItem>
                            <asp:ListItem>COM57</asp:ListItem>
                            <asp:ListItem>COM58</asp:ListItem>
                            <asp:ListItem>COM59</asp:ListItem>
                            <asp:ListItem>COM60</asp:ListItem>
                            <asp:ListItem>COM61</asp:ListItem>
                            <asp:ListItem>COM62</asp:ListItem>
                            <asp:ListItem>COM63</asp:ListItem>
                            <asp:ListItem>COM64</asp:ListItem>
                            <asp:ListItem>COM65</asp:ListItem>
                            <asp:ListItem>COM66</asp:ListItem>
                            <asp:ListItem>COM67</asp:ListItem>
                            <asp:ListItem>COM68</asp:ListItem>
                            <asp:ListItem>COM69</asp:ListItem>
                            <asp:ListItem>COM70</asp:ListItem>
                            <asp:ListItem>COM71</asp:ListItem>
                            <asp:ListItem>COM72</asp:ListItem>
                            <asp:ListItem>COM73</asp:ListItem>
                            <asp:ListItem>COM74</asp:ListItem>
                            <asp:ListItem>COM75</asp:ListItem>
                            <asp:ListItem>COM76</asp:ListItem>
                            <asp:ListItem>COM77</asp:ListItem>
                            <asp:ListItem>COM78</asp:ListItem>
                            <asp:ListItem>COM79</asp:ListItem>
                            <asp:ListItem>COM80</asp:ListItem>
                            <asp:ListItem>COM81</asp:ListItem>
                            <asp:ListItem>COM82</asp:ListItem>
                            <asp:ListItem>COM83</asp:ListItem>
                            <asp:ListItem>COM84</asp:ListItem>
                            <asp:ListItem>COM85</asp:ListItem>
                            <asp:ListItem>COM86</asp:ListItem>
                            <asp:ListItem>COM87</asp:ListItem>
                            <asp:ListItem>COM88</asp:ListItem>
                            <asp:ListItem>COM89</asp:ListItem>
                            <asp:ListItem>COM90</asp:ListItem>
                            <asp:ListItem>COM91</asp:ListItem>
                            <asp:ListItem>COM92</asp:ListItem>
                            <asp:ListItem>COM93</asp:ListItem>
                            <asp:ListItem>COM94</asp:ListItem>
                            <asp:ListItem>COM95</asp:ListItem>
                            <asp:ListItem>COM96</asp:ListItem>
                            <asp:ListItem>COM97</asp:ListItem>
                            <asp:ListItem>COM98</asp:ListItem>
                            <asp:ListItem>COM99</asp:ListItem>
                        </asp:DropDownList>

                                    </td>
                    <td class="auto-style2">

                        &nbsp;</td>
                    <td>

                        <asp:TextBox ID="txTractionSpeed12" runat="server" TextMode="Number" Width="60px"></asp:TextBox>

                                    </td>
                    <td class="auto-style2">

                        &nbsp;</td>
                    <td>

                        <asp:TextBox ID="txTractionDelay12" runat="server" TextMode="Number" Width="60px"></asp:TextBox>

                                    </td>
                    <td>

                        <asp:CheckBox ID="CheckBox21" runat="server" />
                                    </td>
                    <td class="auto-style2">

                        &nbsp;</td>
                    <td>

                        &nbsp;</td>
                    <td>

                        &nbsp;</td>
                </tr>
                                <tr>
                    <td class="auto-style4">

                        <asp:Label ID="Label39" runat="server" Text="Czujnik trakcji Stanowisko 13"></asp:Label>

                                    </td>
                    <td>

                        <asp:DropDownList ID="ddltractionPort13" runat="server">
                                 <asp:ListItem>COM1</asp:ListItem>
                            <asp:ListItem>COM2</asp:ListItem>
                            <asp:ListItem>COM3</asp:ListItem>
                            <asp:ListItem>COM4</asp:ListItem>
                            <asp:ListItem>COM5</asp:ListItem>
                            <asp:ListItem>COM6</asp:ListItem>
                            <asp:ListItem>COM7</asp:ListItem>
                            <asp:ListItem>COM8</asp:ListItem>
                            <asp:ListItem>COM9</asp:ListItem>
                            <asp:ListItem>COM10</asp:ListItem>
                            <asp:ListItem>COM11</asp:ListItem>
                            <asp:ListItem>COM12</asp:ListItem>
                            <asp:ListItem>COM13</asp:ListItem>
                            <asp:ListItem>COM14</asp:ListItem>
                            <asp:ListItem>COM15</asp:ListItem>
                            <asp:ListItem>COM16</asp:ListItem>
                            <asp:ListItem>COM17</asp:ListItem>
                            <asp:ListItem>COM18</asp:ListItem>
                            <asp:ListItem>COM19</asp:ListItem>
                            <asp:ListItem>COM20</asp:ListItem>
                            <asp:ListItem>COM21</asp:ListItem>
                            <asp:ListItem>COM22</asp:ListItem>
                            <asp:ListItem>COM23</asp:ListItem>
                            <asp:ListItem>COM24</asp:ListItem>
                            <asp:ListItem>COM25</asp:ListItem>
                            <asp:ListItem>COM26</asp:ListItem>
                            <asp:ListItem>COM27</asp:ListItem>
                            <asp:ListItem>COM28</asp:ListItem>
                            <asp:ListItem>COM29</asp:ListItem>
                            <asp:ListItem>COM30</asp:ListItem>
                            <asp:ListItem>COM31</asp:ListItem>
                            <asp:ListItem>COM32</asp:ListItem>
                            <asp:ListItem>COM33</asp:ListItem>
                            <asp:ListItem>COM34</asp:ListItem>
                            <asp:ListItem>COM35</asp:ListItem>
                            <asp:ListItem>COM36</asp:ListItem>
                            <asp:ListItem>COM37</asp:ListItem>
                            <asp:ListItem>COM38</asp:ListItem>
                            <asp:ListItem>COM39</asp:ListItem>
                            <asp:ListItem>COM40</asp:ListItem>
                            <asp:ListItem>COM41</asp:ListItem>
                            <asp:ListItem>COM42</asp:ListItem>
                            <asp:ListItem>COM43</asp:ListItem>
                            <asp:ListItem>COM44</asp:ListItem>
                            <asp:ListItem>COM45</asp:ListItem>
                            <asp:ListItem>COM46</asp:ListItem>
                            <asp:ListItem>COM47</asp:ListItem>
                            <asp:ListItem>COM48</asp:ListItem>
                            <asp:ListItem>COM49</asp:ListItem>
                            <asp:ListItem>COM50</asp:ListItem>
                            <asp:ListItem>COM51</asp:ListItem>
                            <asp:ListItem>COM52</asp:ListItem>
                            <asp:ListItem>COM53</asp:ListItem>
                            <asp:ListItem>COM54</asp:ListItem>
                            <asp:ListItem>COM55</asp:ListItem>
                            <asp:ListItem>COM56</asp:ListItem>
                            <asp:ListItem>COM57</asp:ListItem>
                            <asp:ListItem>COM58</asp:ListItem>
                            <asp:ListItem>COM59</asp:ListItem>
                            <asp:ListItem>COM60</asp:ListItem>
                            <asp:ListItem>COM61</asp:ListItem>
                            <asp:ListItem>COM62</asp:ListItem>
                            <asp:ListItem>COM63</asp:ListItem>
                            <asp:ListItem>COM64</asp:ListItem>
                            <asp:ListItem>COM65</asp:ListItem>
                            <asp:ListItem>COM66</asp:ListItem>
                            <asp:ListItem>COM67</asp:ListItem>
                            <asp:ListItem>COM68</asp:ListItem>
                            <asp:ListItem>COM69</asp:ListItem>
                            <asp:ListItem>COM70</asp:ListItem>
                            <asp:ListItem>COM71</asp:ListItem>
                            <asp:ListItem>COM72</asp:ListItem>
                            <asp:ListItem>COM73</asp:ListItem>
                            <asp:ListItem>COM74</asp:ListItem>
                            <asp:ListItem>COM75</asp:ListItem>
                            <asp:ListItem>COM76</asp:ListItem>
                            <asp:ListItem>COM77</asp:ListItem>
                            <asp:ListItem>COM78</asp:ListItem>
                            <asp:ListItem>COM79</asp:ListItem>
                            <asp:ListItem>COM80</asp:ListItem>
                            <asp:ListItem>COM81</asp:ListItem>
                            <asp:ListItem>COM82</asp:ListItem>
                            <asp:ListItem>COM83</asp:ListItem>
                            <asp:ListItem>COM84</asp:ListItem>
                            <asp:ListItem>COM85</asp:ListItem>
                            <asp:ListItem>COM86</asp:ListItem>
                            <asp:ListItem>COM87</asp:ListItem>
                            <asp:ListItem>COM88</asp:ListItem>
                            <asp:ListItem>COM89</asp:ListItem>
                            <asp:ListItem>COM90</asp:ListItem>
                            <asp:ListItem>COM91</asp:ListItem>
                            <asp:ListItem>COM92</asp:ListItem>
                            <asp:ListItem>COM93</asp:ListItem>
                            <asp:ListItem>COM94</asp:ListItem>
                            <asp:ListItem>COM95</asp:ListItem>
                            <asp:ListItem>COM96</asp:ListItem>
                            <asp:ListItem>COM97</asp:ListItem>
                            <asp:ListItem>COM98</asp:ListItem>
                            <asp:ListItem>COM99</asp:ListItem>
                        </asp:DropDownList>

                                    </td>
                    <td class="auto-style2">

                        &nbsp;</td>
                    <td>

                        <asp:TextBox ID="txTractionSpeed13" runat="server" TextMode="Number" Width="60px"></asp:TextBox>

                                    </td>
                    <td class="auto-style2">

                        &nbsp;</td>
                    <td>

                        <asp:TextBox ID="txTractionDelay13" runat="server" TextMode="Number" Width="60px"></asp:TextBox>

                                    </td>
                    <td>

                        <asp:CheckBox ID="CheckBox22" runat="server" />
                                    </td>
                    <td class="auto-style2">

                        &nbsp;</td>
                    <td>

                        &nbsp;</td>
                    <td>

                        &nbsp;</td>
                </tr>
                                <tr>
                    <td class="auto-style4">

                        &nbsp;</td>
                    <td>

                        &nbsp;</td>
                    <td class="auto-style2">

                        &nbsp;</td>
                    <td>

                        &nbsp;</td>
                    <td class="auto-style2">

                        &nbsp;</td>
                    <td>

                        &nbsp;</td>
                    <td>

                        &nbsp;</td>
                    <td class="auto-style2">

                        &nbsp;</td>
                    <td>

                        &nbsp;</td>
                    <td>

                        &nbsp;</td>
                </tr>
                                <tr>
                    <td class="auto-style4">

                        &nbsp;</td>
                    <td>

                        &nbsp;</td>
                    <td class="auto-style2">

                        &nbsp;</td>
                    <td>

                        &nbsp;</td>
                    <td class="auto-style2">

                        &nbsp;</td>
                    <td>

                        &nbsp;</td>
                    <td>

                        &nbsp;</td>
                    <td class="auto-style2">

                        &nbsp;</td>
                    <td>

                        &nbsp;</td>
                    <td>

                        &nbsp;</td>
                </tr>
                                <tr>
                    <td class="auto-style4">

                        &nbsp;</td>
                    <td>

                        &nbsp;</td>
                    <td class="auto-style2">

                        &nbsp;</td>
                    <td>

                        &nbsp;</td>
                    <td class="auto-style2">

                        &nbsp;</td>
                    <td>

                        &nbsp;</td>
                    <td>

                        &nbsp;</td>
                    <td class="auto-style2">

                        &nbsp;</td>
                    <td>

                        &nbsp;</td>
                    <td>

                        &nbsp;</td>
                </tr>
            </table>


        </div>
    </form>
</body>
</html>
