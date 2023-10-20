﻿using Blau.Entities;

using Ookly.Core.CategoryAggregate;

namespace Ookly.Core.AdAggregate;

public class Ad(string title, string description, int categoryId) : Entity, IAggregateRoot
{
    public string Title { get; private set; } = title;
    public string Description { get; private set; } = description;

    public int CategoryId { get; private set; } = categoryId;
    public Category Category { get; private set; } = default!;
}
