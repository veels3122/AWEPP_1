import "./App.css";
import LoginPage from "./pages/Login.page";
import InicioForm from "./components/Inicio.form";
import "primereact/resources/themes/fluent-light/theme.css";
import "primereact/resources/primereact.min.css";
import "primeicons/primeicons.css";
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import 'primereact/resources/themes/lara-light-indigo/theme.css';  
import 'primereact/resources/primereact.min.css';  
import 'primeicons/primeicons.css'; 


function App() {
    return (
        <Router>
            <Routes>
                <Route path="/" element={<LoginPage />} />
                <Route path="/principal" element={<InicioForm />} /> 
            </Routes>
        </Router>
    );
}

export default App;
