namespace GenericMapper
{
    internal class GenericMapper<T, U> where U : class
                                       where T : class
    {
        private readonly List<Tuple<T, U>> _items = new List<Tuple<T, U>>();

        /// <summary>
        /// Retourne un U à partir d'un T
        /// </summary>
        /// <param name="t">T à chercher</param>
        /// <returns>U, null si pas trouvé</returns>
        public U? GetU(T t)
        {
            var tuple = _items.Find(tu => ReferenceEquals(t, tu.Item1));
            if (tuple == null)
            {
                return null;
            }
            return tuple.Item2;
        }

        /// <summary>
        /// Retourne un T à partir d'un U
        /// </summary>
        /// <param name="t">U à chercher</param>
        /// <returns>T, null si pas trouvé</returns>
        public T? GetT(U u)
        {
            var tuple = _items.Find(tu => ReferenceEquals(u, tu.Item2));
            if (tuple == null)
            {
                return null;
            }
            return tuple.Item1;
        }

        /// <summary>
        /// Ajoute un couple de U/T
        /// </summary>
        /// <param name="u">U à ajouter</param>
        /// <param name="t">T à ajouter</param>
        /// <returns>Si au moins un des éléments est déjà présent</returns>
        public bool Add(U u, T t)
        {
            if (GetU(t) != null || GetT(u) != null)
            {
                return false;
            }
            var tuple = new Tuple<T, U>(t, u);
            _items.Add(tuple);
            return _items.Contains(tuple);
        }

        /// <summary>
        /// Reset tout les couples du mapper
        /// </summary>
        public void Reset()
        {
            _items.Clear();
        }
    }
}
