import { useState } from "react";
import axios from "axios";
import Modal from "./Modal";
import { Link } from "react-router-dom";

export default function RegPage() {
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");
  const [firstname, setFirsname] = useState("");
  const [secondname, setSecondname] = useState("");
  const [email, setEmail] = useState("");
  const [modal, setModal] = useState(false);
  const handleSubmit = async (event) => {
    event.preventDefault();
    const response = await axios.post(
      "http://localhost:5300/api/User/CreateNewUser",
      {
        email: email,
        firstName: firstname,
        secondName: secondname,
        password: password,
        login: username,
      },
      { withCredentials: true }
    );
    if (response.status === 200) {
      setModal(true);
    }
  };
  return (
    <main className="regPage">
      <section className="registration">
        <p>Регистрация</p>
        <form className="registration" onSubmit={handleSubmit}>
          <input
            name="login"
            type="text"
            placeholder="Login"
            value={username}
            onChange={(e) => setUsername(e.target.value)}
          />
          <input
            name="email"
            type="text"
            placeholder="Email"
            value={email}
            onChange={(e) => setEmail(e.target.value)}
          />
          <input
            name="firstname"
            type="text"
            placeholder="Firstname"
            value={firstname}
            onChange={(e) => setFirsname(e.target.value)}
          />
          <input
            name="secondname"
            type="text"
            placeholder="Secondname"
            value={secondname}
            onChange={(e) => setSecondname(e.target.value)}
          />
          <input
            name="password"
            type="password"
            placeholder="Password"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
          />
          <input type="submit" value={"Register"} className="signIn" />
        </form>
        {modal ? (
          <Modal>
            <h1>Вы успешно зарегистрировались</h1>
            <div className="ok">
              <Link to="/authorisation">
                <button onClick={() => setModal(false)} className="cancelmodal">
                  Ок
                </button>
              </Link>
            </div>
          </Modal>
        ) : (
          <p></p>
        )}
      </section>
    </main>
  );
}
