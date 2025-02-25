namespace calcSystem
{
    public partial class Form1 : Form
    {
        private Label titleLabel;

        // Элементы для таблицы Products
        private Label productNameLabel;
        private TextBox productNameTextBox;
        private Label productDescriptionLabel;
        private TextBox productDescriptionTextBox;
        private Button saveProductButton;

        // Элементы для таблицы Materials
        private Label materialNameLabel;
        private TextBox materialNameTextBox;
        private Label materialUnitLabel;
        private TextBox materialUnitTextBox;
        private Label materialCostLabel;
        private TextBox materialCostTextBox;
        private Button saveMaterialButton;

        // Элементы для таблицы Operations
        private Label operationNameLabel;
        private TextBox operationNameTextBox;
        private Label operationCostLabel;
        private TextBox operationCostTextBox;
        private Button saveOperationButton;

        // Элементы для таблицы Employees
        private Label employeeNameLabel;
        private TextBox employeeNameTextBox;
        private Label employeePositionLabel;
        private TextBox employeePositionTextBox;
        private Label employeeSalaryLabel;
        private TextBox employeeSalaryTextBox;
        private Button saveEmployeeButton;

        // Элементы для таблицы Expenses
        private Label expenseCategoryLabel;
        private TextBox expenseCategoryTextBox;
        private Label expenseAmountLabel;
        private TextBox expenseAmountTextBox;
        private Label expenseDateLabel;
        private DateTimePicker expenseDatePicker;
        private Button saveExpenseButton;

        // Новая кнопка для расчета стоимости
        private Button calculateCostButton;

        // Метка для вывода результата
        private Label resultLabel;
        private DatabaseHelper dbHelper;

        // Метка полной стоимости
        private Label totalCostLabel;

        public Form1()
        {
            InitializeComponent();
            InitializeCustomComponents();
            this.WindowState = FormWindowState.Maximized; // Устанавливаем форму в максимизированное состояние
            dbHelper = new DatabaseHelper("Server=localhost\\SQLEXPRESS;Database=calcSystem;Trusted_Connection=True;");           
        }

        private void InitializeCustomComponents()
        {
            // Настройки формы
            this.Text = "Калькуляция себестоимости";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = System.Drawing.Color.White;

            // Заголовок
            titleLabel = new Label
            {
                Text = "Калькуляция себестоимости продукции",
                Font = new System.Drawing.Font("Segoe UI", 16, System.Drawing.FontStyle.Bold),
                Location = new System.Drawing.Point(30, 20),
                AutoSize = true
            };

            // Элементы для Products
            productNameLabel = new Label { Text = "Название продукта:", Location = new System.Drawing.Point(30, 70), AutoSize = true };
            productNameTextBox = new TextBox { Location = new System.Drawing.Point(200, 65), Width = 250 };

            productDescriptionLabel = new Label { Text = "Описание продукта:", Location = new System.Drawing.Point(30, 110), AutoSize = true };
            productDescriptionTextBox = new TextBox { Location = new System.Drawing.Point(200, 105), Width = 250, Multiline = true, Height = 60 };

            // Кнопка для сохранения продукта
            saveProductButton = new Button
            {
                Text = "Записать данные",
                Location = new System.Drawing.Point(460, 65),
                Width = 150, // Увеличенная ширина кнопки
                BackColor = System.Drawing.Color.LightGreen
            };
            saveProductButton.Click += new EventHandler(SaveProductButton_Click);

            // Элементы для Materials
            materialNameLabel = new Label { Text = "Название материала:", Location = new System.Drawing.Point(30, 180), AutoSize = true };
            materialNameTextBox = new TextBox { Location = new System.Drawing.Point(200, 175), Width = 250 };

            materialUnitLabel = new Label { Text = "Единица измерения:", Location = new System.Drawing.Point(30, 220), AutoSize = true };
            materialUnitTextBox = new TextBox { Location = new System.Drawing.Point(200, 215), Width = 250 };

            materialCostLabel = new Label { Text = "Стоимость за единицу:", Location = new System.Drawing.Point(30, 260), AutoSize = true };
            materialCostTextBox = new TextBox { Location = new System.Drawing.Point(200, 255), Width = 250 };
            materialCostTextBox.Text = "0"; // Устанавливаем значение по умолчанию

            // Кнопка для сохранения материала
            saveMaterialButton = new Button
            {
                Text = "Записать данные",
                Location = new System.Drawing.Point(460, 215),
                Width = 150, // Увеличенная ширина кнопки
                BackColor = System.Drawing.Color.LightGreen
            };
            saveMaterialButton.Click += new EventHandler(SaveMaterialButton_Click);

            // Элементы для Operations
            operationNameLabel = new Label { Text = "Название операции:", Location = new System.Drawing.Point(30, 300), AutoSize = true };
            operationNameTextBox = new TextBox { Location = new System.Drawing.Point(200, 295), Width = 250 };

            operationCostLabel = new Label { Text = "Стоимость операции:", Location = new System.Drawing.Point(30, 340), AutoSize = true };
            operationCostTextBox = new TextBox { Location = new System.Drawing.Point(200, 335), Width = 250 };
            operationCostTextBox.Text = "0"; // Устанавливаем значение по умолчанию

            // Кнопка для сохранения операции
            saveOperationButton = new Button
            {
                Text = "Записать данные",
                Location = new System.Drawing.Point(460, 335),
                Width = 150, // Увеличенная ширина кнопки
                BackColor = System.Drawing.Color.LightGreen
            };
            saveOperationButton.Click += new EventHandler(SaveOperationButton_Click);

            // Элементы для Employees
            employeeNameLabel = new Label { Text = "ФИО сотрудника:", Location = new System.Drawing.Point(30, 380), AutoSize = true };
            employeeNameTextBox = new TextBox { Location = new System.Drawing.Point(200, 375), Width = 250 };

            employeePositionLabel = new Label { Text = "Должность:", Location = new System.Drawing.Point(30, 420), AutoSize = true };
            employeePositionTextBox = new TextBox { Location = new System.Drawing.Point(200, 415), Width = 250 };

            employeeSalaryLabel = new Label { Text = "Зарплата:", Location = new System.Drawing.Point(30, 460), AutoSize = true };
            employeeSalaryTextBox = new TextBox { Location = new System.Drawing.Point(200, 455), Width = 250 };
            employeeSalaryTextBox.Text = "0"; // Устанавливаем значение по умолчанию

            // Кнопка для сохранения сотрудника
            saveEmployeeButton = new Button
            {
                Text = "Записать данные",
                Location = new System.Drawing.Point(460, 455),
                Width = 150, // Увеличенная ширина кнопки
                BackColor = System.Drawing.Color.LightGreen
            };
            saveEmployeeButton.Click += new EventHandler(SaveEmployeeButton_Click);

            // Элементы для Expenses
            expenseCategoryLabel = new Label { Text = "Категория расхода:", Location = new System.Drawing.Point(30, 500), AutoSize = true };
            expenseCategoryTextBox = new TextBox { Location = new System.Drawing.Point(200, 495), Width = 250 };

            expenseAmountLabel = new Label { Text = "Сумма:", Location = new System.Drawing.Point(30, 540), AutoSize = true };
            expenseAmountTextBox = new TextBox { Location = new System.Drawing.Point(200, 535), Width = 250 };
            expenseAmountTextBox.Text = "0"; // Устанавливаем значение по умолчанию

            expenseDateLabel = new Label { Text = "Дата расхода:", Location = new System.Drawing.Point(30, 580), AutoSize = true };
            expenseDatePicker = new DateTimePicker { Location = new System.Drawing.Point(200, 575), Width = 250 };                       

            // Кнопка для сохранения расхода
            saveExpenseButton = new Button
            {
                Text = "Записать данные",
                Location = new System.Drawing.Point(460, 575),
                Width = 150, // Увеличенная ширина кнопки
                BackColor = System.Drawing.Color.LightGreen
            };
            saveExpenseButton.Click += new EventHandler(SaveExpenseButton_Click);

            // Кнопка для расчета стоимости
            calculateCostButton = new Button
            {
                Text = "Рассчитать стоимость",
                Location = new System.Drawing.Point(30, 620), // Под всеми остальными кнопками
                Width = 250, // Ширина кнопки
                BackColor = System.Drawing.Color.LightBlue
            };
            calculateCostButton.Click += new EventHandler(CalculateCostButton_Click);

            // Метка для вывода результата
            resultLabel = new Label
            {
                Location = new System.Drawing.Point(30, 660),
                AutoSize = true,
                ForeColor = System.Drawing.Color.Green
            };

            // Метка для вывода общей стоимости
            totalCostLabel = new Label { Text = "Общая стоимость: ", Location = new System.Drawing.Point(30, 690), AutoSize = true };

            // Добавляем элементы управления на форму
            this.Controls.Add(titleLabel);
            this.Controls.Add(productNameLabel);
            this.Controls.Add(productNameTextBox);
            this.Controls.Add(productDescriptionLabel);
            this.Controls.Add(productDescriptionTextBox);
            this.Controls.Add(saveProductButton);
            this.Controls.Add(materialNameLabel);
            this.Controls.Add(materialNameTextBox);
            this.Controls.Add(materialUnitLabel);
            this.Controls.Add(materialUnitTextBox);
            this.Controls.Add(materialCostLabel);
            this.Controls.Add(materialCostTextBox);
            this.Controls.Add(saveMaterialButton);
            this.Controls.Add(operationNameLabel);
            this.Controls.Add(operationNameTextBox);
            this.Controls.Add(operationCostLabel);
            this.Controls.Add(operationCostTextBox);
            this.Controls.Add(saveOperationButton);
            this.Controls.Add(employeeNameLabel);
            this.Controls.Add(employeeNameTextBox);
            this.Controls.Add(employeePositionLabel);
            this.Controls.Add(employeePositionTextBox);
            this.Controls.Add(employeeSalaryLabel);
            this.Controls.Add(employeeSalaryTextBox);
            this.Controls.Add(saveEmployeeButton);
            this.Controls.Add(expenseCategoryLabel);
            this.Controls.Add(expenseCategoryTextBox);
            this.Controls.Add(expenseAmountLabel);
            this.Controls.Add(expenseAmountTextBox);
            this.Controls.Add(expenseDateLabel);
            this.Controls.Add(expenseDatePicker);
            this.Controls.Add(saveExpenseButton);
            this.Controls.Add(calculateCostButton); // Добавляем кнопку для расчета стоимости
            this.Controls.Add(resultLabel);
            this.Controls.Add(totalCostLabel);
        }

        private void SaveProductButton_Click(object sender, EventArgs e)
        {
            var result = dbHelper.AddProduct(productNameTextBox.Text, productDescriptionTextBox.Text, out string message);
            resultLabel.Text = result ? message : $"Ошибка: {message}";
        }

        private void SaveMaterialButton_Click(object sender, EventArgs e)
        {
            var result = dbHelper.AddMaterial(materialNameTextBox.Text, materialUnitTextBox.Text, decimal.Parse(materialCostTextBox.Text), out string message);
            resultLabel.Text = result ? message : $"Ошибка: {message}";
        }

        private void SaveOperationButton_Click(object sender, EventArgs e)
        {
            var result = dbHelper.AddOperation(operationNameTextBox.Text, decimal.Parse(operationCostTextBox.Text), out string message);
            resultLabel.Text = result ? message : $"Ошибка: {message}";
        }

        private void SaveEmployeeButton_Click(object sender, EventArgs e)
        {
            var result = dbHelper.AddEmployee(employeeNameTextBox.Text, employeePositionTextBox.Text, decimal.Parse(employeeSalaryTextBox.Text), out string message);
            resultLabel.Text = result ? message : $"Ошибка: {message}";
        }

        private void SaveExpenseButton_Click(object sender, EventArgs e)
        {
            var result = dbHelper.AddExpense(expenseCategoryTextBox.Text, decimal.Parse(expenseAmountTextBox.Text), expenseDatePicker.Value, out string message);
            resultLabel.Text = result ? message : $"Ошибка: {message}";
        }

        private void CalculateCostButton_Click(object sender, EventArgs e)
        {
            // Логика для расчета стоимости
            totalCostLabel.Text = "Общая стоимость: "; // Очищаем метку
            resultLabel.Text = "Стоимость рассчитана."; // Пример сообщения
            var result = dbHelper.GetSumOfAll(out decimal totalCost, out string message);
            var totalCostInSom = result + (result * (decimal)0.10); // Добавляем 10% учёта налогов
            totalCostLabel.Text = totalCostLabel.Text + Math.Round(totalCostInSom, 2) + " Кыргызских сом";
        }
    }
}
