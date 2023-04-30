# PersonApi
### Данный проект имеет своей целью быть учебным для оттачивания навыков по созданию приложений с многослойной гексагональной архитектурой.
- Также проработка навыков по созданию REST Api с использованием паттерна Repository и UnitOfWork.
- Реадизация собственного деструктора (Finalizer)/
- Проект реализован как консольное приложение.
- Реализуется механизм сериализации класса и дессериализации обратно и вывода информации на консоль:
```c#
  public  IEnumerable<PersonDTO> ReadFromFile()
        {
            string folderPath = $"{Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)}\\Persons.json";

            using (FileStream fs = new FileStream(folderPath, FileMode.OpenOrCreate))
            {

                try
                {
                    IEnumerable<PersonDTO> personDTOs = JsonSerializer.Deserialize<IEnumerable<PersonDTO>>(fs);

                    return personDTOs;
                }
                catch(JsonException jsex)
                {
                    return Enumerable.Empty<PersonDTO>();
                }
            }
        }
```
