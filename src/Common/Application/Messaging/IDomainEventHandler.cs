﻿using Domain.Events;
using MediatR;

namespace Application.Messaging;

public interface IDomainEventHandler<in TEvent> : INotificationHandler<TEvent> 
    where TEvent : IDomainEvent
{ }
