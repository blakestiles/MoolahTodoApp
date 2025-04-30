# 🧠 Moolah Todo List – Full Stack Challenge (Vue.js + .NET Core)

Welcome to the **Moolah Todo List App**, a dynamic full-stack to-do management system crafted to showcase modern frontend architecture, backend flexibility, and thoughtful design patterns — all in one seamless experience.

## 🔥 Live Demo Preview

> Select your Provider → Add tasks → Update, search, filter, and enjoy buttery-smooth task management — all backed by real-time updates via API.

---

## 🚀 Tech Stack

- **Frontend**: Vue.js (Composition + Vuex), SCSS
- **Backend**: ASP.NET Core Web API (.NET 8.0)
- **ORM**: Entity Framework Core
- **Database**: SQLite
- **HTTP Client**: Axios
- **Design Pattern**: Factory Pattern (Dynamic Provider Selection)
- **UX Enhancements**: Debounce Search, Undo Delete, Dark/Light Mode, Responsive Animations

---

## 🎯 Features Breakdown

### 🏗️ 1. Provider Switching (Factory Pattern)
- Users can select between providers (`ProviderA`, `ProviderB`) at runtime.
- Uses the **Factory Pattern** to dynamically instantiate the correct provider — decoupling logic and maximizing scalability.
- ✅ Easily extendable to new data sources like Firebase, Supabase, etc.

### 🔎 2. Smart Search with Debounce
- Implements **debounced API search** using `lodash.debounce` to optimize server hits and reduce API overload.
- Typing into the search bar intelligently filters todos from the backend.

### 🧾 3. Add Todos with Tagging
- Add tasks with optional priority tags: `Low`, `Med`, `High`.
- Each task is stored in the database in real time with a visually appealing tag badge.

### ✅ 4. Update Todo (Mark Done / Edit Name)
- Mark tasks as **done/undone** with instant UI feedback.
- Task name can be edited inline with smooth transitions.
- Updates are persisted in the backend (toggle state saved in DB).

### ❌ 5. Delete + Undo
- Instant task deletion with a **snackbar-based undo option**.
- Undo preserves task state, including the `done` status.
- Guarantees user-friendly error recovery — even on accidental deletes.

### 🌗 6. Dark Mode / Light Mode
- Toggle between sleek dark and modern light UI themes.
- Theme preference is saved in `localStorage` across sessions.

### 🔁 7. Import / Export Tasks (JSON)
- Export your to-do list as a `.json` file.
- Re-import anytime to resume where you left off.
- All task metadata (tags, status) is preserved.

### 📋 8. Filtering
- Toggle between:
  - `All`
  - `Active`
  - `Completed`
- Dynamically recalculates progress bar and UI.

### 📊 9. Task Stats & Progress Bar
- Real-time dashboard shows:
  - Task count
  - Tasks completed
  - Dynamic motivational messages (0%, 33%, 100%, etc.)

---

## 🧠 Architecture & Code Quality

- **Vuex Store**:
  - Central state management for tasks.
  - Actions/mutations keep UI and backend fully in sync.

- **Clean Separation of Concerns**:
  - Providers encapsulate API logic.
  - Vue components are modular and scoped.
  - Database logic is isolated using Entity Framework with code-first migrations.

- **Responsive Design**:
  - Works beautifully on mobile and desktop.
  - Animations, glow effects, and smooth transitions enhance engagement.

---

## 💡 Challenges & Solutions

### ✅ Challenge: Checkbox not saving after reload  
> 🔧 **Solution**: Fixed backend-to-frontend data mapping (`isDone` → `status.done`) in both Vuex mutations and API models.

### ✅ Challenge: Undo needed to persist checked state  
> 🔧 **Solution**: Preserved full task object (including `status.done`) in the `undoTask` logic and rerouted through the standard `addTask`.

### ✅ Challenge: Factory pattern clarity  
> 🔧 **Solution**: Built out `ProviderA`, `ProviderB`, and a clean Factory method to instantiate the correct provider based on dropdown selection in UI.

---


## 🛠️ How to Run
 1. Frontend (Vue.js)

cd frontend
npm install
npm run dev


2. Backend (.NET Core API)

cd backend
dotnet restore
dotnet ef database update
dotnet run
