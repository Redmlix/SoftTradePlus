   M S B A M L   `   `   `  ????H  DSoftTradePlus, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:SoftTradePlusSoftTradePlus  5   	   #    SoftTradePlus.AdditionalViews   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:SoftTradePlus     5   	   -   5          ?Name$  window??5	   !   $	??450??5   	   $	??800??6    ? Title$ AdditionalViews??5	   	   $	??450??61   $	??800??6>   .??5
      ?  ? ColumnDefinitions 5   
   ?? 5      $??* ?6   ?? 5      $	??180 ?6   .+?5   
   ??  ?? Orientation$ Vertical=?6   $??1??6,   .+?5      ?? $??	Pick view??6   ?? 5      -   5         ??Name$ 
viewPickCb??5      $??2q?6+   66   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ additViewsTable??5         AutoGenerateColumns$
 True??6Z      CanUserAddRows$ False??6u      
IsReadOnly$
 True??6?   $??0??6?   ??6,   ?? *
ViewList+	 ?? Mode$	 OneWay=?6?   ?? 5   
   -   5        
 ??Name$
 stackPanelBottom??5      $ Vertical=?6/   $??Bottom=?6F   $??1??6a   .+?5      ?? -   5         ??Name$ backBtn??5      $
??Back??6<   $??50??6K   $??2q?6W   5      5      5      