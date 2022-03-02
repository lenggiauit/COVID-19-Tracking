import React, { useState } from 'react'
import { useLocation } from 'react-router-dom';
import * as bt from 'react-bootstrap';
import { Translation } from '../../components/translation/'
import { LanguageSelector } from '../languageSelector';
import { AppProvider } from '../../contexts/appContext';
import { AutoComplete } from '../autoComplete';
import countriesData from "../../locales/countries.json";
import { Covid19DataByCountry } from '../../types/covid19DataByCountry';
import { useHistory } from "react-router-dom";

const Navigation: React.FC = () => {
    const history = useHistory();
    const searchCountryHandler = (item: Covid19DataByCountry) => {
        history.push('/country', item);
        history.go(0);
    }
    return (
        <>
            <bt.Navbar collapseOnSelect variant="light" expand="lg">
                <bt.Container>
                    <bt.Navbar.Brand href="/"><Translation tid="app_title" /></bt.Navbar.Brand>
                    <bt.Navbar.Toggle aria-controls="responsive-navbar-nav" />
                    <bt.Navbar.Collapse id="responsive-navbar-nav">
                        <bt.Nav>
                            <bt.Nav.Link href="/"><Translation tid="home" /></bt.Nav.Link>
                        </bt.Nav>

                        <bt.Nav className="me-auto"></bt.Nav>
                        <form className="form-inline my-1 my-lg-0">
                            <AutoComplete data={countriesData} searchHandler={searchCountryHandler} />
                        </form>
                        <LanguageSelector />
                    </bt.Navbar.Collapse>
                </bt.Container>
            </bt.Navbar>
        </>
    )
};

export default Navigation;