import React, { useState } from 'react'
import { useLocation } from 'react-router-dom';
import * as bt from 'react-bootstrap';
import { Translation } from '../../components/translation/'
import { LanguageSelector } from '../languageSelector';
import { AppProvider } from '../../contexts/appContext';
const Navigation: React.FC = () => {
    return (
        <>
            <bt.Navbar collapseOnSelect bg="light" variant="light" expand="lg">
                <bt.Container>
                    <bt.Navbar.Brand href="/"><Translation tid="app_title" /></bt.Navbar.Brand>
                    <bt.Navbar.Toggle aria-controls="responsive-navbar-nav" />
                    <bt.Navbar.Collapse id="responsive-navbar-nav">
                        <bt.Nav className="me-auto">
                            <bt.Nav.Link href="/"><Translation tid="home" /></bt.Nav.Link>
                        </bt.Nav>
                        <LanguageSelector />
                    </bt.Navbar.Collapse>
                </bt.Container>
            </bt.Navbar>
        </>
    )
};

export default Navigation;