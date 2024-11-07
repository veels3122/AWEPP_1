import React, { useState, useEffect,useMemo } from 'react';
import { Line } from 'react-chartjs-2';
import './finanzas.css';

const Finanzas = () => {
  const initialLabels = useMemo(() => ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'], []); 
  const currentMonthIndex = new Date().getMonth();

  const [monthLabels, setMonthLabels] = useState(initialLabels.slice(0, currentMonthIndex + 1));
  const [financialData, setFinancialData] = useState({
    dollarRateMonthly: Array(currentMonthIndex + 1).fill().map(() => (4200 + Math.random() * 100).toFixed(2)),
    oilPriceMonthly: Array(currentMonthIndex + 1).fill().map(() => (75 + Math.random() * 10).toFixed(2)),
    uvrValue: 300,
  });

  useEffect(() => {
    const checkForNewMonth = () => {
      const now = new Date();
      const newMonthIndex = now.getMonth();

      if (newMonthIndex > monthLabels.length - 1) {
        setFinancialData(prevData => {
          const newDollarRate = parseFloat(prevData.dollarRateMonthly[prevData.dollarRateMonthly.length - 1]) + (Math.random() * 10 - 5);
          const newOilPrice = parseFloat(prevData.oilPriceMonthly[prevData.oilPriceMonthly.length - 1]) + (Math.random() * 3 - 1.5);
          const newUvrValue = parseFloat(prevData.uvrValue) + (Math.random() * 0.5 - 0.25);

          return {
            dollarRateMonthly: [
              ...prevData.dollarRateMonthly,
              isNaN(newDollarRate) ? prevData.dollarRateMonthly[prevData.dollarRateMonthly.length - 1] : newDollarRate.toFixed(2)
            ],
            oilPriceMonthly: [
              ...prevData.oilPriceMonthly,
              isNaN(newOilPrice) ? prevData.oilPriceMonthly[prevData.oilPriceMonthly.length - 1] : newOilPrice.toFixed(2)
            ],
            uvrValue: isNaN(newUvrValue) ? prevData.uvrValue : newUvrValue.toFixed(2),
          };
        });

        setMonthLabels(prevLabels => [
          ...prevLabels,
          initialLabels[newMonthIndex]
        ]);
      }
    };

    const intervalId = setInterval(checkForNewMonth, 86400000);
    return () => clearInterval(intervalId);
  }, [monthLabels, initialLabels]);

  const dollarLineChartData = {
    labels: monthLabels,
    datasets: [
      {
        label: 'Tasa del Dólar (COP)',
        data: financialData.dollarRateMonthly.map(rate => parseFloat(rate)),
        borderColor: 'rgba(75, 192, 192, 1)',
        backgroundColor: 'rgba(75, 192, 192, 0.2)',
        fill: true,
        tension: 0.3,
      },
    ],
  };

  const oilAreaChartData = {
    labels: monthLabels,
    datasets: [
      {
        label: 'Precio del Petróleo (USD)',
        data: financialData.oilPriceMonthly.map(price => parseFloat(price)),
        borderColor: 'rgba(255, 159, 64, 1)',
        backgroundColor: 'rgba(255, 159, 64, 0.3)',
        fill: true,
        tension: 0.4,
      },
    ],
  };

  return (
    <div className="finanzas-container">
      <div className="financial-indicators">
        <div className="indicator-card">
          <h3>Tasa del Dólar</h3>
          <p>${financialData.dollarRateMonthly[financialData.dollarRateMonthly.length - 1]} COP</p>
        </div>
        <div className="indicator-card">
          <h3>Precio del Petróleo</h3>
          <p>${financialData.oilPriceMonthly[financialData.oilPriceMonthly.length - 1]} USD</p>
        </div>
        <div className="indicator-card">
          <h3>Valor UVR</h3>
          <p>${financialData.uvrValue} COP</p>
        </div>
      </div>

      <div className="charts-section horizontal-charts">
        <h3>Tendencias Financieras</h3>
        
        <div className="chart small-chart">
          <Line data={dollarLineChartData} options={{ responsive: true, title: { display: true, text: 'Tasa del Dólar (COP)' } }} />
        </div>

        <div className="chart small-chart">
          <Line data={oilAreaChartData} options={{ responsive: true, title: { display: true, text: 'Precio del Petróleo (USD)' } }} />
        </div>
      </div>

      <div className="news-section">
        <h3>Noticias y Consejos Financieros</h3>
        <ul>
          <li>
            <h4>📈 ¿Por qué está subiendo el dólar?</h4>
            <p>Explora cómo los cambios en el mercado global afectan el tipo de cambio.</p>
            <a href="https://ejemplo.com/dolar" target="_blank" rel="noopener noreferrer">Leer más</a>
          </li>
          <li>
            <h4>🛢️ El impacto del precio del petróleo en la economía</h4>
            <p>Descubre cómo el precio del crudo puede influir en los costos de vida.</p>
            <a href="https://ejemplo.com/petroleo" target="_blank" rel="noopener noreferrer">Leer más</a>
          </li>
          <li>
            <h4>📊 ¿Qué es la UVR y cómo afecta tus préstamos?</h4>
            <p>Aprende sobre la UVR y su impacto en los créditos en Colombia.</p>
            <a href="https://ejemplo.com/uvr" target="_blank" rel="noopener noreferrer">Leer más</a>
          </li>
          <li>
            <h4>💰 ¿Qué es un CDT y cuáles son sus beneficios?</h4>
            <p>Conoce los Certificados de Depósito a Término y cómo pueden ayudarte a ahorrar con intereses.</p>
            <a href="https://ejemplo.com/cdt" target="_blank" rel="noopener noreferrer">Leer más</a>
          </li>
          <li>
            <h4>💡 Consejos para aumentar tu ahorro</h4>
            <p>Descubre estrategias simples y efectivas para incrementar tu ahorro mensual.</p>
            <a href="https://ejemplo.com/ahorro" target="_blank" rel="noopener noreferrer">Leer más</a>
          </li>
        </ul>
      </div>
    </div>
  );
};

export default Finanzas;
