import "./App.css";
import "primereact/resources/themes/fluent-light/theme.css";
import "primereact/resources/primereact.min.css";
import "primeicons/primeicons.css";
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import LoginPage from './pages/LoginPage'; 
import Inicio from './pages/Inicio';   

function App() {
  return (
        <Router>
            <Routes>
                <Route path="/login" element={<LoginPage />} />
                <Route path="/inicio" element={<Inicio />} />
            </Routes>
        </Router>
  );
}

export default App;
