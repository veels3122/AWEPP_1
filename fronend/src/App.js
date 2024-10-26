import "./App.css";
import Register from "./components/Register.js"; 
import LoginPage from "./pages/Login.page";
import InicioForm from "./components/Inicio.form";
import "primereact/resources/themes/fluent-light/theme.css";
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";


function App() {
    return (
        <Router>
            <Routes>
                <Route path="/" element={<LoginPage />} />
                <Route path="/principal" element={<InicioForm />} />
                <Route path="/register" element={<Register />} />
            </Routes>
        </Router>
    );
}

export default App;
