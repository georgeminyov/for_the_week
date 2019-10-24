using System;

namespace ConsoleApp65
{
    class Program
    {
       
            static void Main(string[] args)
            {
                string sushiType = Console.ReadLine();
                string restorant = Console.ReadLine();
                int portions = int.Parse(Console.ReadLine());
                char online = char.Parse(Console.ReadLine());
                double total = 0;
                double price = 0;

                switch (restorant)
                {
                    case "Sushi Zone":
                        switch (sushiType)
                        {
                            case "sashimi":
                                price = 4.99;
                                break;
                            case "maki":
                                price = 5.29;
                                break;
                            case "uramaki":
                                price = 5.99;
                                break;
                            case "temaki":
                                price = 4.29;
                                break;
                            default:
                                break;
                        }
                        break;
                    case "Sushi Time":
                        switch (sushiType)
                        {
                            case "sashimi":
                                price = 5.49;
                                break;
                            case "maki":
                                price = 4.69;
                                break;
                            case "uramaki":
                                price = 4.49;
                                break;
                            case "temaki":
                                price = 5.19;
                                break;
                            default:
                                break;
                        }
                        break;
                    case "Sushi Bar":
                        switch (sushiType)
                        {
                            case "sashimi":
                                price = 5.25;
                                break;
                            case "maki":
                                price = 5.55;
                                break;
                            case "uramaki":
                                price = 6.25;
                                break;
                            case "temaki":
                                price = 4.75;
                                break;
                            default:
                                break;
                        }
                        break;
                    case "Asian Pub":
                        switch (sushiType)
                        {
                            case "sashimi":
                                price = 4.50;
                                break;
                            case "maki":
                                price = 4.80;
                                break;
                            case "uramaki":
                                price = 5.50;
                                break;
                            case "temaki":
                                price = 5.50;
                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        break;
                }

                if (restorant == "Sushi Zone" || restorant == "Sushi Time" || restorant == "Sushi Bar" || restorant == "Asian Pub")
                {
                    if (sushiType == "sashimi")
                    {
                        total = portions * price;
                    }
                    else if (sushiType == "maki")
                    {
                        total = portions * price;
                    }
                    else if (sushiType == "uramaki")
                    {
                        total = portions * price;
                    }
                    else if (sushiType == "temaki")
                    {
                        total = portions * price;
                    }
                    if (online == 'Y')
                    {
                        total = total * 0.20 + total;
                    }
                    Console.WriteLine($"Total price: {Math.Ceiling(total)} lv.");
                }
                else
                {
                    Console.WriteLine($"{restorant} is invalid restaurant!");
                }
            }
        

    }
