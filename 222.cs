	//=======================================================================
	//
	//	This Script was made for the use by Arcturus,
	//	No other faction, players, mods or admins are allowed to copy
	//	edit, or reproduce this script without the express permission
	//	from ColdStranger!
	//TradeScriptIngots,Welcome
	//TradeScriptIngots,Sell,Any
	//TradeScriptIngots,Buy,Gold
	//
	//Config:CustomerDisplay=LCDTradeTerminal222;
	//Config:PriceDisplay=LCDTradePrices222;
	//Config:Entry=222;
	//Config:Vault=TradeVault;
	//Config:Stock=TradeStationStock222;
	//Config:TradeOutSorter=TradeOUTLEAVEOFF;
	//
	//Config:BuyRate=0.95;
	//Config:SellRate=0.99;
	//
	//=======================================================================
        const string MODE_BUY = "Buy";
        const string MODE_SELL = "Sell";
        const string MODE_WELCOME = "Welcome";

        struct TradeStation
        {
            public float RateTraderBuy;
            public float RateTraderSell;
            public string Mode;
            public string ModeTarget;
            public string ItemTypeCurrency;
            public string NameCargoContainerEntry;
            public string NameCargoContainerVault;
            public string NameLCDDisplayCustomer;
            public string NameLCDDisplayPrice;
            public string NameLCDStock;
	    public string NameTradeOut;
            public string NameProgrammableBlockScript;
            public string MsgCollectYourItems;
            public string MsgCollectYourPayment;
            public string MsgErrBlockHasNoInventory;
            public string MsgErrBlockNotFound;
            public string MsgErrInsufficientFunds;
            public string MsgErrInsufficientItems;
            public string MsgErrItemsNotReceived;
            public string MsgErrItemsNotSent;
            public string MsgErrNoFunds;
            public string MsgErrNotANumber;
            public string MsgErrNotInterested;
            public string MsgErrNoTradeItems;
            public string MsgErrPaymentNotReceived;
            public string MsgErrPaymentNotSent;
            public string MsgErrPurchaseNotSpecified;
            public string MsgErrTechnicalDifficulties;
            public string MsgErrTransferFailed;
            public string MsgErrTransferInsufficientItemsInSource;
            public string MsgErrTransferNoItemsInSource;
            public string MsgErrUnknownConfig;
            public string MsgErrUnknownMode;
            public string MsgErrUnknownParam;
            public string MsgItem;
            public string MsgPayment;
            public string MsgPricesAreIn;
            public string MsgThatBuys;
            public string MsgTransactionEnds;
            public string MsgWeBuy;
            public string MsgWelcome;
            public string MsgWePay;
            public string MsgWeSell;
            public string MsgYouOffer;
            public IMyCargoContainer ContainerEntry;
            public IMyCargoContainer ContainerVault;
            public IMyTextPanel DisplayCustomer;
            public IMyTextPanel DisplayPrice;
            public IMyTextPanel StockPrice;
            public IMyProgrammableBlock ProgramScript;
            public IMyInventory InventoryEntry;
            public IMyInventory InventoryVault;
	    public IMyConveyorSorter TradeOut;
            public HashSet<string> IsWeighable;
            public Dictionary<string, float> PriceLookup;
        };

        TradeStation Info;


        //=======================================================================
        // CONSTRUCTORS

        public Program()
        {
            // The constructor, called only once every session and
            // always before any other method is called. Use it to
            // initialize your script.

            Info.RateTraderBuy = 1.00F; //trader buys from player at 100%
            Info.RateTraderSell = 1.00F; //trader sells to player at 100%
            Info.Mode = MODE_SELL;
            Info.ModeTarget = "Any";
            Info.ItemTypeCurrency = "Titanium";
            Info.NameCargoContainerEntry = "TradeStationEntry";
            Info.NameCargoContainerVault = "TradeStationVault";
            Info.NameLCDDisplayCustomer = "TradeStationCustomerDisplay";
            Info.NameLCDDisplayPrice = "TradeStationPriceDisplay";
            Info.NameProgrammableBlockScript = "TradeStationScript";
            Info.ContainerEntry = null;
            Info.ContainerVault = null;
            Info.DisplayCustomer = null;
            Info.DisplayPrice = null;
            Info.NameLCDStock = "TradeStationStock";
	        Info.NameTradeOut = "TradeOutSorter";
            Info.ProgramScript = null;
            Info.InventoryEntry = null;
            Info.InventoryVault = null;
            Info.IsWeighable = new HashSet<string>();
            Info.PriceLookup = new Dictionary<string, float>();

            //Texts used by the script. Can be translated.
            Info.MsgCollectYourItems = "Please, collect your items from the container.";
            Info.MsgCollectYourPayment = "Please, collect your payment from the container.";
            Info.MsgErrBlockHasNoInventory = "ERR: $VAR1$ has no inventory.";
            Info.MsgErrBlockNotFound = "ERR: $VAR1$ does not exist.";
            Info.MsgErrInsufficientFunds = "Sorry, we can't buy that much. We have only ";
            Info.MsgErrInsufficientItems = "Sorry, we can't sell that much. We have only ";
            Info.MsgErrItemsNotReceived = "We couldn't receive the items you offered.";
            Info.MsgErrItemsNotSent = "We couldn't send you your purchase. Refunding your payment.";
            Info.MsgErrNoFunds = "If you want to buy put funds into the container.";
            Info.MsgErrNotANumber = "ERR: Not a number: '$VAR1$'. Check your price overrides.";
            Info.MsgErrNotInterested = "Not interested in buying $VAR1$";
            Info.MsgErrNoTradeItems = "No Iron Ore found. Insert some to REFINE.";
            Info.MsgErrPaymentNotReceived = "We couldn't receive your payment.";
            Info.MsgErrPaymentNotSent = "Sending your payment failed. Giving your items back.";
            Info.MsgErrPurchaseNotSpecified = "ERR: Keyword 'Any' can't be used when buying.";
            Info.MsgErrTechnicalDifficulties = "Sorry, technical difficulties.";
            Info.MsgErrTransferFailed = "ERR: Failed to move $VAR1$: $VAR2$";
            Info.MsgErrTransferInsufficientItemsInSource = "ERR: Not enough items in $VAR1$: $VAR2$";
            Info.MsgErrTransferNoItemsInSource = "ERR: Can't move items. No $VAR1$ in $VAR2$.";
            Info.MsgErrUnknownConfig = "ERR: Unknown config in $VAR1$ custom data: $VAR2$";
            Info.MsgErrUnknownMode = "ERR: Unknown mode";
            Info.MsgErrUnknownParam = "ERR: Unknown param in $VAR1$: $VAR2$";
            Info.MsgItem = "Item";
            Info.MsgPayment = "Payment";
            Info.MsgPricesAreIn = "Prices are in ";
            Info.MsgThatBuys = "That buys";
            Info.MsgTransactionEnds = "Sale complete. Come Back Soon";
            Info.MsgWeBuy = "We buy";
            Info.MsgWelcome = "*** Welcome ***"
			+ System.Environment.NewLine + System.Environment.NewLine + "Ready to Refine? Hit Ore Button on the panel";
            Info.MsgWePay = "We pay";
            Info.MsgWeSell = "We sell";
            Info.MsgYouOffer = "You offer";
        }


        //=======================================================================
        // HELPER METHODS

        private float ParseFloat(string text)
        {
            //Parses a numeric string into a float, zero if fails
            float parsedValue = 0.0F;
            try
            {
                parsedValue = float.Parse(text);
            }
            catch
            {
                Display(Info.MsgErrNotANumber, text, "");
            }
            return parsedValue;
        }

        private void Display(string text, string var1, string var2, bool append = true)
        {
            string msg = text.Replace("$VAR1$", var1);
            msg = msg.Replace("$VAR2$", var2);
            Display(msg, append);
        }

        private void Display(string text, bool append = true)
        {
            //Display a message on the customer display LCD panel
            if (Info.DisplayCustomer != null)
                Info.DisplayCustomer.WriteText(text + System.Environment.NewLine, append);
        }

        private void ShowPrices()
        {
            //Display all prices on the price display LCD panel
            string priceList =
                Info.MsgPricesAreIn + Info.ItemTypeCurrency + System.Environment.NewLine +
                System.Environment.NewLine +
                Info.MsgItem.PadRight(15) + " " + Info.MsgWeSell.PadLeft(8) + " " + Info.MsgWeBuy.PadLeft(8) + System.Environment.NewLine;
            foreach (KeyValuePair<string, float> KVP in Info.PriceLookup)
            {
                if (KVP.Key == Info.ItemTypeCurrency)
                    continue;
                priceList = priceList + System.Environment.NewLine;
                priceList = priceList + KVP.Key.PadRight(15) + " " + (KVP.Value * Info.RateTraderSell).ToString("0.0000000").PadLeft(8) + " " + (KVP.Value * Info.RateTraderBuy).ToString("0.0000000").PadLeft(8);
            }
            Info.DisplayPrice.WriteText(priceList);
        }

        //Display Stock Inventory
        private void ShowStock()
        {
            Info.StockPrice.WriteText("Current Inventory In Stock \n \n",false);
            for (int i = 0; i < Info.InventoryVault.ItemCount; i++)
            {
                var item= Info.InventoryVault.GetItemAt(i).Value;
                string name2;
                if (item.Type.ToString().Contains("Ore"))
                {
                    name2 = "Ore";
                }
                else
                {
                    name2 = "Ingot";
                }
                string name1 = item.Type.SubtypeId;
                if(name1 == "DuraniumIngot")
                    name1 = "Titanium";
                Info.StockPrice.WriteText(name1 +" " +name2 +" " +(double)item.Amount +"\n", true);
            }
        }

        private void SetLookup(Dictionary<string, float> lookupTable, string key, float value)
        {
            if (lookupTable.ContainsKey(key))
                lookupTable.Remove(key);
            if (value >= 0.00001)
                lookupTable.Add(key, value);
        }

        private string GetItemType(MyInventoryItem item)
        {
            string typeOfItem = item.Type.SubtypeId.ToString();
            string contentDescr = item.ToString();
            if (contentDescr.Contains("_Ore"))
            {
                if (typeOfItem != "Stone" && typeOfItem != "Ice")
                    typeOfItem = typeOfItem + " Ore";
            }
            if (typeOfItem == "Stone" && contentDescr.Contains("_Ingot"))
                typeOfItem = "Gravel";
            return typeOfItem;
        }

        private List<MyInventoryItem> GetInventoryItems(IMyInventory container)
        {
            List<MyInventoryItem> items = new List<MyInventoryItem>();
            container.GetItems(items);
            return items;
        }

        //=======================================================================
        // SETUP AND CONFIG METHODS

        private bool SetupDisplayCustomer()
        {
            //Customer display is used for error messages so have a separate setup for it to get it up ASAP.
            Info.DisplayCustomer = GridTerminalSystem.GetBlockWithName(Info.NameLCDDisplayCustomer) as IMyTextPanel;
            if (Info.DisplayCustomer == null)
                return false;

            return true;
        }

        private bool SetupProgramScript()
        {
            //The programmable block's customer data contains the configuration so setup this first
            Info.ProgramScript = GridTerminalSystem.GetBlockWithName(Info.NameProgrammableBlockScript) as IMyProgrammableBlock;
            if (Info.ProgramScript == null)
                return false;

            return true;
        }

        private void SetDefaultPrices()
        {
            //Wikia:
            //
            //
            SetLookup(Info.PriceLookup, "Cobalt", 0.5490000F);
            //SetLookup(Info.PriceLookup, "Cobalt Ore", 0.9000000F); //100 Cobalt Ore Gives 90.00 Cobalt ingots @ 300% Efficiency
            SetLookup(Info.PriceLookup, "Cobalt Ore", 0.5490000F); //100 Cobalt Ore Gives 54.90 Cobalt ingots 3.5 Yield 183% Effectiveness
            //SetLookup(Info.PriceLookup, "Cobalt Ore", 0.5045000F); //100 Cobalt Ore Gives 50.45 Cobalt ingots 3.0 Yield 168% Effectiveness
            //SetLookup(Info.PriceLookup, "Cobalt Ore", 0.4620000F); //100 Cobalt Ore Gives 46.20 Cobalt ingots 2.5 Yield
            //SetLookup(Info.PriceLookup, "Cobalt Ore", 0.4230000F); //100 Cobalt Ore Gives 42.30 Cobalt ingots 2.0 Yield
            //SetLookup(Info.PriceLookup, "Cobalt Ore", 0.3900000F); //100 Cobalt Ore Gives 39.00 Cobalt ingots 1.5 Yield
            //SetLookup(Info.PriceLookup, "Cobalt Ore", 0.3570000F); //100 Cobalt Ore Gives 35.70 Cobalt ingots 1.0 Yield
            //SetLookup(Info.PriceLookup, "Cobalt Ore", 0.3270000F); //100 Cobalt Ore Gives 32.70 Cobalt ingots 0.5 Yield
            //
            SetLookup(Info.PriceLookup, "Gold", 0.0183000F);
            //SetLookup(Info.PriceLookup, "Gold Ore", 0.0300000F); //100 Gold Ore Gives 3.00 Gold ingots @ 300% Efficiency
            SetLookup(Info.PriceLookup, "Gold Ore", 0.0183000F); //100 Gold Ore Gives 1.83 Gold ingots 3.5 Yield 183% Effectiveness
            //SetLookup(Info.PriceLookup, "Gold Ore", 0.0168000F); //100 Gold Ore Gives 1.68 Gold ingots 3.0 Yield 168% Effectiveness
            //SetLookup(Info.PriceLookup, "Gold Ore", 0.0154000F); //100 Gold Ore Gives 1.54 Gold ingots 2.5 Yield
            //SetLookup(Info.PriceLookup, "Gold Ore", 0.0141000F); //100 Gold Ore Gives 1.41 Gold ingots 2.0 Yield
            //SetLookup(Info.PriceLookup, "Gold Ore", 0.0130000F); //100 Gold Ore Gives 1.30 Gold ingots 1.5 Yield
            //SetLookup(Info.PriceLookup, "Gold Ore", 0.0191000F); //100 Gold Ore Gives 1.19 Gold ingots 1.0 Yield
            //SetLookup(Info.PriceLookup, "Gold Ore", 0.0109000F); //100 Gold Ore Gives 1.09 Gold ingots 0.5 Yield
            //
            SetLookup(Info.PriceLookup, "Iron", 1.2810000F);
            //SetLookup(Info.PriceLookup, "Iron Ore", 2.1007000F); //100 Iron Ore Gives 210.07 Iron ingots @ 300% Efficiency
            SetLookup(Info.PriceLookup, "Iron Ore", 1.2810000F); //100 Iron Ore Gives 128.10 Iron ingots 3.5 Yield 183% Effectiveness
            //SetLookup(Info.PriceLookup, "Iron Ore", 1.1773000F); //100 Iron Ore Gives 117.73 Iron ingots 3.0 Yield 168% Effectiveness
            //SetLookup(Info.PriceLookup, "Iron Ore", 1.0780000F); //100 Iron Ore Gives 107.80 Iron ingots 2.5 Yield
            //SetLookup(Info.PriceLookup, "Iron Ore", 0.9870000F); //100 Iron Ore Gives 98.70 Iron ingots 2.0 Yield
            //SetLookup(Info.PriceLookup, "Iron Ore", 0.9100000F); //100 Iron Ore Gives 91.00 Iron ingots 1.5 Yield
            //SetLookup(Info.PriceLookup, "Iron Ore", 0.8300000F); //100 Iron Ore Gives 83.30 Iron ingots 1.0 Yield
            //SetLookup(Info.PriceLookup, "Iron Ore", 0.7630000F); //100 Iron Ore Gives 76.30 Iron ingots 0.5 Yield
            //
            SetLookup(Info.PriceLookup, "Magnesium", 0.0128000F);
            //SetLookup(Info.PriceLookup, "Magnesium Ore", 0.0210000F); //100 Magnesium Ore Gives 2.10 Magnesium Powder @ 300% Efficiency
            SetLookup(Info.PriceLookup, "Magnesium Ore", 0.0128000F); //100 Magnesium Ore Gives 1.28 Magnesium 3.5 Yield 183% Effectiveness
            //SetLookup(Info.PriceLookup, "Magnesium Ore", 0.0118000F); //100 Magnesium Ore Gives 1.18 Magnesium 3.0 Yield 168% Effectiveness
            //SetLookup(Info.PriceLookup, "Magnesium Ore", 0.0000000F); //100 Magnesium Ore Gives 1.08 Magnesium 2.5 Yield
            //SetLookup(Info.PriceLookup, "Magnesium Ore", 0.0000000F); //100 Magnesium Ore Gives 0.99 Magnesium 2.0 Yield
            //SetLookup(Info.PriceLookup, "Magnesium Ore", 0.0000000F); //100 Magnesium Ore Gives 0.91 Magnesium 1.5 Yield
            //SetLookup(Info.PriceLookup, "Magnesium Ore", 0.0000000F); //100 Magnesium Ore Gives 0.83 Magnesium 1.0 Yield
            //SetLookup(Info.PriceLookup, "Magnesium Ore", 0.0000000F); //100 Magnesium Ore Gives 0.76 Magnesium 0.5 Yield
            //
            SetLookup(Info.PriceLookup, "Nickel", 0.7320000F);
            //SetLookup(Info.PriceLookup, "Nickel Ore", 1.2004000F); //100 Nickel Ore Gives 120.04 Nickel ingots @ 300% Efficiency
            SetLookup(Info.PriceLookup, "Nickel Ore", 0.7320000F); //100 Nickel Ore Gives 73.20 Nickel ingots 3.5 Yield 183% Effectiveness
            //SetLookup(Info.PriceLookup, "Nickel Ore", 0.6727000F); //100 Nickel Ore Gives 67.27 Nickel ingots 3.0 Yield 168% Effectiveness
            //SetLookup(Info.PriceLookup, "Nickel Ore", 0.0000000F); //100 Nickel Ore Gives 61.60 Nickel ingots 2.5 Yield
            //SetLookup(Info.PriceLookup, "Nickel Ore", 0.0000000F); //100 Nickel Ore Gives 56.40 Nickel ingots 2.0 Yield
            //SetLookup(Info.PriceLookup, "Nickel Ore", 0.0000000F); //100 Nickel Ore Gives 52.00 Nickel ingots 1.5 Yield
            //SetLookup(Info.PriceLookup, "Nickel Ore", 0.0000000F); //100 Nickel Ore Gives 47.60 Nickel ingots 1.0 Yield
            //SetLookup(Info.PriceLookup, "Nickel Ore", 0.0000000F); //100 Nickel Ore Gives 43.60 Nickel ingots 0.5 Yield
            //
            SetLookup(Info.PriceLookup, "Platinum", 0.0092000F);
            //SetLookup(Info.PriceLookup, "Platinum Ore", 0.0150000F); //100 Platinum Ore Gives 1.50 Platinum ingots @ 300% Efficiency
            SetLookup(Info.PriceLookup, "Platinum Ore", 0.0092000F); //100 Platinum Ore Gives 0.92 Platinum ingots 3.5 Yield 183% Effectiveness
            //SetLookup(Info.PriceLookup, "Platinum Ore", 0.0084000F); //100 Platinum Ore Gives 0.84 Platinum ingots 3.0 Yield 168% Effectiveness
            //SetLookup(Info.PriceLookup, "Platinum Ore", 0.0077000F); //100 Platinum Ore Gives 0.77 Platinum ingots 2.5 Yield
            //SetLookup(Info.PriceLookup, "Platinum Ore", 0.0071000F); //100 Platinum Ore Gives 0.71 Platinum ingots 2.0 Yield
            //SetLookup(Info.PriceLookup, "Platinum Ore", 0.0065000F); //100 Platinum Ore Gives 0.65 Platinum ingots 1.5 Yield
            //SetLookup(Info.PriceLookup, "Platinum Ore", 0.0059000F); //100 Platinum Ore Gives 0.59 Platinum ingots 1.0 Yield
            //SetLookup(Info.PriceLookup, "Platinum Ore", 0.0055000F); //100 Platinum Ore Gives 0.55 Platinum ingots 0.5 Yield
            //
            SetLookup(Info.PriceLookup, "Silicon", 1.2810000F);
            //SetLookup(Info.PriceLookup, "Silicon Ore", 2.1007000F); //100 Silicon Ore Gives 210.07 Silicon ingots @ 300% Efficiency
            SetLookup(Info.PriceLookup, "Silicon Ore", 1.2810000F); //100 Silicon Ore Gives 128.10 Silicon ingots 3.5 Yield 183% Effectiveness
            //SetLookup(Info.PriceLookup, "Silicon Ore", 1.1773000F); //100 Silicon Ore Gives 117.73 Silicon ingots 3.0 Yield 168% Effectiveness
            //SetLookup(Info.PriceLookup, "Silicon Ore", 0.0000000F); //100 Silicon Ore Gives 107.80 Silicon ingots 2.5 Yield
            //SetLookup(Info.PriceLookup, "Silicon Ore", 0.0000000F); //100 Silicon Ore Gives 98.70 Silicon ingots 2.0 Yield
            //SetLookup(Info.PriceLookup, "Silicon Ore", 0.0000000F); //100 Silicon Ore Gives 91.00 Silicon ingots 1.5 Yield
            //SetLookup(Info.PriceLookup, "Silicon Ore", 0.0000000F); //100 Silicon Ore Gives 91.00 Silicon ingots 1.0 Yield
            //SetLookup(Info.PriceLookup, "Silicon Ore", 0.0000000F); //100 Silicon Ore Gives 76.30 Silicon ingots 0.5 Yield
            //
            SetLookup(Info.PriceLookup, "Silver", 0.1830000F);
            //SetLookup(Info.PriceLookup, "Silver Ore", 0.3001000F); //100 Silver Ore Gives 30.01 Silver ingots @ 300% Efficiency
            SetLookup(Info.PriceLookup, "Silver Ore", 0.1830000F); //100 Silver Ore Gives 18.30 Silver ingots 3.5 Yield 183% Effectiveness
            //SetLookup(Info.PriceLookup, "Silver Ore", 0.1682000F); //100 Silver Ore Gives 16.82 Silver ingots 3.0 Yield 168% Effectiveness
            //SetLookup(Info.PriceLookup, "Silver Ore", 0.1540000F); //100 Silver Ore Gives 15.40 Silver ingots 2.5 Yield
            //SetLookup(Info.PriceLookup, "Silver Ore", 0.1410000F); //100 Silver Ore Gives 14.10 Silver ingots 2.0 Yield
            //SetLookup(Info.PriceLookup, "Silver Ore", 0.1300000F); //100 Silver Ore Gives 13.00 Silver ingots 1.5 Yield
            //SetLookup(Info.PriceLookup, "Silver Ore", 0.1190000F); //100 Silver Ore Gives 11.90 Silver ingots 1.0 Yield
            //SetLookup(Info.PriceLookup, "Silver Ore", 0.1090000F); //100 Silver Ore Gives 10.90 Silver ingots 0.5 Yield
            //
            SetLookup(Info.PriceLookup, "Thorium", 0.0073000F);
            //SetLookup(Info.PriceLookup, "Thorium Ore", 0.0120000F); //100 Thorium Ore Gives 1.2 Thorium ingots 300% Effectiveness
            SetLookup(Info.PriceLookup, "Thorium Ore", 0.0073000F); //100 Thorium Ore Gives 0.73 Thorium ingots 3.5 Yield 183% Effectiveness
            //SetLookup(Info.PriceLookup, "Thorium Ore", 0.0067000F); //100 Thorium Ore Gives 0.67 Thorium ingots 3.0 Yield 168% Effectiveness
            //SetLookup(Info.PriceLookup, "Thorium Ore", 0.0062000F); //100 Thorium Ore Gives 0.62 Thorium ingots 2.5 Yield
            //SetLookup(Info.PriceLookup, "Thorium Ore", 0.0057000F); //100 Thorium Ore Gives 0.57 Thorium ingots 2.0 Yield
            //SetLookup(Info.PriceLookup, "Thorium Ore", 0.0052000F); //100 Thorium Ore Gives 0.52 Thorium ingots 1.5 Yield
            //SetLookup(Info.PriceLookup, "Thorium Ore", 0.0048000F); //100 Thorium Ore Gives 0.48 Thorium ingots 1.0 Yield
            //SetLookup(Info.PriceLookup, "Thorium Ore", 0.0044000F); //100 Thorium Ore Gives 0.44 Thorium ingots 0.5 Yield
            //
            SetLookup(Info.PriceLookup, "Titanium", 0.0073000F);
	    //SetLookup(Info.PriceLookup, "Titanium Ore", 0.0120000F); //100 Titanium Ore Gives 1.2 Titanium ingots 300% Effectiveness
            SetLookup(Info.PriceLookup, "Titanium Ore", 0.0073000F); //100 Titanium Ore Gives 0.73 Titanium ingots 3.5 Yield 183% Effectiveness
            //SetLookup(Info.PriceLookup, "Titanium Ore", 0.0067000F); //100 Titanium Ore Gives 0.67 Titanium ingots 3.0 Yield 168% Effectiveness
            //SetLookup(Info.PriceLookup, "Titanium Ore", 0.0062000F); //100 Titanium Ore Gives 0.62 Titanium ingots 2.5 Yield
            //SetLookup(Info.PriceLookup, "Titanium Ore", 0.0057000F); //100 Titanium Ore Gives 0.57 Titanium ingots 2.0 Yield
            //SetLookup(Info.PriceLookup, "Titanium Ore", 0.0052000F); //100 Titanium Ore Gives 0.52 Titanium ingots 1.5 Yield
            //SetLookup(Info.PriceLookup, "Titanium Ore", 0.0048000F); //100 Titanium Ore Gives 0.48 Titanium ingots 1.0 Yield
            //SetLookup(Info.PriceLookup, "Titanium Ore", 0.0044000F); //100 Titanium Ore Gives 0.44 Titanium ingots 0.5 Yield
            //
            SetLookup(Info.PriceLookup, "Uranium", 0.0183000F); //1 Uranium costs 1 Uranium, currency resource
            //SetLookup(Info.PriceLookup, "Uranium Ore", 0.0300000F); //100 Uranium Ore Gives 3.00 Uranium ingots 300% Effectiveness
            SetLookup(Info.PriceLookup, "Uranium Ore", 0.0183000F); //100 Uranium Ore Gives 1.83 Uranium ingots 3.5 Yield 183% Effectiveness
            //SetLookup(Info.PriceLookup, "Uranium Ore", 0.0168000F); //100 Uranium Ore Gives 1.68 Uranium ingots 3.0 Yield 168% Effectiveness
            //SetLookup(Info.PriceLookup, "Uranium Ore", 0.0154000F); //100 Uranium Ore Gives 1.54 Uranium ingots 2.5 Yield
            //SetLookup(Info.PriceLookup, "Uranium Ore", 0.0141000F); //100 Uranium Ore Gives 1.41 Uranium ingots 2.0 Yield
            //SetLookup(Info.PriceLookup, "Uranium Ore", 0.0130000F); //100 Uranium Ore Gives 1.30 Uranium ingots 1.5 Yield
            //SetLookup(Info.PriceLookup, "Uranium Ore", 0.0111000F); //100 Uranium Ore Gives 1.11 Uranium ingots 1.0 Yield
            //SetLookup(Info.PriceLookup, "Uranium Ore", 0.0109000F); //100 Uranium Ore Gives 1.09 Uranium ingots 0.5 Yield
            //
            //
            Info.IsWeighable.Add("Gold");
            Info.IsWeighable.Add("Gold Ore");
            //
            Info.IsWeighable.Add("Cobalt");
            Info.IsWeighable.Add("Cobalt Ore");
            //
            Info.IsWeighable.Add("Iron");
            Info.IsWeighable.Add("Iron Ore");
            //
            Info.IsWeighable.Add("Magnesium");
            Info.IsWeighable.Add("Magnesium Ore");
            //
            Info.IsWeighable.Add("Nickel");
            Info.IsWeighable.Add("Nickel Ore");
            //
            Info.IsWeighable.Add("Platinum");
            Info.IsWeighable.Add("Platinum Ore");
            //
            Info.IsWeighable.Add("Silicon");
            Info.IsWeighable.Add("Silicon Ore");
            //
            Info.IsWeighable.Add("Silver");
            Info.IsWeighable.Add("Silver Ore");
            //
            Info.IsWeighable.Add("Thorium");
            Info.IsWeighable.Add("Thorium Ore");
            //
            Info.IsWeighable.Add("Titanium");
            Info.IsWeighable.Add("Titanium Ore");
            //
            Info.IsWeighable.Add("Uranium");
            Info.IsWeighable.Add("Uranium Ore");
            //
            //
            Info.RateTraderBuy = 1.00F; //trader buys from player at 100%
            Info.RateTraderSell = 1.00F; //trader sells to player at 100%
        }

        private bool Setup()
        {
            //Setup all the other blocks in the system

            //Price display
            Info.DisplayPrice = GridTerminalSystem.GetBlockWithName(Info.NameLCDDisplayPrice) as IMyTextPanel;
            if (Info.DisplayPrice == null)
            {
                Display(Info.MsgErrBlockNotFound, Info.NameLCDDisplayPrice, "");
                return false;
            }
            Info.DisplayPrice.Font = "Monospace";

            //Stock Display
            Info.StockPrice = GridTerminalSystem.GetBlockWithName(Info.NameLCDStock) as IMyTextPanel;
            if (Info.StockPrice == null)
            {
                Display(Info.MsgErrBlockNotFound, Info.NameLCDStock, "");
                return false;
            }
            Info.StockPrice.Font = "Monospace";

            //Player interacts with this cargo container
            Info.ContainerEntry = GridTerminalSystem.GetBlockWithName(Info.NameCargoContainerEntry) as IMyCargoContainer;
            if (Info.ContainerEntry == null)
            {
                Display(Info.MsgErrBlockNotFound, Info.NameCargoContainerEntry, "");
                return false;
            }

            //All the items the trading station has for offer stored in this cargo container
            Info.ContainerVault = GridTerminalSystem.GetBlockWithName(Info.NameCargoContainerVault) as IMyCargoContainer;
            if (Info.ContainerVault == null)
            {
                Display(Info.MsgErrBlockNotFound, Info.NameCargoContainerVault, "");
                return false;
            }

            //TradeOut
            Info.TradeOut = GridTerminalSystem.GetBlockWithName(Info.NameTradeOut) as IMyConveyorSorter;
            if (Info.TradeOut == null)
            {
                Display(Info.MsgErrBlockNotFound, "Info.NameTradeOut", "");
                return false;
            }

            //The inventory of the "Entry" cargo container
            Info.InventoryEntry = (Info.ContainerEntry as IMyEntity).GetInventory(0);
            if (Info.InventoryEntry == null)
            {
                Display(Info.MsgErrBlockHasNoInventory, Info.NameCargoContainerEntry, "");
                return false;
            }

            //The inventory of the "Vault" cargo container
            Info.InventoryVault = (Info.ContainerVault as IMyEntity).GetInventory(0);
            if (Info.InventoryVault == null)
            {
                Display(Info.MsgErrBlockHasNoInventory, Info.NameCargoContainerVault, "");
                return false;
            }

            return true;
        }

        private bool ApplyConfig(string paramType, string paramKey, string paramValue)
        {
            //Applies a single config. Separate becase called from two places as
            //it handles both custom data config and script parameters.
            bool fgSuccess = true;
            if (paramType == "Config")
            {
                switch (paramKey)
                {
                    case "Currency":
                        Info.ItemTypeCurrency = paramValue;
                        break;
                    case "CustomerDisplay":
                        Info.NameLCDDisplayCustomer = paramValue;
                        SetupDisplayCustomer(); //once we know this setup it immediately for possible error messages
                        break;
                    case "PriceDisplay":
                        Info.NameLCDDisplayPrice = paramValue;
                        break;
                    case "Entry":
                        Info.NameCargoContainerEntry = paramValue;
                        break;
                    case "BuyRate":
                        Info.RateTraderBuy = ParseFloat(paramValue);
                        break;
                    case "SellRate":
                        Info.RateTraderSell = ParseFloat(paramValue);
                        break;
                    case "Vault":
                        Info.NameCargoContainerVault = paramValue;
                        break;
                    case "Stock":
                        Info.NameLCDStock = paramValue;
                        break;
                    case "TradeOutSorter":
                        Info.NameTradeOut = paramValue;
                        break;
                    case "Welcome":
                        Info.MsgWelcome = paramValue.Replace("<BR>", System.Environment.NewLine);
                        break;
                    default:
                        Display(Info.MsgErrUnknownConfig, Info.NameProgrammableBlockScript, paramType + ":" + paramKey + "=" + paramValue);
                        fgSuccess = false;
                        break;
                }
            }
            else if (paramType == "Param")
            {
                switch (paramKey)
                {
                    case "Mode":
                        if (paramValue == MODE_BUY || paramValue == MODE_SELL || paramValue == MODE_WELCOME)
                            Info.Mode = paramValue;
                        else
                            Display(Info.MsgErrUnknownMode + ": " + paramValue);
                        break;
                    case "Script":
                        Info.NameProgrammableBlockScript = paramValue;
                        SetupProgramScript(); //once we know this setup it immediately as it contains the rest of the configs
                        break;
                    case "Target":
                        Info.ModeTarget = paramValue;
                        break;
                    default:
                        Display(Info.MsgErrUnknownParam, Info.NameProgrammableBlockScript, paramType + ":" + paramKey + "=" + paramValue);
                        fgSuccess = false;
                        break;
                }
            }
            else if (paramType == "Price")
            {
                //Custom trade item price
                float price = ParseFloat(paramValue);
                SetLookup(Info.PriceLookup, paramKey, price);
            }
            else if (paramType == "Weighable")
            {
                //Item type can be divided into chunks of 0.000001 units.
                if (paramValue == "1")
                    Info.IsWeighable.Add(paramKey);
                else
                    Info.IsWeighable.Remove(paramKey);
            }
            return fgSuccess;
        }

        private bool Configure()
        {
            //Reads the custom data from the programmable block to configure the system
            bool fgSuccess = true;
            char[] sepLine = { ';' };
            char[] sepPars = { ':', '=' };
            string configText = Info.ProgramScript.CustomData;
            string[] configLines = configText.Split(sepLine);
            string[] paramParts;
            string paramType;
            string paramKey;
            string paramValue;
            SetDefaultPrices();
            if (configLines != null)
            {
                int i;
                for (i = 0; i < configLines.Length; i++)
                {
                    paramParts = configLines[i].Split(sepPars);
                    if (paramParts.Length < 3)
                        continue;
                    paramType = paramParts[0].Trim();
                    paramKey = paramParts[1].Trim();
                    paramValue = paramParts[2].Trim();
                    if (!ApplyConfig(paramType, paramKey, paramValue))
                        fgSuccess = false;
                }
            }
            return fgSuccess;
        }


        //=======================================================================
        // INVENTORY MANAGEMENT METHODS

        private int IndexOfFirstTradeItem(IMyInventory container, string requiredType, bool verbose)
        {
            //Finds the first item in the given container that is of the given requiredType
            //and that can be traded i.e. that has a price. Give requiredType="Any" to match
            //any type except the currency resource type.
            //Returns its inventory index or -1 if none found.

            int ix = -1;

            List<MyInventoryItem> containerItems = GetInventoryItems(container);
            if (containerItems.Count > 0)
            {
                bool fgTypeMatches;
                int i;
                string itemType;
                for (i = 0; i < containerItems.Count; i++)
                {
                    itemType = GetItemType(containerItems[i]);
                    if (requiredType == itemType)
                        fgTypeMatches = true;
                    else if (requiredType == "Any" && itemType != Info.ItemTypeCurrency)
                        fgTypeMatches = true;
                    else
                        fgTypeMatches = false;
                    if (fgTypeMatches)
                    {
                        if (Info.PriceLookup.ContainsKey(itemType))
                        {
                            ix = i;
                            break;
                        }
                        else if (verbose)
                            Display(Info.MsgErrNotInterested, itemType, "");
                    }
                }
            }
            return ix;
        }

        private bool Transfer(IMyInventory source, IMyInventory destination, string itemType, VRage.MyFixedPoint amount)
        {
            //Moves given amount of given type from source to destination
            int ixSource;
            List<MyInventoryItem> sourceItems = GetInventoryItems(source);

            ixSource = IndexOfFirstTradeItem(source, itemType, false);
            if (ixSource < 0)
            {
                Display(Info.MsgErrTransferNoItemsInSource, itemType, source.ToString());
                return false;
            }

            MyInventoryItem item = sourceItems[ixSource];
            if (amount > item.Amount)
            {
                Display(Info.MsgErrTransferInsufficientItemsInSource, source.ToString(), item.Amount + "/" + amount.ToString() + " " + itemType);
                return false;
            }
//
    Info.TradeOut.Enabled=true;
            if (!source.TransferItemTo(destination, ixSource, null, true, amount))
            {
        Info.TradeOut.Enabled=false;
                Display(Info.MsgErrTransferFailed, amount.ToString() + " " + itemType, source.ToString() + " -> " + destination.ToString());
                return false;
            }
      Info.TradeOut.Enabled=false;
            return true;
//
        }


        //=======================================================================
        // TRADING METHODS

        private bool Buy(string requiredType)
        {
            //Player buys from the trader
            //Buys the first item in the vault cargo container that matches
            //the given type. The type "Any" can't be used.

            int ixTradeItem;
            int ixPaymentItem;
            List<MyInventoryItem> entryItems;
            List<MyInventoryItem> vaultItems;

            if (Info.ModeTarget == "Any")
            {
                Display(Info.MsgErrPurchaseNotSpecified);
                return false;
            }

            //Find the currency item the player is offering
            ixPaymentItem = IndexOfFirstTradeItem(Info.InventoryEntry, Info.ItemTypeCurrency, false);
            if (ixPaymentItem < 0)
            {
                Display(Info.MsgErrNoFunds + " (" + Info.ItemTypeCurrency + ")");
                return false;
            }

            //Fetch the currency item the player is offering
            entryItems = GetInventoryItems(Info.InventoryEntry);
            MyInventoryItem paymentItem = entryItems[ixPaymentItem];
            string paymentItemType = GetItemType(paymentItem);
            VRage.MyFixedPoint paymentItemAmount = paymentItem.Amount;
            Display(Info.MsgYouOffer + ": " + paymentItemAmount.ToString() + " " + paymentItemType);

            //Calculate the amount the player gets
            string tradeItemType = requiredType;
            VRage.MyFixedPoint tradeItemAmount = paymentItemAmount * (1.0F / Info.PriceLookup[tradeItemType]);
            if (!Info.IsWeighable.Contains(tradeItemType))
            {
                //If purchased item can't be divided adjust the amount to whole units and recalc the price
                tradeItemAmount = VRage.MyFixedPoint.Floor(tradeItemAmount);
                paymentItemAmount = tradeItemAmount * Info.PriceLookup[tradeItemType];
            }
            Display(Info.MsgThatBuys + ": " + tradeItemAmount.ToString() + " " + tradeItemType);

            //Find the item the player is buying
            ixTradeItem = IndexOfFirstTradeItem(Info.InventoryVault, tradeItemType, false);
            if (ixTradeItem < 0)
            {
                Display(Info.MsgErrInsufficientItems + "0 " + requiredType + ".");
                return false;
            }

            //Fetch the item the player purchased
            vaultItems = GetInventoryItems(Info.InventoryVault);
            MyInventoryItem tradeItem = vaultItems[ixTradeItem];
            tradeItemType = GetItemType(tradeItem);
            VRage.MyFixedPoint maxTradeItemAmount = tradeItem.Amount;

            if (tradeItemAmount > maxTradeItemAmount)
            {
                Display(Info.MsgErrInsufficientItems + maxTradeItemAmount.ToString() + " " + tradeItemType + ".");
                return false;
            }

            //Move the payment to the vault
            if (!Transfer(Info.InventoryEntry, Info.InventoryVault, paymentItemType, paymentItemAmount))
            {
                Display(Info.MsgErrTechnicalDifficulties + " " + Info.MsgErrPaymentNotReceived);
                return false;
            }
            Display(Info.MsgPayment + ": " + paymentItemAmount.ToString() + " " + paymentItemType);

            //Move the item to the "Entry" container
            if (!Transfer(Info.InventoryVault, Info.InventoryEntry, tradeItemType, tradeItemAmount))
            {
                //Moving the purchase failed so return the payment back to the player, if this fails then too bad...
                Display(Info.MsgErrTechnicalDifficulties + " " + Info.MsgErrItemsNotSent);
                Transfer(Info.InventoryVault, Info.InventoryEntry, paymentItemType, paymentItemAmount);
                return false;
            }
            Display(Info.MsgCollectYourItems);
            Display(Info.MsgTransactionEnds);

            return true;
        }

		private string mirrorType(string requiredType)
		{
			switch (requiredType)
			{
                case "Cobalt Ore":
                    return "Cobalt";
                case "Cobalt":
                    return "Cobalt Ore";

                case "Gold Ore":
                    return "Gold";
                case "Gold":
                    return "Gold Ore";

                case "Iron Ore":
                    return "Iron";
                case "Iron":
                    return "Iron Ore";

                case "Magnesium Ore":
                    return "Magnesium";
                case "Magnesium":
                    return "Magnesium Ore";

                case "Nickel Ore":
                    return "Nickel";
                case "Nickel":
                    return "Nickel Ore";

                case "Platinum Ore":
                    return "Platinum";
                case "Platinum":
                    return "Platinum Ore";

                case "Silicon Ore":
                    return "Silicon";
                case "Silicon":
                    return "Silicon Ore";

                case "Silver Ore":
                    return "Silver";
                case "Silver":
                    return "Silver Ore";

                case "Thorium Ore":
                    return "Thorium";
                case "Thorium":
                    return "Thorium Ore";

                case "Titanium Ore":
                    return "Titanium";
                case "Titanium":
                    return "Titanium Ore";

                case "Uranium Ore":
                    return "Uranium";
                case "Uranium":
                    return "Uranium Ore";

                default:
                    Display("Trade not Accepted, Contact ColdStranger");
                    break;
			}
            return "";
		}

        private bool Sell(string requiredType)
        {
            //Player sells to the trader
            //Sells the first item in the "Entry" cargo container that matches
            //the given type. Use "Any" to match any type (that has a price).

            int ixTradeItem;
            int ixPaymentItem;
            List<MyInventoryItem> entryItems;
            List<MyInventoryItem> vaultItems;

            //Find the item the player is selling
            ixTradeItem = IndexOfFirstTradeItem(Info.InventoryEntry, requiredType, true);
            if (ixTradeItem < 0)
            {
                Display(Info.MsgErrNoTradeItems);
                return false;
            }

            //Fetch the item the player sells
            entryItems = GetInventoryItems(Info.InventoryEntry);
            MyInventoryItem tradeItem = entryItems[ixTradeItem];
            string tradeItemType = GetItemType(tradeItem);
            VRage.MyFixedPoint tradeItemAmount = tradeItem.Amount;
            Display(Info.MsgYouOffer + ": " + tradeItemAmount.ToString() + " " + tradeItemType);

            //Calculate the payment
            float price = Info.PriceLookup[tradeItemType] * Info.RateTraderBuy * Info.RateTraderSell;
            VRage.MyFixedPoint paymentItemAmount = tradeItemAmount * price;
			Info.ItemTypeCurrency = mirrorType(tradeItemType);

            Display(Info.MsgWePay + ": " + paymentItemAmount.ToString() + " " + Info.ItemTypeCurrency);

            //Find the payment item in the vault
            ixPaymentItem = IndexOfFirstTradeItem(Info.InventoryVault, Info.ItemTypeCurrency, false);
            if (ixPaymentItem < 0)
            {
                Display(Info.MsgErrInsufficientFunds + "0 " + Info.ItemTypeCurrency + ".");
                return false;
            }

            //Fetch the payment item in the vault
            vaultItems = GetInventoryItems(Info.InventoryVault);
            MyInventoryItem paymentItem = vaultItems[ixPaymentItem];
            string paymentItemType = GetItemType(paymentItem);
            VRage.MyFixedPoint maxPaymentItemAmount = paymentItem.Amount;

            if (paymentItemAmount > maxPaymentItemAmount)
            {
                Display(Info.MsgErrInsufficientFunds + maxPaymentItemAmount.ToString() + " " + paymentItemType + ".");
                return false;
            }

            //Move the player's item to vault
            if (!Transfer(Info.InventoryEntry, Info.InventoryVault, tradeItemType, tradeItemAmount))
            {
                Display(Info.MsgErrTechnicalDifficulties + " " + Info.MsgErrItemsNotReceived);
                return false;
            }

            //Pay the player
            if (!Transfer(Info.InventoryVault, Info.InventoryEntry, paymentItemType, paymentItemAmount))
            {
                //Payment failed so return the trade item back to the player, if this fails then too bad...
                Display(Info.MsgErrTechnicalDifficulties + " " + Info.MsgErrPaymentNotSent);
                Transfer(Info.InventoryVault, Info.InventoryEntry, tradeItemType, tradeItemAmount);
                return false;
            }
            Display(Info.MsgCollectYourPayment);
            Display(Info.MsgTransactionEnds);

            return true;
        }


        //=======================================================================
        // MAIN ENTRY POINT FOR SCRIPT

        public void Main(string args)
        {
            // The main entry point of the script, invoked every time
            // one of the programmable block's Run actions are invoked.

            char[] sepArgs = { ',' };
            string[] listArgs = args.Split(sepArgs);

            //1st argument is the name of the programmable block that runs this script
            if (listArgs.Length > 0)
                ApplyConfig("Param", "Script", listArgs[0]);

            //Now we know the programmable block, read its config and setup the system
            //If fails then just abort as there's nothing that can be done
            if (!Configure())
                return;
            if (!Setup())
                return;

            //2nd argument is the mode: "Buy", "Sell", or "Welcome"
            if (listArgs.Length > 1)
                ApplyConfig("Param", "Mode", listArgs[1]);

            //3rd argument is the mode target
            if (listArgs.Length > 2)
                ApplyConfig("Param", "Target", listArgs[2]);

            //Clear the customer screen
            Display("", false);

            //Write price list
            ShowPrices();

            switch (Info.Mode)
            {
                case MODE_BUY:
                    Buy(Info.ModeTarget);
                    break;
                case MODE_SELL:
                    Sell(Info.ModeTarget);
                    break;
                case MODE_WELCOME:
                    Display(Info.MsgWelcome, false);
                    ShowStock();
                    break;
                default:
                    Display(Info.MsgErrUnknownMode + ": " + Info.Mode + "='" + Info.ModeTarget + "'");
                    break;
            }
        }


        //=======================================================================
        // SAVE PERSISTENT DATA

        public void Save()
        {
            // Called when the program needs to save its state. Use
            // this method to save your state to the Storage field
            // or some other means.

            // This method is optional and can be removed if not
            // needed.
        }

        //=======================================================================
        //////////////////////////END////////////////////////////////////////////
        //=======================================================================
