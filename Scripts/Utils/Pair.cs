namespace RichUnity.Utils {
    public class Pair<K, V> {
        public Pair() {
        }

        public Pair(K key, V value) {
            Key = key;
            Value = value;
        }

        public K Key { get; set; }
        public V Value { get; set; }
    };
}