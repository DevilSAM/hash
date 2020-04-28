# visualization of hash
from random import randint
from time import sleep

# массив, в который будем записывать значения
arr = ['x' for i in range(10)]

# наша хеш-функция
def myHash(num):
    return num % 7

# функция вставки элемента в наш массив
def insert_to_arr(num):
    # вычисляем хеш и это будет нашим индексом
    idx = myHash(num)
    # проверим не заполнен ли массив
    # 'x' - пустое местo в массиве, 'o' - ячейка удаленного элемента из цепочки
    if ('x' or 'o') not in arr:
        print('Array is full')
        return
    # проверяем не случилось ли коллизии
    if arr[idx] == 'x':
        arr[idx] = num
    else:
        # если элемент уже в той ячейке есть, то идем дальше до конца массива и ищем первое пустое место
        for i in range(idx + 1, len(arr)):
            if arr[i] == 'x' or arr[i] == 'o':
                arr[i] = num
                return
        # если дошли до конца и не нашли пустого места, то начинаем проход с начала массива до того места, откуда начинали
        for i in range(idx):
            if arr[i] == 'x' or arr[i] == 'o':
                arr[i] = num
                return

# функция удаления элемента из массива
def delete_from_arr(num):
    idx = myHash(num)
    if arr[idx] == 'x':
        print('NO ELEMENT')
        return
    else:
        # если там стоит это число
        if arr[idx] == num:
            # теперь нужно проверить не стоит ли за ним другое число, чтобы не разбить чепочку кластера
            # и нужно предусмотреть границу массива, чтобы не выпасть за его пределы
            if idx < len(arr) -1:
                # если следующий эл-т не пустой, то ставим наш маркер ('o'), для сохранения цепочки
                arr[idx] = 'x' if arr[idx+1] == 'x' else 'o'
                print('Элемент найден. Удаляем!')
                return
            else:
                # это случай для проверки последнего элемента в массиве. Тут нужно смотреть на первый элемент
                arr[idx] = 'x' if arr[0] == 'x' else 'o'
                print('Элемент ПРЕДПОСЛЕДНИЙ. Удаляем!')
                return
        # теперь ветка если мы попали на другое число или маркер ('o')
        else:
            # идем вправо по цепочки до тех пор, пока не найдем этот элемент или пустую ячейку
            for i in range(idx +1, len(arr)-1):
                if arr[i] == 'x':
                    print('Отсюда и вправо НЕТ ЭЛЕМЕНТА')
                    return
                elif arr[i] == num:
                    arr[i] = 'x' if arr[i+1] == 'x' else 'o'
                    print('УДАЛЕН где-то справа')
                    return
            # если return не сработал, то нужно проверить последний элемент
            if arr[-1] == 'x':
                print('ПОСЛЕДНИЙ тоже не он!')
                return
            elif arr[-1] == num:
                arr[-1] = 'x' if arr[0] == 'x' else 'o'
                print('Это Последний элемент БЫЛ!')
                return
            # проверили все элементы вправо. Теперь надо проверить элементы слева 
            for i in range(idx):
                if arr[i] == 'x':
                    print('Нет элемента и СЛЕВА')
                    return
                elif arr[i] == num:
                    arr[i] = 'x' if arr[i+1] == 'x' else 'o'
                    print('Удален ГДЕ_ТО слеа')
                    return
        # Мы все проверили. Значит тут этого жлемента нет!
        print('ТАКОГО ЭЛЕМЕНТА ТОЧНО НЕТ')
        return




# тестируем на рандмных числах
for i in range(7):
    x = randint(0, 20)
    print('x = {}, hash(x) = {}'.format(x, myHash(x)))
    insert_to_arr(x)

# смотрим, что получилось
print(arr)

# тестируем на рандмных числах
for i in range(7):
    x = randint(0, 20)
    print('el = {}  (idx={})'.format(x, myHash(x)))
    delete_from_arr(x)

print(arr)