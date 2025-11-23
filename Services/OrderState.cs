namespace BlazingPizza.Services;

public class OrderState
{
    public bool ShowingConfigureDialog { get; private set; }
    public Pizza ConfiguringPizza { get; private set; }
    public Order Order { get; private set; } = new Order();

    //Show Dialog when pizza selected
    public void ShowConfigurePizzaDialog(PizzaSpecial special)
    {
        ConfiguringPizza = new Pizza()
        {
            Special = special,
            SpecialId = special.Id,
            Size = Pizza.DefaultSize,
            Toppings = new List<PizzaTopping>(),
        };

        ShowingConfigureDialog = true;
    }

    //Cancel Confirm Add to order
    public void CancelConfigurePizzaDialog()
    {
        ConfiguringPizza = null;

        ShowingConfigureDialog = false;
    }

    //Confirm add to Order
    public void ConfirmConfigurePizzaDialog()
    {
        Order.Pizzas.Add(ConfiguringPizza);
        ConfiguringPizza = null;

        ShowingConfigureDialog = false;
    }

    //Remove Pizza from Order List
    public void RemoveConfiguredPizza(Pizza pizza)
    {
        Order.Pizzas.Remove(pizza);
    }

    //Reset Order List
    public void ResetOrder()
    {
        Order = new Order();
    }
}