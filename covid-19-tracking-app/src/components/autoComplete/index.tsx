import react, { ChangeEvent, FC, useState } from "react";
import styled from "styled-components";
import { Covid19DataByCountry } from "../../types/covid19DataByCountry";
import {
    AutoCompleteContainer,
    Input,
    AutoCompleteItem,
    AutoCompleteItemButton
} from "./styles";
const Root = styled.div`
  position: relative;
  width: 250px;
`;

interface IData {
    name: string;
    code: string;
}
interface autoCompleteProps {
    data: any[];
    searchHandler(arg?: Covid19DataByCountry): void;
}
export const AutoComplete: FC<autoCompleteProps> = ({
    data,
    searchHandler
}) => {
    const [search, setSearch] = useState({
        text: "",
        suggestions: []
    });
    const [isComponentVisible, setIsComponentVisible] = useState(true);
    const onTextChanged = (e: ChangeEvent<HTMLInputElement>) => {
        const value = e.target.value;
        let suggestions: any = [];
        if (value.length > 0) {
            const regex = new RegExp(`^${value}`, "i");
            suggestions = data.sort().filter((v: IData) => regex.test(v.name));
        }
        setIsComponentVisible(true);
        setSearch({ suggestions, text: value });
    };

    const suggestionSelected = (value: IData) => {
        setIsComponentVisible(false);

        setSearch({
            text: value.name,
            suggestions: []
        });
        let country: Covid19DataByCountry = {
            avg7Case: 0,
            avg7CasePop: 0,
            avg7Death: 0,
            avg7DeathPop: 0,
            casesLast7Days: 0,
            casesLast7DaysChange: 0,
            casesPerHundredThousand: 0,
            confirmed: 0,
            countryCode: value.code,
            cumulativeConfirmed: 0,
            cumulativeDeaths: 0,
            deaths: 0,
            deathsLast7Days: 0,
            deathsLast7DaysChange: 0,
            deathsPerHundredThousand: 0,
            todayConfirmed: 0,
            todayDeaths: 0,
            updatedDate: null,
            wkCasePop: 0,
            wkDeathPop: 0
        }

        searchHandler(country);
    };

    const { suggestions } = search;

    return (
        <Root>
            <div className="form-outline"
                onClick={() => setIsComponentVisible(false)}
            />
            <div>
                <Input
                    id="input"
                    placeholder="Search by country"
                    className="form-control"
                    autoComplete="off"
                    value={search.text}
                    onChange={onTextChanged}
                    type={"text"}
                />
            </div>
            {suggestions.length > 0 && isComponentVisible && (
                <AutoCompleteContainer >
                    {suggestions.map((item: IData) => (
                        <AutoCompleteItem key={item.code}>
                            <AutoCompleteItemButton
                                key={item.code}
                                onClick={() => suggestionSelected(item)}
                            >
                                {item.name}
                            </AutoCompleteItemButton>
                        </AutoCompleteItem>
                    ))}
                </AutoCompleteContainer>
            )}
        </Root>
    );
};
