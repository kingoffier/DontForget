import React from 'react';
import ReactDOM from "react-dom/client";
import App from "./App.jsx";
import "./index.css";
import RegPage from "./components/RegPage.jsx";
import AuthPage from "./components/AuthPage.jsx";
import {createBrowserRouter,RouterProvider} from 'react-router-dom'
import MainPage from './components/MainPage.jsx';

const router = createBrowserRouter([
  {
    path: "/",
    element: <App />,
    errorElement:<div>Not Found</div>
  },
  {
    path: "/authorisation",
    element: <AuthPage />,
  },
  {
    path: "/registration",
    element: <RegPage />,
  },
  {
    path: "/main",
    element: <MainPage />,
  },
]);


ReactDOM.createRoot(document.getElementById("root")).render(
  <React.StrictMode>
    <RouterProvider router={router} />
  </React.StrictMode>
);
