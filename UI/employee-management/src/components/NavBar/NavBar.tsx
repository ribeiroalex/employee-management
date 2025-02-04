import React from "react";

const NavBar = () => {
    return (
        <div className="uk-container">
            <nav className="uk-navbar">
                <div className="uk-navbar-left">
                    <a href="#" className="uk-navbar-item uk-logo">Employyes</a>
                </div>

                <div className="uk-navbar-right">
                    <ul className="uk-navbar-nav">
                        <li>
                            <a href="/create"><span uk-icon="icon:plus; ratio: 1.2"></span></a>
                        </li>
                    </ul>
                </div>
            </nav>
        </div>
    )
}

export default NavBar;