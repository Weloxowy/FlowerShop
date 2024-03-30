import React from 'react'
import ReactDOM from 'react-dom/client'
import './index.css'
import {
    BrowserRouter,
    Routes, // instead of "Switch"
    Route,
} from "react-router-dom";
import App from "./App.tsx";
import Home from "./Home.tsx";
//basic routing
ReactDOM.createRoot(document.getElementById('root')).render(
    <BrowserRouter>
        <Routes>
            <Route path="/" element={<Home />} />
        </Routes>
        <Routes>
            <Route path="/pag" element={<App />} />
        </Routes>
    </BrowserRouter>
)
