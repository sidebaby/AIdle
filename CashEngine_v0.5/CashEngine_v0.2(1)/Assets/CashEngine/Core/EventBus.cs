using System;
using System.Collections.Generic;
namespace CashEngine.Core{
public interface IEvent{}
public class EventBus{
private readonly Dictionary<Type,List<Delegate>> _subs=new();
public void Subscribe<T>(Action<T> cb) where T:IEvent{var t=typeof(T);if(!_subs.ContainsKey(t))_subs[t]=new();_subs[t].Add(cb);}
public void Unsubscribe<T>(Action<T> cb) where T:IEvent{if(_subs.TryGetValue(typeof(T),out var l))l.Remove(cb);}
public void Publish<T>(T evt) where T:IEvent{if(_subs.TryGetValue(typeof(T),out var l))foreach(var d in l.ToArray())((Action<T>)d)(evt);}
}}