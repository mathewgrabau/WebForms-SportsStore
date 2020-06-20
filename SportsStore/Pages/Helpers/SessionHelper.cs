using SportsStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace SportsStore.Pages.Helpers
{
    public enum SessionKey
    {
        CART,
        RETURN_URL
    }

    // TODO make this an extension method for fun.
    public static class SessionHelper
    {
        public static void Set(HttpSessionState session, SessionKey key, object value)
        {
            session[Enum.GetName(typeof(SessionKey), key)] = value;
        }

        public static T Get<T>(HttpSessionState session, SessionKey key)
        {
            object dataValue = session[Enum.GetName(typeof(SessionKey), key)];
            if (dataValue != null && dataValue is T)
            {
                return (T)dataValue;
            }
            else
            {
                return default(T);
            }
        }

        public static Cart GetCart(HttpSessionState session)
        {
            Cart currentCart = Get<Cart>(session, SessionKey.CART);
            if (currentCart == null)
            {
                currentCart = new Cart();
                Set(session, SessionKey.CART, currentCart);
            }

            return currentCart;
        }
    }
}