namespace PurchaseNexus.Shared.Validators;

public class TodoListValidator : AbstractValidator<TodoList>
{
    public TodoListValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty();
    }
}
