using System;using System.Collections.Generic;
namespace CashEngine.Core{public static class ServiceRegistry{static readonly Dictionary<Type,object> s=new();
public static void Register<T>(T svc) where T:class=>s[typeof(T)]=svc;
public static bool TryGet<T>(out T service) where T:class{if(s.TryGetValue(typeof(T),out var o)){service=(T)o;return true;}service=null;return false;}
public static T Get<T>() where T:class=>TryGet<T>(out var s)?s:throw new InvalidOperationException();}}