   M S B A M L   `   `   `  ????H  DSoftTradePlus, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:SoftTradePlusSoftTradePlus  5   	   "    SoftTradePlus.ProductsWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:SoftTradePlus     5   	   -   5          ?Name$  window??5	      $	??450??5   	   $	??800??6    ? Title$ Products??5	   	   $	??450??6*   $	??800??67   .??5
      ?  ? ColumnDefinitions 5   
   ?? 5      $??* ?6   ?? 5      $	??180 ?6   .+?5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ productsTable??5         AutoGenerateColumns$ False??6X      CanUserAddRows$ False??6t   $??0??6?   ??6*   ?? *
Products+ ?? Mode$ OneWay=?   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Id??6<   	   Width5  /System.Windows.Controls.DataGridLengthConverter$		 100 6H   
   
IsReadOnly$

 True??6T   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   ?? *Id+6T     5      $
 Name??6>   $		 100 6L    6%   ?? *Name+6L     5      $ Price??6?   $		 100 6N    6%   ?? *Price+6N     5      $
 Type??6>   $		 100 6L    6%   ?? *Type+6L     5      $ Date expiring??6W   $		 120 6n    6%   ?? *Date+ ?? StringFormat$ 
yyyy-MM-dd??6n   5      ?? 5   
   -   5         ??Name$ stackPanelVertical??5       ?? Orientation$ Vertical=?61   $??1??6H   .+?5      ?? $
??Name??6   ?? 5      -   5         ??Name$ productNameTb??5      $??20??6-   $??2q?69   ?? 5      $??Price??6   ?? 5      -   5        $ productPriceTb??5      $??20??6Y   $??2q?6e   ?? 5      $
??Type??6   ?? 5      -   5         ??Name$ productTypeCb??5       ?? SelectedValuePath$ Id??6?    ?? DisplayMemberPath$
 Name??6?   $??2q?6?   ??6`   ?? *ProductTypes+$ OneWay=?6?   ?? 5      $??Date Expiring??6   (  "System.Windows.Controls.DatePicker  5       -   5          Name$ productDateCalendar??5       $??2q?66   ?? 5!      -   5         ??Name$ addBtn??5!      $	??Add??6:   $??50??6H   $??	2,10,2,10q?6T   ?? 5"      -	   5        $ 	deleteBtn??5"      $??Delete selected??6@   $??50??6Z   $??2,0,2,2q?6f   5#      ?? 5$   
   -
   5        $ stackPanelBottom??5$      $ Vertical=?6/   $??Bottom=?6F   $??1??6a   .+?5%      ?? -   5        $ backBtn??5%      $
??Back??6<   $??50??6K   $??2q?6W   5&      5'      5(      