import React from 'react';
import * as bt from 'react-bootstrap';
import Placeholder from 'react-bootstrap/Placeholder';
import { GetRandomBgColor } from '../../utils/functions';
import "./countryItem.css";
import { Translation } from '../translation';
import { RegionColors } from '../../types/colors';
import { uuid } from 'uuidv4';
import { Covid19DataByCountry } from '../../types/covid19DataByCountry';
//@ts-ignore
import ReactCountryFlag from "react-country-flag";
import { KeyValues } from '../../locales/';

type Props = {
    data?: Covid19DataByCountry;
    max: number;
    selectedItem(arg?: Covid19DataByCountry): void;
}

const TopCountriesItem: React.FC<Props> = ({ data, max, selectedItem }) => {

    const handleClick = () => {
        selectedItem(data)!;
    }
    if (data != null) {
        return (
            <>
                <div className="country-item-body my-4" onClick={handleClick}>
                    <div className="d-flex justify-content-between">
                        <div>
                            <ReactCountryFlag className="emojiFlag"
                                svg
                                style={{
                                    width: '1.2em',
                                    height: '1.2em',
                                }}
                                title={KeyValues["country"][data.countryCode]}
                                countryCode={data.countryCode} />&nbsp;
                            <span className="text-left" >
                                <b>{KeyValues["country"][data.countryCode]} </b>
                            </span>
                        </div>
                        <div>
                            <b><span className="text-warning">
                                {data.confirmed.toLocaleString(undefined, { maximumFractionDigits: 0 })} </span>
                                /
                                <span className="text-danger"> {data.deaths.toLocaleString(undefined, { maximumFractionDigits: 0 })}</span>&nbsp;
                                (<span>{((data.deaths / data.confirmed) * 100).toFixed(2)} %</span>)
                            </b>
                        </div>

                    </div>
                    <div className="d-flex justify-content-between">
                        <div></div>
                        &nbsp;
                        <small style={{ fontSize: 10 }}>
                            <Translation tid="Confirmed" /> / <Translation tid="Deaths" />
                        </small >
                    </div>
                    <bt.ProgressBar variant={GetRandomBgColor()} key={uuid()} now={data.confirmed == max ? 100 : (data.confirmed / max) * 100} />
                </div>
            </>
        )
    }
    else {
        const colorRandom = GetRandomBgColor();
        return (
            <>
                <>
                    <div className="country-item-body my-4" onClick={handleClick}>
                        <div className="d-flex justify-content-between">
                            <div>
                                <Placeholder as="a" animation="glow">
                                    <Placeholder xs={2} bg={colorRandom} size="sm" />
                                </Placeholder>
                            </div>
                            <div>
                                <Placeholder as="a" animation="glow">
                                    <Placeholder xs={2} bg={colorRandom} size="sm" />
                                </Placeholder>
                            </div>

                        </div>
                        <div className="d-flex justify-content-between">
                            <div></div>
                            &nbsp;
                            <small style={{ fontSize: 10 }}>
                                <Placeholder as="a" animation="glow">
                                    <Placeholder xs={2} bg={colorRandom} size="sm" />
                                </Placeholder>
                            </small >
                        </div>
                        <Placeholder as="a" animation="glow">
                            <Placeholder xs={12} bg={colorRandom} size="sm" />
                        </Placeholder>
                    </div>
                </>
            </>)
    }
}

export default TopCountriesItem;