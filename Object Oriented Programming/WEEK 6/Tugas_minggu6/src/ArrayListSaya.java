public class ArrayListSaya<T> {
    Data<T>[] daftar;
    int size;
    int capacity;

    @SuppressWarnings("unchecked")
    public ArrayListSaya() {
        this.capacity = 1000000;
        this.size = 0;
        this.daftar = new Data[capacity];
    }

    void add(T data) {
        daftar[size] = new Data<T>(size, data); 
        size++;
    }

    void add(int index, T data) {
        if (index < 0 || index > size) {
            System.out.println("Index out of bounds: " + index);
            return;
        }

        for (int i = size; i > index; i--) {
            daftar[i] = daftar[i - 1]; // shift objects
            daftar[i].id = i;          // update ids
        }

        daftar[index] = new Data<T>(index, data);
        size++;

        // update IDs after insertion
        for (int i = index + 1; i < size; i++) {
            daftar[i].id = i;
        }
    }

    void remove(int index) {
        if (index < 0 || index >= size) {
            System.out.println("Index out of bounds: " + index);
            return;
        }

        for (int i = index; i < size - 1; i++) {
            daftar[i] = daftar[i + 1];
            daftar[i].id = i;
        }
        daftar[size - 1] = null;
        size--;
    }

    void remove(T data) {
        for (int i = 0; i < size; i++) {
            if (daftar[i].data.equals(data)) {
                remove(i);
                return;
            }
        }
    }

    T get(int index) {
        if (index < 0 || index >= size) {
            System.out.println("Index out of bounds: " + index);
            return null;
        }
        return daftar[index].data;
    }

    void set(int index, T data) {
        if (index < 0 || index >= size) {
            System.out.println("Index out of bounds: " + index);
            return;
        }
        daftar[index].data = data;
    }

    boolean contains(T data) {
        for (int i = 0; i < size; i++) {
            if (daftar[i].data.equals(data)) {
                return true;
            }
        }
        return false;
    }

    boolean isEmpty() {
        return size == 0;
    }

    void clear() {
        for (int i = 0; i < size; i++) {
            daftar[i] = null;
        }
        size = 0;
    }

    int size() {
        return size;
    }
    
    void print() {
        for (int i = 0; i < size; i++) {
            System.out.println(daftar[i].id + " - " + daftar[i].data);
        }
        System.out.println("=================================================");
    }
}
