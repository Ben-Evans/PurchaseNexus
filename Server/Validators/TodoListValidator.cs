﻿namespace PurchaseNexus.Server.Validators;

public class TodoListValidator : Shared.Validators.TodoListValidator
{
    private readonly ApplicationDbContext _context;

    public TodoListValidator(ApplicationDbContext context) : base()
    {
        _context = context;

        RuleFor(v => v.Name)
            .MustAsync(BeUniqueName)
                .WithMessage("'Title' must be unique.");
    }

    public async Task<bool> BeUniqueName(TodoList list, string name, CancellationToken cancellationToken)
    {
        return await _context.TodoLists
            .Where(tl => tl.Id != list.Id)
            .AllAsync(tl => tl.Name != name, cancellationToken);
    }
}
