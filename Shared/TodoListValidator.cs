using FluentValidation;

namespace PurchaseNexus.Shared;

public class TodoListValidator : AbstractValidator<TodoList>
{
    public TodoListValidator()
    {
        RuleFor(p => p.Title)
            .NotEmpty();
    }
}
